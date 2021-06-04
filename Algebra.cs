using System;

namespace _31
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }


        static void Main(string[] args)////// method main
        {
            double score = 0;
            Difficulty level = 0;
            string mainmenu;
            bool theloop = false;
            int con;

            while (theloop == false)
            {
                Console.Write("TIMER:");
                Console.WriteLine(DateTimeOffset.Now.ToUnixTimeSeconds());
                Console.WriteLine();
                Console.WriteLine("*** ALGEBRA PUZZLE ***");
                Console.WriteLine();
                Console.Write("Press 1 To Start the game ------> : ");
                con = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (con == 1)
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("Press 0 : Start the game ");
                    Console.WriteLine("Press 1 : Setting");
                    Console.WriteLine("Press 2 : Exit the program");
                    Console.WriteLine();
                    Console.WriteLine("Your score ---> {0} // Difficulty ---> {1}", score, level);
                    Console.WriteLine();
                    Console.Write("What do you choose in Menu -----> :");
                    

                }
                else
                {
                    Console.WriteLine("Please Press the 1 Button !!!!!");
                }


                mainmenu = Console.ReadLine();
                switch (mainmenu)
                {
                    case "0":
                        score = thegameplay(level);
                        Console.WriteLine("Score ---> {0} // Difficulty ---> {1}", score, level);
                        break;
                    case "1":
                        level = setting();
                        Console.WriteLine("Score ---> {0} // Difficulty ---> {1}", score, level);
                        break;
                    case "2":
                        theloop = true;
                        long start = DateTimeOffset.Now.ToUnixTimeSeconds();
                        bool stop = false;
                        Console.Write("The game will exit in...");
                        while (true)
                        {
                            long end = DateTimeOffset.Now.ToUnixTimeSeconds();
                            long wait = end - start;
                            if (wait == 1 && stop == false)
                            {
                                Console.Write(" 3 "); stop = true;
                            }
                            if (wait == 2 && stop == true)
                            {
                                Console.Write(" 2 "); stop = false;
                            }
                            if (wait == 3 && stop == false)
                            {
                                Console.Write(" 1 "); stop = true; break;
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("********** Exit the game Goodbye *********");
                        break;
                    default:
                        Console.WriteLine("Plase input only 0-2 !!!");
                        break;

                }
                Console.WriteLine("//////////////////////////////////////////");
            }

            ////////////////////////////////////////////// Setting /////////////////////////////////////////////////////
            static Difficulty setting()
            {
                Difficulty levels = Difficulty.Easy | Difficulty.Hard | Difficulty.Normal;
                int level;
                Console.WriteLine("Plase choose the level");
                Console.WriteLine("0=Easy");
                Console.WriteLine("1=Normal");
                Console.WriteLine("2=Hard");
                Console.Write("-------> : ");
                level = int.Parse(Console.ReadLine());

                switch (level)
                {
                    case 0:
                        levels = Difficulty.Easy;
                        break;
                    case 1:
                        levels = Difficulty.Normal;
                        break;
                    case 2:
                        levels = Difficulty.Hard;
                        break;

                }
                return levels;

            }


        }

        ///The game play method ////

        static double thegameplay(Difficulty level)
        {
            int NumberofQuestion;
            NumberofQuestion = 0;
            Problem[] randomProblems = GenerateRandomProblems(0);

            switch ((int)level)
            {
                case 0:
                    NumberofQuestion = 3;
                    break;
                case 1:
                    NumberofQuestion = 5;
                    break;
                case 2:
                    NumberofQuestion = 7;
                    break;
                default:
                    break;

            }
            randomProblems = GenerateRandomProblems(NumberofQuestion);

            double Timer, Finisher;
            int inputAnswer, CorrectAns;
            CorrectAns = 0;
            Timer = DateTimeOffset.Now.ToUnixTimeSeconds();

            for (int i = 0; i < NumberofQuestion; i++)
            {
                Console.Write(randomProblems[i].Message);
                //Console.Write(randomProblems[i].Answer);//เช็คค
                inputAnswer = int.Parse(Console.ReadLine());
                if (inputAnswer == randomProblems[i].Answer)
                {
                    CorrectAns += 1;
                }


            }
            Finisher = DateTimeOffset.Now.ToUnixTimeSeconds();

            double Qc, Qa, DeltaT, d, s, T1, T2;
            Qc = CorrectAns;
            Qa = NumberofQuestion;
            T1 = Timer;
            T2 = Finisher;
            DeltaT = T2 - T1;
            d = (int)level;


            s = (Qc / Qa) * (25 - Math.Pow(d, 2)) / Math.Max(DeltaT, 25 - (Math.Pow(d, 2)) * Math.Pow((2 * d) + 1, 2));

            return s;




        }

        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;

        }
    }
}
