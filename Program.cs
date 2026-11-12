using System;
using System.IO;
namespace file
{
    struct president
    {
        public string ime;
        public double uspeh;
    }

    class Program
    {
        private const string name = "test2.dat";
        static void Main()
        {
            if (File.Exists(name))
            {
                Console.WriteLine("The file {0} already exists!", name);

                FileStream ms = new FileStream(name, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(ms);

                for(int i = 0; i < 3; i++)
                {
                    Console.WriteLine(r.ReadString());
                    Console.WriteLine(r.ReadDouble());
                }
                r.Close();
                ms.Close();
                Console.ReadKey();
                return;
            }
            else
            {
                president p;
                FileStream fs = new FileStream(name, FileMode.CreateNew);
                BinaryWriter w = new BinaryWriter(fs);

                for(int i = 0; i< 3; i++)
                {
                    Console.WriteLine("VAVEDI IME:");
                    p.ime = Console.ReadLine();
                    Console.WriteLine("VAVEDI USPEH:");
                    p.uspeh = Double.Parse(Console.ReadLine());
                    w.Write(p.ime);
                    w.Write(p.uspeh);
                }

                w.Close();
                fs.Close();
            }
            Console.ReadKey();
        }
    }
}

