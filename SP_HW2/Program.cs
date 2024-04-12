using System.Text;


partial class Program
{
    static int[] Arr;

    static async Task Main()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Завдання 003 з іншим рішенням\r\n" +
            "Створити методи для сортування масиву та для бінарного пошуку в масиві (2 окремих методи)" +
            "\r\nПотрібно асинхронно запустити ці методи, так щоб після завершення першого запустився другий" +
            "\r\nВивести масив до та після сортування, а також індекс числа, яке шукаємо.\n");

        //Рішення №2
        Task Create = CreateArrey();
        await Create;
        Task Sort = SortingArrey();
        await Sort;
        Task Search = BinarySearch();
        await Search;

        static async Task CreateArrey()
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

        static async Task SortingArrey()
        {
            Console.WriteLine("Сортуємо масив ");
            int[] ArrCopy = (int[])Arr.Clone();
            Array.Sort(ArrCopy);
            PrintArray("Відсортований масив : ", ArrCopy);
            Console.WriteLine();
            Program.Arr = ArrCopy;
        }

        static async Task BinarySearch()
        {
            Console.Write("Введіть число, яке потрібно знайти: ");
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

        static async Task PrintArray(string label, int[] array)
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
