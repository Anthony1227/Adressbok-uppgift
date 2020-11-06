﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adressbok_inlämning
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Anthony\Adressfil.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            lines.Add(Console.ReadLine());

            File.WriteAllLines(filePath, lines);

            Console.ReadLine();
        }
    }

    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
