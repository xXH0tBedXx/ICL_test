using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace tasks_cs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Первое задание
            String[] names = { "utf-16", "utf-8", "windows-1251", "cp866(dos)", "koi8-r" };
            String[] strings = { "съешь же ещё этих мягких французских булок, да выпей чаю", "The quick brown fox jumps over the lazy dog", "1234567890!@#$%ˆ&*()" };
            File.WriteAllLines(names[0], strings, Encoding.Unicode);
            Console.WriteLine("in " + names[0] + " recorded: \n" + File.ReadAllText(names[0], Encoding.Unicode));
            Console.WriteLine(names[0] + " Done\n_____________________________________________________________");
            File.WriteAllLines(names[1], strings, Encoding.UTF8);
            Console.WriteLine("in " + names[1] + " recorded: \n" + File.ReadAllText(names[1], Encoding.UTF8));
            Console.WriteLine(names[1] + " Done\n_____________________________________________________________");
            File.WriteAllLines(names[2], strings, Encoding.GetEncoding(1251));
            Console.WriteLine("in " + names[2] + " recorded: \n" + File.ReadAllText(names[2], Encoding.GetEncoding(1251)));
            Console.WriteLine(names[2] + " Done\n_____________________________________________________________");
            File.WriteAllLines(names[3], strings, Encoding.GetEncoding(866));
            Console.WriteLine("in " + names[3] + " recorded: \n" + File.ReadAllText(names[3], Encoding.GetEncoding(866)));
            Console.WriteLine(names[3] + " Done\n_____________________________________________________________");
            File.WriteAllLines(names[4], strings, Encoding.GetEncoding(20866));
            Console.WriteLine("in " + names[4] + " recorded: \n" + File.ReadAllText(names[4], Encoding.GetEncoding(20866)));
            Console.WriteLine(names[4] + " Done\n_____________________________________________________________");

            deleteLastFiveStrings(); // Вызов второго задания

            //Третье задание
            Console.Write("Enter a path to folder, then I show list of all folders and subdirectories in console: ");
            String path = Console.ReadLine();
            foreach (String file in ReceiveDirectoryInfo(path))
            {
                Console.WriteLine(file);
            }

            //Четвертое задание
            Console.Write("choose Persons(1), Teachers(2) or Students(3): ");
            char sign = Console.ReadKey().KeyChar;
            switch (sign)
            {
                case '1':
                    Person[] person = new Person[10];
                    for (int i = 0; i < 10; i++)
                    {
                        person[i] = new Person(i);
                        Console.WriteLine(person[i].ToString());
                    }
                    break;
                case '2':
                    Teacher[] teacher = new Teacher[10];
                    for (int i = 0; i < 10; i++)
                    {
                        teacher[i] = new Teacher(i);
                        Console.WriteLine(teacher[i].ToString());
                    }
                    break;
                case '3':
                    Student[] student = new Student[10];
                    for (int i = 0; i < 10; i++)
                    {
                        student[i] = new Student(i);
                        Console.WriteLine(student[i].ToString());
                    }
                    break;
                default:
                    Console.WriteLine("Wrong answer");
                    break;
                  
            }
        }

        public static void deleteLastFiveStrings() // Реализация второго задания
        {
            Console.Write("Enter a path to file, then I delete last 5 strings in console: ");
            String path = Console.ReadLine();
            String[] text = File.ReadAllLines(path);
            Array.Clear(text, text.Length - 5, 5);
            File.WriteAllLines(path, text);
            Console.WriteLine("Done");
        }

        public static List<String> ReceiveDirectoryInfo(String path) //Реализация третьего задания
        {

            List<string> ls = new List<string>();
            try
            {
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {
                    ls.Add("folder: " + folder);
                    ls.AddRange(ReceiveDirectoryInfo(folder));
                }
                string[] files = Directory.GetFiles(path);
                foreach (string filename in files)
                {
                    ls.Add("file: " + filename);
                }
            }
            catch (exepyion e) // реализация try-catch со своим исключением
            {
                e.showmessage();
            }
            return ls;
        }
    }

    // Собственный класс исключений :)
    class exepyion : Exception
    {
        public void showmessage()
        {
            Console.WriteLine("Что-то пошло не так!!\nкод ошибки: " + this.Message);
        }
    }

    //реализация классов person-teacher-student
    class Person
    {
        private int id;
        public Person()
        {}
        public Person(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }
        override public String ToString()
        {
            return ("ID: " + id);
        }
        public virtual void Print()
        {
            Console.WriteLine("I am Person [-_-]");
        }
    }

    class Teacher : Person
    {
        private int id;
        public Teacher()
        { }
        public Teacher(int id)
        {
            this.id = id;
        }
        public override void Print()
        {
            Console.WriteLine("I am teacher (* - *)");
        }
    }

    class Student : Teacher
    {
        private int id;
        public Student(int id)
        {
            this.id = id;
        }
        public override void Print()
        {
            Console.WriteLine("I am Student (-_-)");
        }
    }
}
