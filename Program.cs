using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace beagyki2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person p = new Person
            {
                Age = 13,
                Name = "Hello"
            };
            /*
            // p.AgeChanging = new AgeChangingDelegate(personAgeChanging);
            // 5
            p.AgeChanging += personAgeChanging;
            //p.AgeChanging += personAgeChanging;
            //p.AgeChanging += personAgeChanging;
            //p.AgeChanging -= personAgeChanging;
            ++p.Age;
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Age);
            Console.WriteLine(p.SzuletesiEv);
            XmlSerializer ser = new XmlSerializer(typeof(Person));
            var file = new FileStream("person.txt", FileMode.Create);
            ser.Serialize(file, p);
            file.Close();
            System.Diagnostics.Process.Start("person.txt");
            */
            List<Person> people = new List<Person>();
            people.Add(p);
            people.Add(new Person() { Name = "AAA", Age = 43 });
            foreach(Person e in people.FindAll(personFilter => personFilter.Age%2!=0))
            {
                Console.WriteLine(e.Name);
            }
            Console.ReadKey();
        }
        // 4 
        static void personAgeChanging(int oldAge, int newAge)
        {
            Console.WriteLine($"Person age {oldAge} -> {newAge} ");
        }
        delegate bool personFilter(Person person);
    }

}
