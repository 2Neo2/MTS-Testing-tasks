// See https://aka.ms/new-console-template for more information

using System.Globalization;
using ConsoleApp6;

class Program
{
    private static IFormatProvider _ifp = CultureInfo.InvariantCulture;

    /// <summary>
    /// Задание №1 "Ломай меня полностью".
    /// </summary>
    private static void Task1() 
    {
        Console.WriteLine("!!!Task 1!!!");
        FailProcess();
    }
    private static void FailProcess() 
    {
        // Divide by zero.
        int zero = 0;
        double diff = 1 / zero;
        
        // Null exception.
        string line = null;
        Console.WriteLine(line[0]);
        
        // Index exception.
        int index = 5;
        int[] arr = new[] { 1, 2, 3 };
        Console.WriteLine(arr[index]);
        
        // Overflow exception.
        int max = Int32.MaxValue;
        int value = max + 1;
        
        // CastException.
        int parseValue = int.Parse("Hello");
    }
    
    /// <summary>
    /// Задание №2 "Операция "Ы"".
    /// </summary>
    private static void Task2() 
    {
        Console.WriteLine("!!!Task 2!!!");
        int someValue1 = 10;
        int someValue2 = 5;
        
        // Вариант 1.
        string result = (new Number(someValue1, _ifp).GetNum() + someValue2).ToString(_ifp);
        
        // Вариант 2.
        // result = (new Number(someValue1, _ifp).GetNum() + new Number(someValue2, _ifp).GetNum()).ToString(_ifp);

        Console.WriteLine(result);
        Console.ReadKey();
    }
    
    /// <summary>
    /// Задание №3 "Мне только спросить!".
    /// </summary>
    private static void Task3() 
    {
        Console.WriteLine("!!!Task 3!!!");
        // Получаем результирующие пары и выводим результат.
        foreach (var value in EnumerateFromTail(new List<int>{1, 2, 3, 4, 5, 6}, 3).ToList())
        {
            if (Equals(value.Item2, null))
            {
                Console.WriteLine("( " + value.Item1 + ",  )");
            }
            else
            {
                Console.WriteLine("( " + value.Item1 + "," + value.Item2 + " )");
            }
        }
    }
    
    /// <summary>
    /// Отсчитать несколько элементов с конца.
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="tailLength"> Сколько элементов отсчитать с конца (у последнего элемента tail = 0). </param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(IEnumerable<T> enumerable, int? tailLength) 
    {
        // Одним проходом по коллекции заполняем лист, нахожу пары по индеексу.
        List<(T, int?)> result = new List<(T, int?)>();
        for (int i = 0; i < enumerable.ToList().Count; ++i)
        {
            if (i == enumerable.ToList().Count - 1)
            {
                result.Add((enumerable.ToList()[i], 0));
                break;
            }
            int? diff = i - tailLength + 1;
            if (diff > 0)
            {
                result.Add((enumerable.ToList()[i], Convert.ToInt32(enumerable.ToList()[(int)(diff - 1)])));
            }
            else
            {
                result.Add((enumerable.ToList()[i], null));
            }
        }
        return result;
    }

    /// <summary>
    /// Задание №4 "Высший сорт".
    /// </summary>
    private static void Task4() 
    {
        // Плохо работает с дубликатами.
        List<int> collection = new List<int> { -1, -12, 2, 4, 6, 8, 9, 10, 23, 45, 34, 33, 32 };
        Console.WriteLine("Original collection: ");
        foreach (var number in collection)
        {
            Console.Write(" " + number);
        }

        Console.WriteLine("\nSorted collection: ");
        foreach (var number in GetSort(collection, 10, 45))
        {
            Console.Write(" " + number);
        }
    }
    
    /// <summary>
    /// Возвращает отсортированный по возрастанию поток чисел.
    /// </summary>
    /// <param name="inputStream"> Поток чисел от 0 до maxValue. Длина потока не превыщает миллиарда чисел.</param>
    /// <param name="sortFaktor"> Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число
    /// x, то в нем больше не встретятся числа меньше чем x (Sort faktor). </param>
    /// <param name="maxValue"> Максимально возможное значение чисел в потоке. Неотрицательное число не превышающее 2000.</param>
    /// <returns></returns>
    private static IEnumerable<int> GetSort(IEnumerable<int> inputStream, uint sortFaktor, uint maxValue) 
    {
        int faktorIndex = -1;
        List<int> faktorNumbers = new List<int>();
        for (int i = 0; i < inputStream.ToList().Count; ++i)
        {
            if (inputStream.ToList()[i] == sortFaktor && sortFaktor == -1) faktorIndex = i;
            
            if (faktorIndex != -1)
            {
                faktorNumbers.Add(inputStream.ToList()[i]);
            }
        }

        if (faktorIndex != -1)
        {
            MySort mySortFaktorNums = new MySort(inputStream.ToList().GetRange(faktorIndex, inputStream.ToList().Count));
            mySortFaktorNums.QuickSort(0, mySortFaktorNums.getNums().Count - 1);
            
            MySort mySortLossNums = new MySort(inputStream.ToList().GetRange(0, faktorIndex));
            mySortLossNums.QuickSort(0, mySortLossNums.getNums().Count - 1);
            inputStream = mySortLossNums.getNums();
            inputStream.ToList().AddRange(mySortFaktorNums.getNums());
        }
        else
        {
            MySort collection = new MySort(inputStream.ToList());
            collection.QuickSort(0, inputStream.ToList().Count - 1);
            inputStream = collection.getNums();
        }
        return inputStream;
    }

    /// <summary>
    /// Задание №5 "Слон из мухи".
    /// </summary>
    private static void Task5() 
    {
        Console.WriteLine("!!!Task 5!!!");
        TransformToElephant();
        Console.WriteLine("Муха");
        
        StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }
    
    private static void TransformToElephant() 
    {
        Console.WriteLine("Слон");
        // Изменяю стандартный output с консоли на фай,
        // /dev/null - системный файл, куда записывается слово "Муха".
        Console.SetOut(new StreamWriter("/dev/null"));
    }
    
    public static void Main(string[] args)
    {
        // Раскоментируйте методы для тестирования.
        //Task1();
        //Task2();
        //Task3();
        //Task4();
        //Task5();
    }
}