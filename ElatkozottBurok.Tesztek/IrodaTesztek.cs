using ElatkozottBurok;
namespace ElatkozottBurok.Tesztek
{
    [TestFixture]
    public class IrodaTesztek
    {
        [Test]
        public void Nassolnivalo_UresNev_BeallitjaAlapértelmezettet()
        {
            var snack = new Nassolnivalo("", 10, 10, 200);
            Assert.That(snack.Nev, Is.EqualTo("Ismeretlen nassolnivaló"));
        }

        [Test]
        public void Nassolnivalo_Hatarteruletek_HelyesenVagja()
        {
            var snack = new Nassolnivalo("Energiaital", 80, -5, 50);
            Assert.That(snack.KoffeinLoket, Is.EqualTo(50));
            Assert.That(snack.Stresszoldas, Is.EqualTo(0));
            Assert.That(snack.Ar, Is.EqualTo(100));
        }

        [Test]
        public void Fejleszto_KoffeinEsStresszHatarteruletek_EsKiegveAllapot()
        {
            var dev = new Fejleszto("Teszt Elek", Munkakor.Junior, 1000, 50, 20, false, "Kávé");

            dev.Koffeinszint = 120;
            Assert.That(dev.Koffeinszint, Is.EqualTo(100));
            Assert.That(dev.Kiegve, Is.True);

            var dev2 = new Fejleszto("Teszt Anna", Munkakor.Senior, 1000, 50, 20, false, "Kávé");
            dev2.StresszSzint = 100;
            Assert.That(dev2.StresszSzint, Is.EqualTo(100));
            Assert.That(dev2.Kiegve, Is.True);
        }

        [Test]
        public void Fejleszto_KedvencSnack_KetszeresStresszoldasEsExtraKoffein()
        {
            var dev = new Fejleszto("Márk", Munkakor.Junior, 1000, 30, 50, false, "Maci Laci");
            var kedvenc = new Nassolnivalo("Maci Laci", 10, 10, 200);

            dev.Fogyaszt(kedvenc);

            // Koffein: 30 + 10 + 5 (bónusz) = 45
            // Stressz: 50 - (10 * 2) = 30
            Assert.That(dev.Koffeinszint, Is.EqualTo(45));
            Assert.That(dev.StresszSzint, Is.EqualTo(30));
        }

        [Test]
        public void Automata_ElakadvaAllapotban_MegnoveliAVasarloStresszet()
        {
            List<Nassolnivalo> tesztNassok = new List<Nassolnivalo>
            {
                new Nassolnivalo("Espresso", 30, 5, 500),
                new Nassolnivalo("Cappuccino", 25, 10, 650),
                new Nassolnivalo("Energiaital", 50, 0, 700),
                new Nassolnivalo("Zöld tea", 15, 20, 450),
                new Nassolnivalo("Csokiszelet", 10, 15, 400),
            };
            var automata = new Automata(1000,tesztNassok, true);
            var dev = new Fejleszto("Péter", Munkakor.Senior, 1000, 50, 20, false, "Kávé");

            var kapott = automata.Vasarlas("Kávé", dev);

            Assert.That(kapott, Is.Null);
            Assert.That(dev.StresszSzint, Is.EqualTo(35)); // 20 + 15
        }

        //[Test]
        //public void Automata_KevesPenz_NemAdKiTermeket()
        //{
        //    var automata = new Automata();
        //    automata.Feltolt(new List<Nassolnivalo> { new Nassolnivalo("Kávé", 20, 10, 300) });
        //    var dev = new Fejleszto("Szegény Béla", Munkakor.Junior, 100, "Kávé");

        //    var kapott = automata.Vasarlas("Kávé", dev);

        //    Assert.That(kapott, Is.Null);
        //    Assert.That(dev.Penz, Is.EqualTo(100));
        //}
    }
}

