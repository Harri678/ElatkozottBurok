using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Automata
    {
        private int keszpenzKassza;
        private List<Nassolnivalo> keszlet;
        private bool elakadva;
        private static Random random = new Random();
        public Automata(int keszpenzKassza, List<Nassolnivalo> keszlet, bool elakadva)
        {
            this.keszpenzKassza = keszpenzKassza;
            this.keszlet = keszlet;
            this.elakadva = elakadva;
        }

        public int KeszpenzKassza { get => keszpenzKassza; set => keszpenzKassza = value; }
        public List<Nassolnivalo> Keszlet { get => keszlet; set => keszlet = value; }
        public bool Elakadva { get => elakadva; set => elakadva = value; }

        public void Feltolt(List<Nassolnivalo> ujElemek)
        {
            Keszlet.AddRange(ujElemek);
        }

        public Nassolnivalo Vasarlas(string termekNev, Fejleszto vasarlo)
        {
            if(elakadva == true)
            {
                Console.WriteLine("Elakadt a termek");
                vasarlo.StresszSzint += 15;
                return null;
            }

            Nassolnivalo termek = Keszlet.FirstOrDefault(x => x.Nev.Equals(termekNev, StringComparison.OrdinalIgnoreCase));

            if (termek == null)
            {
                Console.WriteLine("A termek kifogyott");
                return null;
            }

            if(vasarlo.Penz <= termek.Ar)
            {
                Console.WriteLine("Nincs elegendo penze");
                return null;
            }

            int veletlen = random.Next(1, 101);

            if (veletlen < 15)
            {
                vasarlo.Penz -= termek.Ar;
                Elakadva = true;
                vasarlo.StresszSzint += 30;

                Console.WriteLine(
                    $"Az automata elakadt! {vasarlo.Nev} pénze levonásra került, " +
                    $"de a terméket nem kapta meg.");

                return null;
            }

            vasarlo.Penz -= termek.Ar;
            KeszpenzKassza += termek.Ar;
            Keszlet.Remove(termek);

            Console.WriteLine($"{vasarlo.Nev} megvásárolta: {termek.Nev} ({termek.Ar} Ft)");

            return termek;
        }

        public void JavitasRugassal()
        {
            if (!Elakadva)
            {
                Console.WriteLine("Az automata nincs elakadva.");
                return;
            }

            int veletlen = random.Next(1, 100);

            if (veletlen <= 50)
            {
                Elakadva = false;
                Console.WriteLine("A rúgás sikeres volt");
            }
            else
            {
                Console.WriteLine("RIASZTÓ");
            }
        }

    }
}