using System;
using System.ComponentModel.DataAnnotations;

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
            this.Stresszoldas = StresszOldas;
            this.Ar = ar;
        }

        public string Nev { 
            get => nev; 
            set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    nev = "Ismeretlen nassolnivaló";
                }
                else
                {
                    nev = value; 
                }
            }
        }

        public int KoffeinLoket { get => koffeinLoket; set 
            {
                if(value < 0)
                {
                    value = 0;
                }
                else if(value > 50)
                {
                    value = 50;
                }
                koffeinLoket = value;
            }
        }    
        public int Stresszoldas { 
            get => StresszOldas; 
            set
            {
                if (value < 0)
                {
                    StresszOldas = 0;
                }
                else if (value > 100)
                {
                    StresszOldas = 100;
                }
                else
                {
                    StresszOldas = value;
                }
            }
        }
        public int Ar { get => ar; set { if (koffeinLoket >= 50) ar = value * 2; else ar = value; } }
    }
}