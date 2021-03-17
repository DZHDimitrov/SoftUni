using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Piece
    {
        public string PieceName { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public Piece(string piece, string composer, string key)
        {
            PieceName = piece;
            Composer = composer;
            Key = key;
        }

        public override string ToString()
        {
            return $"{PieceName} -> Composer: {Composer}, Key: {Key}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int pieces = int.Parse(Console.ReadLine());
            List<Piece> allPieces = new List<Piece>();

            for (int i = 0; i < pieces; i++)
            {
                string[] array = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string pieceName = array[0];
                string composer = array[1];
                string key = array[2];

                Piece piece = new Piece(pieceName, composer, key);
                allPieces.Add(piece);
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] array = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = array[0];
                string pieceName = array[1];
                switch (command)
                {
                    case "Add":

                        string composer = array[2];
                        string key = array[3];

                        Piece piece = new Piece(pieceName, composer, key);
                        if (!allPieces.Exists(x => x.PieceName == pieceName))
                        {
                            allPieces.Add(piece);
                            Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{pieceName} is already in the collection!");
                        }
                        break;

                    case "Remove":

                        if (allPieces.Exists(x => x.PieceName == pieceName))
                        {
                            int index = allPieces.FindIndex(x => x.PieceName == pieceName);
                            allPieces.RemoveAt(index);
                            Console.WriteLine($"Successfully removed {pieceName}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":

                        key = array[2];

                        if (allPieces.Exists(x => x.PieceName == pieceName))
                        {
                            foreach (var item in allPieces.Where(x => x.PieceName == pieceName))
                            {
                                item.Key = key;
                                break;
                            }
                            Console.WriteLine($"Changed the key of {pieceName} to {key}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            foreach (var item in allPieces.OrderBy(x => x.PieceName).ThenBy(x => x.Composer))
            {
                Console.WriteLine(item);
            }
        }
    }
}
