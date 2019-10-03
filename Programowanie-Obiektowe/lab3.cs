using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Katalog
    {
        
        private string dzialTematyczny { get; set; }

        private List<Pozycja> pozycje = new List<Pozycja>();
        public Katalog()
        {
            dzialTematyczny = "brak";
        }
        public Katalog(string dzialTematyczny)
        {
            this.dzialTematyczny = dzialTematyczny;
        }
        public void DodajPozycje(Pozycja pozycja)
        {
            pozycje.Add(pozycja);
        }
        public Pozycja ZnajdzPozycje(int ID)
        {
            for (int i = 0; i < pozycje.Count; i++)
            {
                if (ID == pozycje[i].Id)
                {
                    return pozycje[i];
                }

            }
            return null;
        }
        public void WypiszWszystkiePozycje()
        {
            for (int i = 0; i < pozycje.Count; i++)
            {
                Console.WriteLine("Pozycja numer: " + (i + 1)+" Tytul: "+pozycje[i].Tytyl + " ID: " + pozycje[i].Id + " Wydawnictwo: " + pozycje[i].Wydawnictwo + " Rok Wydania: " + pozycje[i].RokWydania);
            }
        }
    }

    abstract class Pozycja
    {
        protected string tytul;
        protected int id;
        protected string wydawnictwo;
        protected int rokWydania;

        public string Tytyl
        {
            get { return tytul; }
        }
        public int Id
        {
            get { return id; }
        }
        public string Wydawnictwo
        {
            get { return wydawnictwo; }
        }
        public int RokWydania
        {
            get { return rokWydania; }
        }

        public Pozycja()
        {
            tytul = "brak";
            id = 0;
            wydawnictwo = "brak";
            rokWydania = 0;
        }
        public Pozycja( string tytul,int id, string wydawnictwo,int rokWydania)
        {
            this.tytul = tytul;
            this.id = id;
            this.wydawnictwo = wydawnictwo;
            this.rokWydania = rokWydania;
        }
        public abstract void WypiszInfo();     
    }
    class Ksiazka : Pozycja
    {
        private int liczbaStron { get; set; }

        private List<Autor> autorzy = new List<Autor>();
        public Ksiazka() : base("brak",0,"brak",0)
        {
            liczbaStron = 0;
        }
        public Ksiazka(string tytul, int id, string wydawnictwo, int rokWydania,int liczbaStron)
                : base(tytul,id,wydawnictwo,rokWydania)
        {
            this.liczbaStron = liczbaStron;
        }
        
        public void DodajAutora(Autor autor)
        {
            autorzy.Add(autor);
        }
        public override void WypiszInfo()
        {
            for (int i = 0; i < autorzy.Count; i++) {
                Console.WriteLine("Autorzy: " + autorzy[i].imie + " " + autorzy[i].nazwisko);
                    }
            Console.WriteLine(tytul + " ID: " + id + " Wydawnictwo: " + wydawnictwo + " Rok Wydania: " + rokWydania + " Liczba Stron: " + liczbaStron);
        }
    }
    class Autor : Ksiazka
    {
        
        

        public string imie { get; set; }
        public string nazwisko { get; set; }

        public Autor() : base("brak", 0, "brak", 0,0)
        {
            imie = "brak";
            nazwisko = "brak";
        }
        public Autor(string imie,string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }

    class Czasopismo : Pozycja
    {
        

        public int numer { get; set; }

        public Czasopismo() : base("brak", 0, "brak", 0)
        {
            numer = 0;
        }
        public Czasopismo(string tytul, int id, string wydawnictwo, int rokWydania,int numer)
            : base(tytul, id, wydawnictwo, rokWydania)
        {
            this.numer = numer;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine(tytul + " ID: " + id + " Wydawnictwo: " + wydawnictwo + " Rok Wydania: " + rokWydania + " Numer:" + numer);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Katalog katalog1 = new Katalog("Dramat");
            Pozycja poz = new Ksiazka("Wolf", 2, "Helion", 2010,500);
           
            poz.WypiszInfo();
            katalog1.DodajPozycje(poz);
            katalog1.WypiszWszystkiePozycje();
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Ksiazka ksi = new Ksiazka("Wolfik", 3, "Helion", 2020, 600);
            ksi.DodajAutora(autor);
            ksi.WypiszInfo();
            Pozycja pozycja = katalog1.ZnajdzPozycje(2);
            pozycja.WypiszInfo();
            

            Console.ReadKey();

            
        }
    }
}
