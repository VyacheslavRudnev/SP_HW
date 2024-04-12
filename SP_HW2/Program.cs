using System.Text;

partial class Program
{
    static object locker = new object();
    static int[] Arr;

    static void Main()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Завдання 003 на тему Locking threads\r\n" +
            "Створити методи для сортування масиву та для бінарного пошуку в масиві (2 окремих методи)" +
            "\r\nПотрібно асинхронно запустити ці методи, так щоб після завершення першого запустився другий" +
            "\r\nВивести масив до та після сортування, а також індекс числа, яке шукаємо.\n");

        Thread t_ca = new Thread(CreateArrey);
        Thread t_sa = new Thread(SortingArrey);
        Thread t_bs = new Thread(BinarySearch);
        t_ca.Start();
        t_sa.Start();
        t_bs.Start();

        static void CreateArrey()
        {
            lock (locker) 
            { 
                Random rnd = new Random();
                int[] Arr = new int[10];
                    Console.WriteLine("Створюємо випадковий масив на 10 элементів ");
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = rnd.Next(0, 25);
                    }
                PrintArray("Початковий масив : ", Arr);
                Program.Arr = Arr;    
                Console.WriteLine();
            }
        }

        static void SortingArrey()
        {
            lock (locker)
            {
                Console.WriteLine("Сортуємо масив ");
                int[] ArrCopy = (int[])Arr.Clone();
                Array.Sort(ArrCopy);
                PrintArray("Відсортований масив : ", ArrCopy);
                Console.WriteLine();
                Program.Arr = ArrCopy;
            }
        }

        static void BinarySearch(object searchValueObj)
        {
            lock(locker)
            {
                Console.WriteLine("Введіть число, яке потрібно знайти:");
                int searchValue = int.Parse(Console.ReadLine());
                int index = Array.BinarySearch(Arr, searchValue);

                if (index >= 0)
                {
                    Console.WriteLine($"Індекс числа {searchValue} в масиві: {index}");
                }
                else
                {
                    Console.WriteLine($"Число {searchValue} не знайдено в масиві.");
                }
            }
        }

        static void PrintArray(string label, int[] array)
        {
            Console.Write(label);
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
