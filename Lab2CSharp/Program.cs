using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть номер завдання від 1 до 4:");
        string input = Console.ReadLine();
        int taskNumber;

        if (int.TryParse(input, out taskNumber) && taskNumber >= 1 && taskNumber <= 6)
        {
            switch (taskNumber)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Номер завдання повинен бути від 1 до 6.");
        }
    }

    static void Task1()
    {
        Console.WriteLine("Введіть розмір масиву:");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[size];

        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < size; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Введіть число:");
        int x = Convert.ToInt32(Console.ReadLine());

        DoubleElementsLessThanX(array, x);

        Console.WriteLine("Масив після змін:");
        foreach (int element in array)
        {
            Console.WriteLine(element);
        }
    }

    static void Task2()
    {
        Console.Write("Введіть розмір масиву: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] array = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 100); // Заповнюємо масив випадковими числами від 1 до 100
        }

        int maxIndex = Array.IndexOf(array, array.Max()); // Знаходимо індекс максимального елемента

        // Міняємо місцями максимальний елемент і перший елемент
        int temp = array[0];
        array[0] = array[maxIndex];
        array[maxIndex] = temp;

        Console.WriteLine("Масив після змін:");
        foreach (int element in array)
        {
            Console.WriteLine(element);
        }
    }

    static void Task3()
    {
        Console.WriteLine("Введіть розмір матриці:");
        int size = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[size, size];
        Random random = new Random();

        Console.WriteLine("Початкова матриця:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = random.Next(1, 100); // Заповнюємо матрицю випадковими числами від 1 до 100
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        double average = CalculateAverageBelowSecondaryDiagonal(matrix);
        Console.WriteLine("Середнє значення елементів нижче другої діагоналі: " + average);
    }

    static void Task4()
    {
        Console.WriteLine("Введіть розмір матриці:");
        int size = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[size, size];
        Random random = new Random();

        Console.WriteLine("Початкова матриця:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = random.Next(1, 100); // Заповнюємо матрицю випадковими числами від 1 до 100
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        int[] result = SumEvenPositiveInColumns(matrix);
        Console.WriteLine("Сума парних додатніх чисел в стовпцях:");
        foreach (int sum in result)
        {
            Console.WriteLine(sum);
        }
    }

    static double CalculateAverageBelowSecondaryDiagonal(int[,] matrix)
    {
        int sum = 0;
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                sum += matrix[i, j];
                count++;
            }
        }

        return count > 0 ? (double)sum / count : 0;
    }

    static int[] SumEvenPositiveInColumns(int[,] matrix)
    {
        int[] result = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
                {
                    sum += matrix[i, j];
                }
            }
            result[j] = sum;
        }
        return result;
    }

    static void DoubleElementsLessThanX(int[] array, int x)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < x)
            {
                array[i] *= 2;
            }
        }
    }
}
