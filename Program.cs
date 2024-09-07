namespace MatrixEffect {
    internal class Program {

        private static Random rand = new Random();

        private static char AsciiCharacter {
            get {
                int t = rand.Next(10);
                if (t <= 2)
                    return (char)('0' + rand.Next(10));
                else if (t <= 4)
                    return (char)('a' + rand.Next(27));
                else if (t <= 6)
                    return (char)('A' + rand.Next(27));
                else
                    return (char)(rand.Next(32, 255));
            }
        }

        public static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;

            int width, height;
            int[] y;

            Init(out width, out height, out y);

            while (true) {
                Update(width, height, y);
            }
        }

        private static void Update(int width, int height, int[] y) {
            int x;
            for (x = 0; x < width; ++x) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(AsciiCharacter);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, InScreen(temp, height));
                Console.Write(AsciiCharacter);
                
                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, InScreen(temp1, height));
                Console.Write(' ');

                y[x] = InScreen(y[x] + 1, height);
            }

            if (Console.KeyAvailable) {
                if (Console.ReadKey().Key == ConsoleKey.F5) { Init(out width, out height, out y); }
                if (Console.ReadKey().Key == ConsoleKey.F11) { System.Threading.Thread.Sleep(1); }
            }

        }

        public static int InScreen(int yPosition, int height) {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }

        private static void Init(out int width, out int height, out int[] y) {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];

            Console.Clear();
            for (int x = 0; x < width; ++x) { y[x] = rand.Next(height); }
        }
    }
}
