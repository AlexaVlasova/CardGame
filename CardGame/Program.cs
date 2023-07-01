using System;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardGame.StartGame();
            MyQueue<string> queue = new MyQueue<string>();
            queue.Enqueue("k");
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            queue.Print();
            Console.WriteLine();

            queue.Peek();
            Console.WriteLine();
            Console.WriteLine(queue.IsEmplty());

            Console.WriteLine();
            queue.Dequeue();
            queue.Print();

            Console.WriteLine();
            queue.Peek();

            Console.WriteLine();
            queue.Clear();
            queue.Print();

            Console.WriteLine();
            queue.Peek();
            Console.WriteLine(queue.IsEmplty());
        }
    }

    public class CardGame
    {
        public static int[] Deck = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static List<int> firstHalf = new List<int>(5);
        public static List<int> secondHalf = new List<int>(5);

        public static void StartGame()
        {
            Snuffle(Deck, ref firstHalf, ref secondHalf);
            Queue<int> firstPlayer = new Queue<int>();
            Queue<int> secondPlayer = new Queue<int>();

            Console.WriteLine("Колода игрока 1:");
            FillDeck(ref firstHalf, ref firstPlayer);
            Console.WriteLine("\n");
            Console.WriteLine("Колода игрока 2:");
            FillDeck(ref secondHalf, ref secondPlayer);
            Console.WriteLine("\n");
            CompareTwoCard(ref firstPlayer, ref secondPlayer);

        }
        public static void Snuffle(int[] deck, ref List<int> firstHalf, ref List<int> secondHalf)
        {
            Random random = new Random();
            for (int i = deck.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                int tmp = deck[j];
                deck[j] = deck[i];
                deck[i] = tmp;
            }

            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                {
                    firstHalf.Add(deck[i]);
                }
                else if (i >= 5)
                {
                    secondHalf.Add(deck[i]);
                }

            }

        }

        public static void FillDeck(ref List<int> deck, ref Queue<int> deckToFill)
        {
            for (int i = 0; i < 5; i++)
            {
                deckToFill.Enqueue(deck[i]);
            }

            foreach (int s in deckToFill)
            {
                Console.Write(s + "\t");
            }
        }

        public static void PrintDeck(Queue<int> Deck,int i) 
        {
            Console.WriteLine($"Колода игрока {i}:");
            foreach (int s in Deck)
            {
                Console.Write(s + "\t");
            }
            Console.WriteLine("\n");
        }

        public static void CompareTwoCard(ref Queue<int> first, ref Queue<int> second)
        {
            int count = 0;
            while (first.Count != 0 && second.Count != 0)
            {
                if (first.Peek() == 0 && second.Peek() == 9)
                {
                    Console.WriteLine($"Игрок 1 берет помещает обе карты в свою колоду: {first.Peek()}  {second.Peek()} \n\n");
                    first.Enqueue(first.Dequeue());
                    first.Enqueue(second.Dequeue());
                    PrintDeck(first, 1);
                    PrintDeck(second, 2);
                    count++;

                }
                else if (second.Peek() == 0 && first.Peek() == 9)
                {
                    Console.WriteLine($"Игрок 2 берет помещает обе карты в свою колоду: {second.Peek()}  {first.Peek()} \n\n");
                    second.Enqueue(second.Dequeue());
                    second.Enqueue(first.Dequeue());
                    PrintDeck(first, 1);
                    PrintDeck(second, 2);
                    count++;

                }
                else
                {
                    if (first.Peek() > second.Peek())
                    {
                        Console.WriteLine($"Игрок 1 берет помещает обе карты в свою колоду: {first.Peek()}  {second.Peek()}\n\n");
                        first.Enqueue(first.Dequeue());
                        first.Enqueue(second.Dequeue());
                        PrintDeck(first, 1);
                        PrintDeck(second, 2);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Игрок 2 берет помещает обе карты в свою колоду: {second.Peek()}  {first.Peek()}\n\n");
                        second.Enqueue(second.Dequeue());
                        second.Enqueue(first.Dequeue());
                        PrintDeck(first, 1);
                        PrintDeck(second, 2);
                        count++;


                    }
                }
                Console.WriteLine("****************************************************************************************");

            }
            if (first.Count == 0)
            {
                Console.WriteLine("Игрок 2 победил");
                Console.WriteLine($"Количество ходов: {count}");
            }
            else if (second.Count == 0)
            {
                Console.WriteLine("Игрок 1 победил");
                Console.WriteLine($"Количество ходов: {count}");
            }

        }

    }
}
