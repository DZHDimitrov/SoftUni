using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < number; i++)
            {
                string[] data = Console.ReadLine().Split("_");
                string typelist = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();
                song.TypeList = typelist;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }
            string input = Console.ReadLine();

            if (input != "all")
            {
                foreach (Song item in songs)
                {
                    if (item.TypeList == input)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
            else
            {
                foreach (Song item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}

