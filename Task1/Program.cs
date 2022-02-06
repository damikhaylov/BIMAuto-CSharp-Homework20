using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Условие задачи
            ***********************************************************************************************************

            В приложении объявить тип делегата, который ссылается на метод. Требования к сигнатуре метода следующие:
            - метод получает входным параметром переменную типа double;
            - метод возвращает значение типа double, которое является результатом вычисления.

            Реализовать вызов методов с помощью делегата, которые получают радиус R и вычисляют:
            - длину окружности по формуле D = 2 * π* R;
            - площадь круга по формуле S = π* R²;
            - объем шара. Формула V = 4/3 * π * R³.

            Методы должны быть объявлены как статические.
            */

            /* Реализация задачи
            ***********************************************************************************************************
            
            У пользователя запрашивается радиус и какое вычисление нужно выполнить. Метод вычисления по выбору 
            пользователя присваивается переменной делегата. Далее делегат выполняет вычисление.
            */

            GeomCalculation geomcalc = null; // Переменная делегата для еометрических вычислений
            double radius = 0;

            Console.WriteLine("Геометрические вычисления по заданному радиусу\n");
            while (true) // Код выполняется в бесконечном цикле, пока пользователь не введёт корректное значение радиуса
            {
                Console.Write("Введите радиус: ");
                try { radius = Convert.ToDouble(Console.ReadLine()); }
                catch (Exception) { };
                if (radius > 0) break;
                else Console.WriteLine("\nРадиус должен быть положительным числом.\n");
            }

            while (true) // Код выполняется в бесконечном цикле, пока пользователь не выберет вариант выхода из меню
            {
                Console.WriteLine("\n>>> Выберите, какое значение необходимо вычислить:\n");
                Console.WriteLine("1 — Вычислить длину окружности с заданным радиусом");
                Console.WriteLine("2 — Вычислить площадь круга с заданным радиусом");
                Console.WriteLine("3 — Вычислить объём шара с заданным радиусом");
                Console.WriteLine("0 — Завершить работу программы");
                Console.Write("\nВаш выбор: ");

                byte menuPoint = 255; // Переменная для выбора пользователем пункта меню, инициализирована в значение,
                                      // соответствующее дальнейшей обработке по-умолчанию
                                      // ("Такого пункта меню нет в списке.")

                try { menuPoint = Convert.ToByte(Console.ReadLine()); }
                catch (Exception) { }
                Console.WriteLine();
                switch (menuPoint) // Выполнение действий согласно выбранному пункту меню
                {
                    case 0: break;
                    case 1:
                        geomcalc = CircleLength; // Присвоение метода переменной делегата
                        Console.Write("Длина окружности равна: ");
                        break;
                    case 2:
                        geomcalc = CircleArea; // Присвоение метода переменной делегата
                        Console.Write("Площадь круга равна равна: ");
                        break;
                    case 3:
                        geomcalc = SphereVolume; // Присвоение метода переменной делегата
                        Console.Write("Объём шара равен: ");
                        break;
                    default:
                        Console.WriteLine("Такого пункта меню нет в списке.");
                        break;
                }

                // Здесь происходит вызов метода по выбору пользователя с помощью делегата
                if (geomcalc != null) Console.WriteLine(geomcalc(radius));

                if (menuPoint == 0) break; // Выход из программы

            }
        }
        static double CircleLength(double r) => 2 * Math.PI * r;
        static double CircleArea(double r) => Math.PI * r * r;
        static double SphereVolume(double r) => (4.0 / 3.0) * Math.PI * r * r * r;

        delegate double GeomCalculation(double x);
    }
}

