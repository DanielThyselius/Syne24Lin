using System.Xml.Linq;

namespace OopDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
   
            var person = new Person("John", 12);
            var student = new Student("Jane", 22);
            var robot = new Robot("R2D2");

            var list = new List<IGreeter>();
            list.Add(person);
            list.Add(student);
            list.Add(robot);

            foreach (var item in list)
            {
                // Todo (bonusövning):
                // Prefix the greeting with Name if the item is a Person
                // Or with Id if the item is a Robot

                Console.WriteLine(item.GetGreeting());
                
            }
        }
    }
    public interface IGreeter
    {
        public string GetGreeting();
    }

    internal class Robot :IGreeter
    {
        public string Id;

        public Robot(string id)
        {
            Id = id;
        }

        public string GetGreeting()
        {
            return "Beep Boop";
        }

        public override string ToString()
        {
            return $"Id: {Id} ";
        }
    }

    internal class Person : IGreeter
    {
        public string Name { get; set;} 
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        virtual public string GetGreeting()
        {
            return "Hello";
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    internal class Student : Person
    {
        public string School { get; set; } = "default";

        public Student(string name, int age) : base(name, age)
        {
        }

        public string Study()
        {
            return "Studying...";
        }

        override public string GetGreeting()
        {
            return "Zup?";
        }
    }

}
