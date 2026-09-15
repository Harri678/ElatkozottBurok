using System;

namespace ElatkozottBurok
{
    public class Nassolnivalo
    {
        private string nev;
        private int koffeinLoket;
        private int StresszOldas;
        private int ar;

        public Nassolnivalo(string nev, int koffeinLoket, int StresszOldas, int ar)
        {
            this.Nev = nev;
            this.KoffeinLoket = koffeinLoket;
            this.StresszOldas = StresszOldas;
            this.Ar = ar;
        }

        public string Nev { 
            get => nev; 
            set 
            {
                if(nev == "" || nev == null)
                {
                    nev = "Ismeretlen nassolnivaló";
                }
                else
                {
                    nev = value; 
                }
            }
        }

        public int KoffeinLoket { get => koffeinLoket; set => koffeinLoket = value; }
        public int Stresszoldas { get => StresszOldas; set => StresszOldas = value; }
        public int Ar { get => ar; set => ar = value; }
    }
}