using System;

namespace ElatkozottBurok
{
    public class Fejleszto
    {
        private string nev;
        private Munkakor munkakor;
        private int penz;
        private int koffeinSzint;
        private int stresszSzint;
        private bool kiegve;
        private string kedvencSnack;

        public Fejleszto(string nev, Munkakor munkakor, int penz, int koffeinSzint, int stresszSzint, bool kiegve, string kedvencSnack)
        {
            Nev = nev;
            Munkakor = munkakor;
            Penz = penz;
            Koffeinszint = koffeinSzint;
            StresszSzint = stresszSzint;
            Kiegve = kiegve;
            KedvencSnack = kedvencSnack;
        }

        public string Nev
        {
            get => nev;
            set => nev = value;
        }

        public Munkakor Munkakor
        {
            get => munkakor;
            set => munkakor = value;
        }

        public int Penz
        {
            get => penz;
            set
            {
                if (value < 0)
                    penz = 0;
                else
                    penz = value;
            }
        }

        public int Koffeinszint
        {
            get => koffeinSzint;
            set
            {
                if (value < 0)
                {
                    koffeinSzint = 0;
                }
                else if (value > 100)
                {
                    koffeinSzint = 100;
                    kiegve = true;
                }
                else
                {
                    koffeinSzint = value;
                }

                if (koffeinSzint >= 100)
                    kiegve = true;
            }
        }

        public int StresszSzint
        {
            get => stresszSzint;
            set
            {
                if (value < 0)
                {
                    stresszSzint = 0;
                }
                else if (value > 100)
                {
                    stresszSzint = 100;
                    kiegve = true;
                }
                else
                {
                    stresszSzint = value;
                }

                if (stresszSzint >= 100)
                    kiegve = true;
            }
        }

        public bool Kiegve
        {
            get => kiegve;
            set => kiegve = value;
        }

        public string KedvencSnack
        {
            get => kedvencSnack;
            set => kedvencSnack = value;
        }

        public void Dolgozik()
        {
            if (Kiegve)
            {
                Console.WriteLine($"{Nev} fejlesztő kiégett.");
                return;
            }

            switch (Munkakor)
            {
                case Munkakor.Junior:
                    Koffeinszint -= 25;
                    StresszSzint += 20;
                    break;

                case Munkakor.Senior:
                    Koffeinszint -= 15;
                    StresszSzint += 10;
                    break;

                case Munkakor.DevOpsVarazslo:
                    Koffeinszint -= 10;
                    StresszSzint += 25;
                    break;
            }

            if (Koffeinszint < 15)
            {
                Console.WriteLine(
                    $"{Nev} fejlesztő lefagyott, koffeinre van szüksége.");
            }
        }

        public void Fogyaszt(Nassolnivalo elem)
        {
            if (elem == null)
                return;

            Koffeinszint += elem.KoffeinLoket;

            if (elem.Nev == KedvencSnack)
            {
                StresszSzint -= elem.Stresszoldas * 2;
                Koffeinszint += 5;
            }
            else
            {
                StresszSzint -= elem.Stresszoldas;
            }
        }
    }
}
