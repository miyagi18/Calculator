using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double? M = 0;
            while (true)
            {
                Console.WriteLine("Введите операцию: ");
                string op = Console.ReadLine();

                double? num1 = null;
                double? num2 = null;
                double? result = null;

                if (op == "+" || op == "-" || op == "*" || op == "/" || op == "%")
                {
                    Console.WriteLine("Введите первое число (или 'MR' для использования памяти): ");
                    string str_num1 = Console.ReadLine();
                    if (str_num1 == "MR")
                    {
                        num1 = M;
                        Console.WriteLine($"Используется значение из памяти: {M}");
                    }
                    else
                    {
                        try
                        {
                            num1 = Convert.ToDouble(str_num1);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный ввод первого числа!");
                        }
                    }

                    Console.WriteLine("Введите второе число (или 'MR' для использования памяти): ");
                    string str_num2 = Console.ReadLine();
                    if (str_num2 == "MR")
                    {
                        num2 = M;
                        Console.WriteLine($"Используется значение из памяти: {M}");
                    }
                    else
                    {
                        try
                        {
                            num2 = Convert.ToDouble(str_num2);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный ввод второго числа!");
                        }
                    }
                }
                switch (op)
                {

                    case "+":
                        result = num1 + num2;
                        goto case "print";
                    case "-":
                        result = num1 - num2;
                        goto case "print";
                    case "*":
                        result = num1 * num2;                      
                        goto case "print";
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Ошибка: Деление на ноль!");
                            break;
                        }
                        result = num1 / num2;
                        goto case "print";
                    case "%":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Ошибка: Деление на ноль!");
                            break;
                        }
                        result = num1 % num2;
                        goto case "print";
                    case "1/x":
                        double? x = null;
                        Console.WriteLine("Введите x (или 'MR' для использования памяти): ");
                        string str_x = Console.ReadLine();

                        if (str_x == "MR")
                        {
                            if (M == null)
                            {
                                Console.WriteLine("Память пуста!");
                                break;
                            }
                            x = M;
                            Console.WriteLine($"Используется значение из памяти: {M}");
                        }
                        else
                        {
                            try
                            {
                                x = Convert.ToDouble(str_x);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Некорректный ввод числа!");
                                break;
                            }
                        }

                        if (x == 0)
                        {
                            Console.WriteLine("Ошибка: Деление на ноль!");
                            break;
                        }
                        result = 1 / x;
                        goto case "print";
                    case "x**2":
                        result = PowTo2(M);
                        goto case "print";
                    case "sqrt":
                        result = SqrtFromNumber(M); 
                        if (result != null) goto case "print";
                        break;
                    case "M+":
                        Console.WriteLine("Введите число для сохранения в память: ");
                        string str_num = Console.ReadLine();
                        try
                        {
                            double number = Convert.ToDouble(str_num);
                            M += number;
                            Console.WriteLine($"Число {number} добавлено в память. Текущее M: {M}");
                            Console.Write("Нажмите чтобы продолжить...");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный ввод числа!");
                        }
                        break;

                    case "M-":
                        Console.WriteLine("Введите число для сохранения в память: ");
                        str_num = Console.ReadLine();
                        try
                        {
                            double number = Convert.ToDouble(str_num);
                            M -= number;
                            Console.WriteLine($"Число {number} вычтено из памяти. Текущее M: {M}");
                            Console.Write("Нажмите чтобы продолжить...");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный ввод числа!");
                        }
                        break;
                    case "MR":
                        Console.WriteLine($"Число M: {M}");
                        break;
                    case "print":
                        Console.WriteLine($"Результат: {result}");
                        int tmp = SaveNumber();
                        if (tmp == 1)
                        {
                            M += result;
                        }
                        else if (tmp == 2)
                        {
                            M -= result;
                        }
                        Console.Write("Нажмите чтобы продолжить...");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ошибка: Неизвестная операция");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                };
                
            }
        }
        static double? PowTo2(double? M)
        {
            Console.WriteLine("Введите x (или 'MR' для использования памяти): ");
            string str_x = Console.ReadLine();

            double x;
            if (str_x == "MR")
            {
                if (M == null)
                {
                    Console.WriteLine("Память пуста!");
                    return null;
                }
                x = M.Value;
                Console.WriteLine($"Используется значение из памяти: {M}");
            }
            else
            {
                try
                {
                    x = Convert.ToDouble(str_x);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод числа!");
                    return null;
                }
            }
            return Math.Pow(x, 2);
        }

        static double? SqrtFromNumber(double? M)
        {
            Console.WriteLine("Введите x (или 'MR' для использования памяти): ");
            string str_x = Console.ReadLine();

            double x;
            if (str_x == "MR")
            {
                if (M == null)
                {
                    Console.WriteLine("Память пуста!");
                    return null;
                }
                x = M.Value;
                Console.WriteLine($"Используется значение из памяти: {M}");
            }
            else
            {
                try
                {
                    x = Convert.ToDouble(str_x);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод числа!");
                    return null;
                }
            }

            if (x < 0)
            {
                Console.WriteLine("Ошибка: Нельзя вычислить корень из отрицательного числа!");
                return null;
            }
            return Math.Sqrt(x);
        }

        static int SaveNumber()
        {
            Console.WriteLine("Хотите сохранить число (M+)? (да/нет)");
            string answer = Console.ReadLine();
            if (answer == "да")
            {
                return 1;
            }
            
            Console.WriteLine("Хотите вычесть число из памяти (М-)? (да/нет)");
            string answer2 = Console.ReadLine();
            if (answer2 == "да")
            {
                return 2;
            }
            return 0;
        }


    }
}
