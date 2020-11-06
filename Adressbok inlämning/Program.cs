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
            string command;
            List<Person> people = new List<Person>();

            List<string> lines = File.ReadAllLines(filePath).ToList();
            Console.WriteLine("Välkommen till adressboken." +
                "\n Skriv visa om du vill se dess innehåll." +
                "\n Skriv ny om du vill lägga till någons Namn,Adress,Telefonnummer och Email." +
                "\n Skriv ta bort om du vill ta bort en persons uppgifter ");

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

            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "visa")
                {
                    Console.WriteLine("Läst från fil");
                    foreach (var person in people)
                    {
                        Console.WriteLine($"{person.Name}\n" +
                                          $"{person.Adress}\n" +
                                          $"{person.Phone}\n" +
                                          $"{person.Email} ");
                    }
                }
                else if (command == "ny")
                {
                    people.Add(new Person { Name = Console.ReadLine(), Adress = Console.ReadLine(), Phone = Console.ReadLine(), Email = Console.ReadLine() });

                    List<string> output = new List<string>();

                    foreach (var person in people)
                    {
                        output.Add($"{ person.Name }, { person.Adress }, { person.Phone },{ person.Email } ");
                    }

                    Console.WriteLine("Skriver till fil");

                    File.WriteAllLines(filePath, output);

                    Console.WriteLine("Alla poster inskrivna");
                }
                else if (command == "ta bort")
                {
                    Console.WriteLine("Skriv in index av personen du vill ta bort");
                    string index = Console.ReadLine();
                    try
                    {
                            people.RemoveAt(Int32.Parse(index));
                            lines.RemoveAt(Int32.Parse(index));
                    }
                    catch
                    {
                        Console.WriteLine("Fel index");
                    }

                }
            } while (command != "sluta");
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
