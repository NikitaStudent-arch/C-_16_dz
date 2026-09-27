using System.Text;

namespace C__16_dz
{
    internal class Program
    {
        public static void Task1()
        {

            bool IsPrime(int n)
            {
                if (n <= 1) return false;
                if (n == 2) return true;
                if (n % 2 == 0) return false;

                int boundary = (int)Math.Floor(Math.Sqrt(n));

                for (int i = 3; i <= boundary; i += 2)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }

            void Fibonacci()
            {
                using (StreamWriter stream = new StreamWriter("IsFibonacci.txt", true, Encoding.Unicode))
                {
                    int a = 0;
                    int b = 1;

                    stream.WriteLine(a);
                    stream.WriteLine(b);

                    for (int i = 3; i < 13; i++)
                    {
                        int c = a + b;
                        stream.WriteLine(c);
                        a = b;
                        b = c;
                    }
                }
            }
            Fibonacci();
            Console.WriteLine("The Fibonacci numbers are written down.");

            using (StreamWriter stream = new StreamWriter("IsPrime.txt", true, Encoding.Unicode))
            {
                for (int i = 1; i < 101; i++)
                {
                    if (IsPrime(i)) stream.WriteLine(i);
                }
                Console.WriteLine("Prime numbers are written down");
            }
        }

        public static void Task2()
        {
            string text = File.ReadAllText("Task2.txt");

            Console.WriteLine("Enter search term: ");
            string search = Console.ReadLine();
            Console.WriteLine("Enter replacement: ");
            string replacement = Console.ReadLine();

            if (text == search)
            {
                File.WriteAllText("Task2.txt", replacement);
                Console.WriteLine("The replacement was successful.");
            }
        }

        public static void Task3()
        {
            string moderate = File.ReadAllText("Moderate.txt");
            string[] ModerateArray = moderate.Split(new char[] { ' ' });

            string text = File.ReadAllText("Text.txt");
            string[] TextArray = text.Split(new char[] { ' ' });

            string[] text2 = (string[])TextArray.Clone();
            for (int i = 0; i < TextArray.Length; i++)
            {
                foreach (string m in ModerateArray)
                {
                    if (string.Equals(text2[i], m)) text2[i] = new string('*', m.Length);
                }
            }

            string result = string.Join(" ", text2);
            using (StreamWriter stream = new StreamWriter("Text.txt", false, Encoding.Unicode))
            {
                stream.WriteLine(result);
            }
            Console.WriteLine("Complete!");
        }

        public static void Task4()
        {
            string text = File.ReadAllText("Text2.txt");
            string[] TextArray = text.Split(new char[] { ' ' });

            List<string> text2 = new List<string>();
            for (int i = TextArray.Length - 1; i >= 0; i--)
            {
                text2.Add(TextArray[i]);
            }

            using (StreamWriter stream = new StreamWriter("Text3.txt", false, Encoding.Unicode))
            {
                foreach (string t in text2)
                {
                    stream.WriteLine(t);
                }
            }
            Console.WriteLine("Complete!");
        }

        public static void Task5()
        {

            using (StreamWriter stream = new StreamWriter("100000.txt", false, Encoding.Unicode))
            {
                for (int i = 1; i < 100001; i++)
                {
                    stream.WriteLine(i);
                }
            }

            int positiveCount = 0;
            int negativeCount = 0;
            int twoDigitCount = 0;
            int fiveDigitCount = 0;

            using (StreamReader reader = new StreamReader("100000.txt", Encoding.Unicode))
            using (StreamWriter posWriter = new StreamWriter("positive.txt", false, Encoding.Unicode))
            using (StreamWriter negWriter = new StreamWriter("negative.txt", false, Encoding.Unicode))
            using (StreamWriter twoWriter = new StreamWriter("two_digit.txt", false, Encoding.Unicode))
            using (StreamWriter fiveWriter = new StreamWriter("five_digit.txt", false, Encoding.Unicode))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        if (number > 0)
                        {
                            positiveCount++;
                            posWriter.WriteLine(number);
                        }
                        else if (number < 0)
                        {
                            negativeCount++;
                            negWriter.WriteLine(number);
                        }
                        if ((number >= 10 && number <= 99) || (number <= -10 && number >= -99))
                        {
                            twoDigitCount++;
                            twoWriter.WriteLine(number);
                        }
                        if ((number >= 10000 && number <= 99999) || (number <= -10000 && number >= -99999))
                        {
                            fiveDigitCount++;
                            fiveWriter.WriteLine(number);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
        }
    }
}