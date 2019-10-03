using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{

    interface IInfo
    {
        void WypiszInfo();
    }
    abstract class Zwierze : IInfo
    {
        public string Gatunek { set; get; }
        public string Pozywienie { set; get; }
        public string Pochodzenie { set; get; }

         public Zwierze()
        {
            Gatunek = "";
            Pozywienie = "";
            Pochodzenie = "";
        }
        public Zwierze(string Gatunek, string Pozywienie, string Pochodzenie)
        {
            this.Gatunek = Gatunek;
            this.Pozywienie = Pozywienie;
            this.Pochodzenie = Pochodzenie;
        }

        public abstract void WypiszInfo();
        
    }
    class Ptaki : Zwierze
    {
        public double Rozpietosc { get; set; }
        public double Wytrzymalosc { get; set; }

        public Ptaki() : base()
        {
            Rozpietosc = 0.0;
            Wytrzymalosc = 0.0;
        }
        public Ptaki(string Gatunek, string Pozywienie, string Pochodzenie,double Rozpietosc, double Wytrzymalosc)
            : base (Gatunek,Pozywienie,Pochodzenie)
        {
            this.Rozpietosc = Rozpietosc;
            this.Wytrzymalosc = Wytrzymalosc;
        }
        public double DlugoscLotu(double Rozpietosc, double Wytrzymalosc)
        {
            return Rozpietosc * Wytrzymalosc;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("Gatunek: " + Gatunek + " " + " Pozywienie: " + Pozywienie + " Pochodzenie: "+Pochodzenie
                + " Rozpietosc: " + Rozpietosc + " Wytrzymalosc: " + Wytrzymalosc);
            Console.WriteLine("Dlugosc lotu: "+DlugoscLotu(Rozpietosc, Wytrzymalosc));
        }
    }
    class Gady : Zwierze
    {
        public bool Jadowity { get; set; }
        public Gady() : base()
        {
            Jadowity = false;
        }
        public Gady(string Gatunek, string Pozywienie, string Pochodzenie,bool Jadowity)
            : base(Gatunek, Pozywienie, Pochodzenie)
        {
            this.Jadowity = Jadowity;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("Gatunek: " + Gatunek + " " + " Pozywienie: " + Pozywienie +
                " Pochodzenie: " + Pochodzenie + " Jadowity: " + Jadowity);
        }
    }
    class Ssaki : Zwierze
    {
        public string Srodowisko { get; set; }

        public Ssaki() : base()
        {
            Srodowisko = "";
        }
        public Ssaki(string Gatunek, string Pozywienie, string Pochodzenie,string Srodowisko)
            : base(Gatunek, Pozywienie, Pochodzenie)
        {
            this.Srodowisko = Srodowisko;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("Gatunek: " + Gatunek + " " + " Pozywienie: " + Pozywienie +
                " Pochodzenie: " + Pochodzenie + " Srodowisko: " +Srodowisko );
        }
    }
    class Klatka :IInfo
    {
        public int Pojemnosc { get; set; }
        public long Id { get; set; }

        private List<Zwierze> zwierzeta = new List<Zwierze>();
        public Klatka (int Pojemnosc,long Id)
        {
            this.Pojemnosc = Pojemnosc;
            this.Id = Id;
        }
        public bool DodajZwierze(Zwierze zwierze)
        {
            if (zwierzeta.Count < Pojemnosc)
            {
                zwierzeta.Add(zwierze);
                return true;
            }
            else
            {
                Console.WriteLine("Klatka jest Pelna");
                return false;
            }
        }
        public void Posprzataj()
        {
            Console.WriteLine("Posprzatalem klatke o ID: " + Id);
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Klatka o id: " + Id + " pojemnosc: " + Pojemnosc);
            for(int i = 0; i < zwierzeta.Count; i++)
            {
                zwierzeta[i].WypiszInfo();
            }
        }
    }
    class Opiekun : IInfo
    {
        public string Nazwisko { get; set; }
        private List<Klatka> klatki = new List<Klatka>();
        public Opiekun(string Nazwisko)
        {
            this.Nazwisko = Nazwisko;
        }
        public void DodajKlatke(Klatka klatka)
        {
            klatki.Add(klatka);
        }
        public void PosprzatajWszystkie()
        {
            for(int i = 0; i < klatki.Count; i++)
            {
                klatki[i].Posprzataj();
            }
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Nazwisko: " + Nazwisko+"Przydzielone Klatki: ");
            for(int i = 0; i < klatki.Count; i++)
            {
                Console.WriteLine("Id: " + klatki[i].Id);
            }
        }
    }
    class Zoo
    {
        private List<Opiekun> opiekunowie = new List<Opiekun>();
        private List<Klatka> klatki = new List<Klatka>();
        
        public void WypiszInfoKlatek()
        {
            if (klatki.Count != 0)
            {
                for (int i = 0; i < klatki.Count; i++)
                {
                    klatki[i].WypiszInfo();
                }
            }
            else
            {
                Console.WriteLine("Nie posiadamy klatek!");
            }
        }
        public void DodajKlatke(Klatka kl,Opiekun opiekun)
        {
            klatki.Add(kl);
            opiekun.DodajKlatke(kl);
        }
        public void PowiekszKlatke(Klatka kl,int pojem)
        {
            kl.Pojemnosc = pojem;
        }
        public void NowyPrac(Opiekun opiekun)
        {
            opiekunowie.Add(opiekun);
        }
        public void UmiescZwierze(Zwierze zw,Klatka kl)
        {
            kl.DodajZwierze(zw);
        }
        
    }



    class Program
    {
        static void Main(string[] args)
        {
            Opiekun Artur = new Opiekun("Karny");
            Opiekun Jan = new Opiekun("Zamojski");
            Zwierze orzel = new Ptaki("ptak", "robaki", "Polska", 10.2, 2.3);
            Zwierze waz = new Gady("gad", "chomik", "afryka", true);
            Zwierze malpa = new Ssaki("ssak", "banan","afryka","drzewo");
            Klatka klatka1 = new Klatka(5, 1);
            Klatka klatka2 = new Klatka(1, 2);
            Zoo zoo = new Zoo();
            zoo.WypiszInfoKlatek();
            zoo.NowyPrac(Artur);
            zoo.NowyPrac(Jan);
            zoo.DodajKlatke(klatka1,Artur);
            zoo.DodajKlatke(klatka2, Jan);
            zoo.UmiescZwierze(orzel, klatka1);
            zoo.UmiescZwierze(waz, klatka2);
            zoo.UmiescZwierze(malpa, klatka1);
            zoo.WypiszInfoKlatek();
            Console.WriteLine();
            zoo.PowiekszKlatke(klatka2, 2);
            zoo.WypiszInfoKlatek();
            Jan.PosprzatajWszystkie();
            Artur.PosprzatajWszystkie();


            Console.ReadKey();

            
        }
    }
}
