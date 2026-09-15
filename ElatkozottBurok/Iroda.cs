using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Iroda
    {
        public List<Fejleszto> Fejlesztok { get; set; }
        public Automata AutomataGep { get; set; }

        public Iroda()
        {
            Fejlesztok = new List<Fejleszto>();
            AutomataGep = new Automata(0, new List<Nassolnivalo>(), false);
        }

        public Iroda(List<Fejleszto> fejlesztok, Automata automataGep)
        {
            Fejlesztok = fejlesztok;
            AutomataGep = automataGep;
        }

        public void MunkanapSzimulacio(int orakSzama)
        {
            for (int ora = 1; ora <= orakSzama; ora++)
            {
                foreach (Fejleszto fejleszto in Fejlesztok)
                {
                    fejleszto.Dolgozik();

                    if (fejleszto.Koffeinszint < 20 ||
                        fejleszto.StresszSzint > 70)
                    {
                        VasarlasFejlesztonek(fejleszto);
                    }
                }

                foreach (Fejleszto fejleszto in Fejlesztok)
                {
                    Console.WriteLine(
                        $"{fejleszto.Nev} | " +
                        $"Koffein: {fejleszto.Koffeinszint} | " +
                        $"Stressz: {fejleszto.StresszSzint} | " +
                        $"Pénz: {fejleszto.Penz} Ft | " +
                        $"Kiegve: {fejleszto.Kiegve}");
                }
            }
        }

        private void VasarlasFejlesztonek(Fejleszto fejleszto)
        {
            if (AutomataGep == null || AutomataGep.Keszlet == null ||
                AutomataGep.Keszlet.Count == 0)
            {
                Console.WriteLine(
                    $"{fejleszto.Nev} szamara nincs elerheto nassolnivalo.");
                return;
            }

            if (AutomataGep.Elakadva)
            {
                Console.WriteLine(
                    $"Az automata elakadt, {fejleszto.Nev} megprobalja megjavitani.");

                AutomataGep.JavitasRugassal();

                if (AutomataGep.Elakadva)
                {
                    return;
                }
            }
            Nassolnivalo termek = null;

            foreach (Nassolnivalo nassolnivalo in AutomataGep.Keszlet) 
            { if (nassolnivalo.Nev.ToLower() == fejleszto.KedvencSnack.ToLower()) 
                { 
                    termek = nassolnivalo; break; 
                } 
            }

            if (termek == null)
            { 
                termek = AutomataGep.Keszlet[0]; 
                for (int i = 1; i < AutomataGep.Keszlet.Count; i++) 
                { if (AutomataGep.Keszlet[i].Ar < termek.Ar) 
                    { termek = AutomataGep.Keszlet[i]; 
                    } 
                } 
            }

            if (fejleszto.Penz <= termek.Ar)
            {
                Console.WriteLine($"{fejleszto.Nev} nem tud vasarolni.");
                return;
            }

            Nassolnivalo megvasaroltTermek = AutomataGep.Vasarlas(termek.Nev, fejleszto);

            if (megvasaroltTermek != null)
            {
                fejleszto.Fogyaszt(megvasaroltTermek);

                Console.WriteLine($"{fejleszto.Nev} elfogyasztotta: " + $"{megvasaroltTermek.Nev}");
            }
        }

        public void NapiJelentes()
        {
            Console.WriteLine("Harom legfeszultebb fejleszto: ");

            List<Fejleszto> legFeszultebbek = Fejlesztok.OrderByDescending(x => x.StresszSzint).Take(3).ToList();

            if (legFeszultebbek.Count == 0)
            {
                Console.WriteLine("Nincs fejleszto az irodaban.");
            }
            else
            {
                foreach (Fejleszto fejleszto in legFeszultebbek)
                {
                    string allapot;

                    if (fejleszto.Kiegve)
                    {
                        allapot = "kiegett";
                    }
                    else if (fejleszto.StresszSzint > 70)
                    {
                        allapot = "tul stresszes";
                    }
                    else if (fejleszto.Koffeinszint < 20)
                    {
                        allapot = "koffeinhianyos";
                    }
                    else
                    {
                        allapot = "rendben";
                    }

                    Console.WriteLine(
                        $"{fejleszto.Nev} | " + $"Stressz: {fejleszto.StresszSzint} | " + $"Allapot: {allapot}");
                }
            }

            int kiegettFejlesztok = Fejlesztok.Count(x => x.Kiegve);

            Console.WriteLine(
                $"Kiegett fejlesztok szama: {kiegettFejlesztok}");


            Console.WriteLine("\nAutomata statisztika");

            Console.WriteLine($"Teljes napi bevetel: " + $"{AutomataGep.KeszpenzKassza} Ft");

            Console.WriteLine($"Maradek keszlet: " + $"{AutomataGep.Keszlet.Count} db");

            Console.WriteLine($"Automata allapota: " + $"{(AutomataGep.Elakadva ? "elakadva" : "mukodik")}");
        }
    }
}