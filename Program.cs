using System;
using System.Xml.Serialization;

namespace Lesson006
{
    public class Program
    {
        static void ClearConsole()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static void FillMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if ((x == 0 || x == map.GetLength(0) - 1) && (y == 0 || y == map.GetLength(1) - 1))
                    {
                        map[x, y] = '*';
                    }
                    else if (y == 0 || y == map.GetLength(1) - 1)
                    {
                        map[x, y] = '-';
                    }
                    else if (x == 0 || x == map.GetLength(0) - 1)
                    {
                        map[x, y] = '|';
                    }
                    else
                    {
                        map[x, y] = '.';
                    }
                }
            }
        }

        static void FillConsole(char[,] map, int playerXIndex, int playerYIndex, int stoneXIndex, int stoneYIndex)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (x == playerXIndex && y == playerYIndex)
                    {
                        Console.Write("X");
                    }
                    else if (x == stoneXIndex && y == stoneYIndex)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(map[x, y]);
                    }
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            char[,] map = new char[100, 15];
            int playerXIndex = 10;
            int playerYIndex = 5;
            int stoneXIndex = 6;
            int stoneYIndex = 4;

            FillMap(map);

            ClearConsole();

            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    FillConsole(map, playerXIndex, playerYIndex, stoneXIndex, stoneYIndex);
                    System.Threading.Thread.Sleep(10);
                }
            }).Start();

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    playerYIndex--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    playerYIndex++;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    playerXIndex--;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    playerXIndex++;
                }

                playerYIndex = Math.Min(map.GetLength(1) - 2, Math.Max(1, playerYIndex));
                playerXIndex = Math.Min(map.GetLength(0) - 2, Math.Max(1, playerXIndex));

                new Thread(() =>
                {
                    int startX = playerXIndex;
                    int startY = playerYIndex;
                    for (int i = 0; i < 5; i++)
                    {
                        int slash1X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX - i - 1));
                        int slash1Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY - i - 1));

                        int slash2X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX - i - 1));
                        int slash2Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY + i + 1));

                        int slash3X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX + i + 1));
                        int slash3Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY + i + 1));

                        int slash4X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX + i + 1));
                        int slash4Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY - i - 1));

                        int slash5X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX + i + 1));
                        int slash5Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY));

                        int slash6X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX - i - 1));
                        int slash6Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY));

                        int slash7X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX));
                        int slash7Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY - i - 1));

                        int slash8X = Math.Min(map.GetLength(0) - 2, Math.Max(1, startX));
                        int slash8Y = Math.Min(map.GetLength(1) - 2, Math.Max(1, startY + i + 1));

                        map[slash1X, slash1Y] = '\\';
                        map[slash2X, slash2Y] = '/';
                        map[slash3X, slash3Y] = '\\';
                        map[slash4X, slash4Y] = '/';
                        map[slash5X, slash5Y] = ')';
                        map[slash6X, slash6Y] = '(';
                        map[slash7X, slash7Y] = '^';
                        map[slash8X, slash8Y] = 'v';
                        System.Threading.Thread.Sleep(100);
                        map[slash1X, slash1Y] = '.';
                        map[slash2X, slash2Y] = '.';
                        map[slash3X, slash3Y] = '.';
                        map[slash4X, slash4Y] = '.';
                        map[slash5X, slash5Y] = '.';
                        map[slash6X, slash6Y] = '.';
                        map[slash7X, slash7Y] = '.';
                        map[slash8X, slash8Y] = '.';
                    }
                }).Start();
            }
        }
    }
}