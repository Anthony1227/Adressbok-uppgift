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
                "\n Skriv ta bort om du vill ta bort en persons uppgifter " +
                "\n efter du tagit bort en person skriv in kommandot: spara");

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
                                          $" {person.Email} ");
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
                    Console.Write("Ange namnet på den du vill ta bort ur adressboken: ");
                    string name = Console.ReadLine();
                    bool removedName = false;
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (name == people[i].Name)
                        {
                            Console.WriteLine($"Tog bort personen med namnet {name} ur adressbooken!");
                            Console.WriteLine($"Hittade {name} på rad {i + 1}");
                            Console.WriteLine($"Skriv in kommandot 'spara' för att skicka din ändring till text filen");
                            people.RemoveAt(i);
                            removedName = true;
                        }
                    }
                    if (removedName == false)
                    {
                        Console.WriteLine($"Hittade ingen med namnet {name} i adressboken, har du stavat rätt?");
                    }
                }
                else if (command == "spara")
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        for (int i = 0; i < people.Count(); i++)
                        {
                            writer.WriteLine("{0},{1},{2},{3}",
                                            people[i].Name, people[i].Adress,
                                            people[i].Phone, people[i].Email);
                        }
                        Console.WriteLine("Adressboken är sparad!");
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
