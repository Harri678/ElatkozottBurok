using System;
using System.Collections.Generic;

namespace ElatkozottBurok
{
    class Program
    {
        static void Main(string[] args)
        {
            Nassolnivalo kave = new Nassolnivalo("Kave", 30, 10, 500);
            Nassolnivalo energiaital = new Nassolnivalo("Energiaital", 40, 15, 700);
            Nassolnivalo csoki = new Nassolnivalo("Csoki", 10, 20, 300);

            List<Nassolnivalo> keszlet = new List<Nassolnivalo>();
            keszlet.Add(kave);
            keszlet.Add(energiaital);
            keszlet.Add(csoki);

            Automata automata = new Automata(0, keszlet, false);

            Fejleszto Bela = new Fejleszto("Bela", Munkakor.Junior, 5000, 80, 30, false, "Kave");
            Fejleszto Anna = new Fejleszto("Anna", Munkakor.Senior, 5000, 15, 40, false, "Energiaital");
            Fejleszto Peter = new Fejleszto("Peter", Munkakor.DevOpsVarazslo, 5000, 70, 80, false, "Csoki");
            Fejleszto Zoli = new Fejleszto("Zoli", Munkakor.Junior, 200, 20, 60, false, "Kave");

            List<Fejleszto> fejlesztok = new List<Fejleszto>();
            fejlesztok.Add(Bela);
            fejlesztok.Add(Anna);
            fejlesztok.Add(Peter);
            fejlesztok.Add(Zoli);

            Iroda iroda = new Iroda(fejlesztok, automata);

            Console.WriteLine("MUNKANAP SZIMULACIO\n");
            iroda.MunkanapSzimulacio(8);

            Console.WriteLine("\nNAPI JELENTES\n");
            iroda.NapiJelentes();

            Console.ReadKey();
        }
    }
}