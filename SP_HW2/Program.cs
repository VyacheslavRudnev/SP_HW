using System.Text;
using System.Threading;

partial class Program
{
    private static bool isGenerating = true;

    static void Main()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Завдання 002 на тему ThreadPool\r\n" +
            "Створити метод який буде що секунди генерувати рандомне число." +
            "\r\nМетод повинен запускатися в потоці. Якщо користувач нажме кнопку S на клавіатурі," +
            "\r\nто генерація цифр повинна запинитися, якщо знову нажме - то продовжитися.\r\n" +
            "Продумайте як можна зробити так, щоб потік міг зупинятися і відновлювати\r\nсвою роботу.\n");

        Thread randomNumberThread = new Thread(GenerateNumbers);
        randomNumberThread.Start();

        Console.WriteLine("Натисніть 'S' щоб зупинити/відновити генерацію. Для виходу натисніть 'Enter' \n");

        while (true)
        {
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.S)
            {
                isGenerating = !isGenerating;
                Console.WriteLine(isGenerating ? "Відновлення генерації випадкових чисел.\n" : "\nГенерація випадкових чисел зупинена.");
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Завершення роботи програми");
                Environment.Exit(0);
            }
        }
        
        static void GenerateNumbers()
        {
            Random random = new Random();

            while (true)
            {
                if (isGenerating)
                {
                    int randomNumber = random.Next(1, 100);
                    Console.WriteLine($"Випадкове число: {randomNumber}");
                }
                Thread.Sleep(1000);
            }
        }
    }
}