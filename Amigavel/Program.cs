using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Amigavel
{
    class Program
    {
        static void Main(string[] args)
        {
            byte c = 100, a = 24, golo = 0, goloAdv = 0, x = 0, y = 0, rng = 0, equipa = 0;
            char asterisco = '*', jogador = 'O';
            ConsoleKeyInfo consoleKeyInfo;
            string clube, adversario;
            bool letra = true;
            Random rnd = new Random();

            do
            {
                Console.Clear();
                Console.Write("Insira o nome do seu clube: ");
                clube = Console.ReadLine().ToUpper();

                for (int i = 0; i < clube.Length; i++)
                {
                    letra = char.IsLetter(clube[i]);
                }

            } while (!(letra == true && !(string.IsNullOrEmpty(clube))));

            do
            {
                Console.Clear();
                Console.Write("Insira o nome do seu adversário: ");
                adversario = Console.ReadLine().ToUpper();

                for (int i = 0; i < adversario.Length; i++)
                {
                    letra = char.IsLetter(adversario[i]);
                }

            } while (!(letra == true && adversario != clube && !(string.IsNullOrEmpty(adversario))));

            Console.Clear();

            do
            {
                Console.Clear();
                Console.WriteLine("Formação 4-3-3 -> Pressione 1");
                Console.WriteLine();
                Console.Write("Insira qual a formação que deseja: ");

            } while (!(byte.TryParse(Console.ReadLine(), out equipa) && equipa == 1));

            Console.Clear();

            switch (equipa)
            {
                case 1:

                    Console.WriteLine();

                    for (int i = 0; i <= a; i++)
                    {
                        if (i == 0 || i == a)
                        {
                            for (int j = 0; j <= c; j++)
                            {
                                Console.Write(asterisco);
                            }
                        }
                        else
                        {
                            for (int j = 0; j <= c; j++)
                            {
                                if (j == 0 || j == c || j == 50 || /*pequena area*/((j <= 4 || j >= 96) && (i == 8 || i == 16)) || ((j == 4 || j == 96) && (i >= 8 && i <= 16)) || /*grande area*/((j <= 12 || j >= 88) && (i == 5 || i == 19)) || ((j == 12 || j == 88) && (i >= 5 && i <= 19)) || /*meio campo*/((i == 9 || i == 15) && (j >= 48 && j <= 52)) || ((i == 14 || i == 10) && (j == 46 || j == 54)) || ((i >= 11 && i <= 13) && (j == 44 || j == 56)) || /*entrada area*/((i == 10 || i == 14) && (j == 14 || j == 86)) || ((i >= 11 && i <= 13) && (j == 16 || j == 84)))
                                {
                                    Console.Write(asterisco);
                                }
                                else if (/*formação 4-3-3 */((i == 12) && (j == 1 || j == 35 || j == 80)) || ((i == 2 || i == 22) && (j == 20)) || ((i == 7 || i == 17) && (j == 15)) || ((i == 3 || i == 21) && (j == 70)) || ((i == 7) && (j == 45)) || ((i == 17) && (j == 45)))
                                {
                                    Console.Write(jogador);
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                        }
                        Console.WriteLine("");
                    }

                    do
                    {
                        if (golo == 0)
                        {
                            Console.WriteLine($"{clube}: {golo}                                                                           {adversario}: {goloAdv}");
                        }

                        Console.SetCursorPosition(2, 13);
                        x = 2;
                        y = 13;

                        do
                        {
                            //GR
                            while (x == 2 && y == 13)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    rng = Convert.ToByte(rnd.Next(0, 2));

                                    if (rng == 0)
                                    {
                                        Console.SetCursorPosition(16, 8);
                                        x = 16;
                                        y = 8;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(16, 18);
                                        x = 16;
                                        y = 18;
                                    }
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(2, 13);
                                    x = 2;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(2, 13);
                                    x = 2;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(2, 13);
                                    x = 2;
                                    y = 13;
                                }
                            }

                            //DCE
                            while (x == 16 && y == 8)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(36, 13);
                                    x = 36;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(2, 13);
                                    x = 2;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(16, 18);
                                    x = 16;
                                    y = 18;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(21, 3);
                                    x = 21;
                                    y = 3;
                                }
                            }

                            //DCD
                            while (x == 16 && y == 18)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(36, 13);
                                    x = 36;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(2, 13);
                                    x = 2;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(21, 23);
                                    x = 21;
                                    y = 23;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(16, 8);
                                    x = 16;
                                    y = 8;
                                }
                            }

                            //DE
                            while (x == 21 && y == 3)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(46, 8);
                                    x = 46;
                                    y = 8;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(21, 3);
                                    x = 21;
                                    y = 3;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(16, 8);
                                    x = 16;
                                    y = 8;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(21, 3);
                                    x = 21;
                                    y = 3;
                                }
                            }

                            //DD
                            while (x == 21 && y == 23)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(46, 18);
                                    x = 46;
                                    y = 18;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(21, 23);
                                    x = 21;
                                    y = 23;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(21, 23);
                                    x = 21;
                                    y = 23;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(16, 18);
                                    x = 16;
                                    y = 18;
                                }
                            }

                            //MC
                            while (x == 36 && y == 13)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    rng = Convert.ToByte(rnd.Next(0, 2));

                                    if (rng == 0)
                                    {
                                        Console.SetCursorPosition(46, 8);
                                        x = 46;
                                        y = 8;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(46, 18);
                                        x = 46;
                                        y = 18;
                                    }
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    rng = Convert.ToByte(rnd.Next(0, 2));

                                    if (rng == 0)
                                    {
                                        Console.SetCursorPosition(16, 8);
                                        x = 16;
                                        y = 8;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(16, 18);
                                        x = 16;
                                        y = 18;
                                    }
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(36, 13);
                                    x = 36;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(36, 13);
                                    x = 36;
                                    y = 13;
                                }
                            }

                            //ME
                            while (x == 46 && y == 8)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(71, 4);
                                    x = 71;
                                    y = 4;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(36, 13);
                                    x = 36;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(46, 18);
                                    x = 46;
                                    y = 18;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(46, 8);
                                    x = 46;
                                    y = 8;
                                }
                            }

                            //MD
                            while (x == 46 && y == 18)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(71, 22);
                                    x = 71;
                                    y = 22;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(36, 13);
                                    x = 36;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(46, 18);
                                    x = 46;
                                    y = 18;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(46, 8);
                                    x = 46;
                                    y = 8;
                                }
                            }

                            //AE
                            while (x == 71 && y == 4)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(81, 13);
                                    x = 81;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(46, 8);
                                    x = 46;
                                    y = 8;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(71, 22);
                                    x = 71;
                                    y = 22;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(71, 4);
                                    x = 71;
                                    y = 4;
                                }
                            }

                            //AD
                            while (x == 71 && y == 22)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(81, 13);
                                    x = 81;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    Console.SetCursorPosition(46, 18);
                                    x = 46;
                                    y = 18;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(71, 22);
                                    x = 71;
                                    y = 22;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(71, 4);
                                    x = 71;
                                    y = 4;
                                }
                            }

                            //PL
                            while (x == 81 && y == 13)
                            {
                                consoleKeyInfo = Console.ReadKey(true);

                                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    Console.SetCursorPosition(98, 13);
                                    x = 98;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    rng = Convert.ToByte(rnd.Next(0, 2));

                                    if (rng == 0)
                                    {
                                        Console.SetCursorPosition(71, 4);
                                        x = 71;
                                        y = 4;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(71, 22);
                                        x = 71;
                                        y = 22;
                                    }
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                                {
                                    Console.SetCursorPosition(81, 13);
                                    x = 81;
                                    y = 13;
                                }
                                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    Console.SetCursorPosition(81, 13);
                                    x = 81;
                                    y = 13;
                                }
                            }

                            if (x == 98 && y == 13)
                            {
                                Console.ReadKey(true);
                            }

                        } while (x != 98 || y != 13);

                        if (golo < 3)
                        {
                            Console.SetCursorPosition(0, 26);
                            golo++;
                            Console.WriteLine($"{clube}: {golo}");
                        }

                    } while (golo < 3);

                    Console.SetCursorPosition(2, 13);

                    break;
            }

            Console.ReadKey();
        }
    }
}
