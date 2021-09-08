
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp33
{
    [Serializable]
    public class Stud
    {
        public string Name;
        public string Group;

        public DateTime DateOfBirth;

        public Stud()
        {

        }

        public Stud(string name, string group, DateTime dateofbirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;

        }

    };

    class MM
    {
        static void Main(string[] args)
        {
            List<Stud> stds = new List<Stud>();

            Stud st1 = new Stud("Иванов", "Group1", DateTime.Now);
            stds.Add(st1);
            Stud st2 = new Stud("Григорьева", "Group1", DateTime.Now);
            stds.Add(st2);
            Stud st3 = new Stud("Степанов", "Group2", DateTime.Now);
            stds.Add(st3);

            Stud st4 = new Stud("Трофимов", "Group1", DateTime.Now);
            stds.Add(st4);
            Stud st5 = new Stud("Орлова", "Group2", DateTime.Now);
            stds.Add(st5);
            Stud st6 = new Stud("Тимофеев", "Group3", DateTime.Now);
            stds.Add(st6);
            Stud st7 = new Stud("Панфилов", "Group3", DateTime.Now);
            stds.Add(st7);

            Stud st8 = new Stud("Гречко", "Group1", DateTime.Now);
            stds.Add(st8);
            Stud st9 = new Stud("Томилина", "Group2", DateTime.Now);
            stds.Add(st9);
            Stud st10 = new Stud("Дмитриев", "Group3", DateTime.Now);
            stds.Add(st10);
            Stud st11 = new Stud("Иноккентьев", "Group1", DateTime.Now);
            stds.Add(st11);
            Stud st12 = new Stud("Кустикова", "Group2", DateTime.Now);
            stds.Add(st12);

            IEnumerable<string> grps = stds.Select(x => x.Group).Distinct();

            foreach (string g in grps)
            {
                // откр файл и писать
                IEnumerable<Stud> ss = stds.Where(x => x.Group == g);

                Console.WriteLine(g);

                foreach (Stud s in ss)
                {
                    Console.WriteLine(" {0} {1} {2}", s.Name, s.Group, s.DateOfBirth.ToString());
                }

                Console.WriteLine(Environment.NewLine);

            }

            using (Stream fs = File.Open(@"d:\fs.bin", FileMode.Create))
            {
                BinaryFormatter fmt = new BinaryFormatter();

                try
                {
                    fmt.Serialize(fs, stds);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }

            using (FileStream fs1 = new FileStream(@"d:\fs.bin", FileMode.Open))
            {
                BinaryFormatter fmt = new BinaryFormatter();
                List<Stud> stds1 = (List<Stud>)fmt.Deserialize(fs1);

                IEnumerable<string> grps1 = stds1.Select(x => x.Group).Distinct();

                foreach (string g in grps1)
                {


                    IEnumerable<Stud> ss1 = stds1.Where(x => x.Group == g);

                    Console.WriteLine(g);

                    foreach (Stud s in ss1)
                    {
                        Console.WriteLine(" {0} {1} {2}", s.Name, s.Group, s.DateOfBirth.ToString());
                    }

                    Console.WriteLine(Environment.NewLine);

                }
            }

            Console.Read();
        }
    }
}
