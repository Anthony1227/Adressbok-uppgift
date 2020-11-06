using System;
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

            List<Person> people = new List<Person>();

            List<string> lines = File.ReadAllLines(filePath).ToList();

            try
            {
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');

                    Person newPerson = new Person();

                    newPerson.Name = entries[0];
                    newPerson.Adress = entries[1];
                    newPerson.Phone = entries[2];
                    newPerson.Email = entries[3];



                    people.Add(newPerson);
                }
            }
            catch { }

            Console.WriteLine("Läst från fil");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}\n" +
                                  $"{person.Adress}\n" +
                                  $"{person.Phone}\n" +
                                  $"{person.Email} ");
            }

            people.Add(new Person { Name = Console.ReadLine(), Adress = Console.ReadLine(), Phone = Console.ReadLine(), Email = Console.ReadLine() });

            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add($"{ person.Name }, { person.Adress }, { person.Phone },{ person.Email } ");
            }

            Console.WriteLine("Skriver till fil");

            File.WriteAllLines(filePath, output);

            Console.WriteLine("Alla poster inskrivna");

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
