using System;
using System.Linq;
using Lab_2;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите степень уравнения (1 или 2):");
        if (!int.TryParse(Console.ReadLine(), out int degree) || (degree != 1 && degree != 2))
        {
            Console.WriteLine("Некорректный ввод степени уравнения.");
            return;
        }

        int coefficientCount = degree + 1;
        double[] coefficients = new double[coefficientCount];

        for (int i = 0; i < coefficientCount; i++)
        {
            Console.WriteLine($"Введите коэффициент при x^{degree - i}:");
            while (!double.TryParse(Console.ReadLine(), out coefficients[i]))
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
            }
        }

        try
        {
            PolynomialEquation equation = Equations.CreateEquation(coefficients);
            Complex[] roots = equation.FindRoots();
            Console.WriteLine("Корни уравнения:");
            foreach (var root in roots)
            {
                Console.WriteLine(root);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
