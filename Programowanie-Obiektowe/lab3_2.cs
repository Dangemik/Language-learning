using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IZadzadzaniePozycjami
    {
         Pozycja ZnajdzPozycjePoTytule(string tytul);
         Pozycja ZnajdzPozycjePoId(int id);
         void WypiszWszystkiePozycje();
    }
    interface IZarzadzanieBibliotekarzami
    {
        void DodajBibliotekarza(Bibliotekarz bibliotekarz);
        void WypiszBibliotekarzy();
    }


    class Katalog : IZadzadzaniePozycjami
    {
        
        public string dzialTematyczny { get; set; }

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
        public Pozycja ZnajdzPozycjePoId(int ID)
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

        public Pozycja ZnajdzPozycjePoTytule(string tytul)
        {
            for(int i = 0; i < pozycje.Count; i++)
            {
                if (tytul == pozycje[i].Tytyl)
                {
                    return pozycje[i];
                }
            }
            return null;
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

        public string narodowosc { get; set; }

        public Autor() : base("brak", 0, "brak", 0,0)
        {
            imie = "brak";
            nazwisko = "brak";
        }
        public Autor(string imie,string nazwisko,string narodowsc)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.narodowosc = narodowosc;
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
    
    

    class Biblioteka : IZadzadzaniePozycjami,IZarzadzanieBibliotekarzami
    {
        private string adres;

        private List<Bibliotekarz> bibliotekarze = new List<Bibliotekarz>();
        private List<Katalog> katalogi = new List<Katalog>();

        public Biblioteka()
        {
            adres = "Brak";
        }
        public Biblioteka(string adres)
        {
            this.adres = adres;
        }
        public void DodajBibliotekarza(Bibliotekarz bibliotekarz)
        {
            bibliotekarze.Add(bibliotekarz);
        }
        public void WypiszBibliotekarzy()
        {
            for(int i=0;i<bibliotekarze.Count;i++)
            {
                bibliotekarze[i].WypiszInfo();
            }
        }
        public void DodajKatalog(Katalog katalog)
        {
            katalogi.Add(katalog);
        }
        public void DodajPozycje(Pozycja p, string dzialTematyczny)
        {
            for(int i =0; i < katalogi.Count; i++)
            {
                if(dzialTematyczny == katalogi[i].dzialTematyczny)
                {
                    katalogi[i].DodajPozycje(p);
                }
            }
        }

        public void WypiszWszystkiePozycje()
        {
            for(int i = 0; i < katalogi.Count; i++)
            {
                katalogi[i].WypiszWszystkiePozycje();
            }
        }

        public Pozycja ZnajdzPozycjePoId(int id)
        {
            for(int i = 0; i < katalogi.Count; i++)
            {
                return katalogi[i].ZnajdzPozycjePoId(id);
            }
            return null;
        }

        public Pozycja ZnajdzPozycjePoTytule(string tytul)
        {
            for (int i = 0; i < katalogi.Count; i++)
            {
                return katalogi[i].ZnajdzPozycjePoTytule(tytul);
            }
            return null;
        }
    }
    class Bibliotekarz : Osoba
    {
        private string dataZatrudnienia;
        private double wynagrodzenie;

        public Bibliotekarz() : base()
        {
            dataZatrudnienia = "Brak";
            wynagrodzenie = 0.0;

        }
        public Bibliotekarz(string imie, string nazwisko,string dataZatrudnienia,double wynagrodzenie):
            base(imie,nazwisko)
        {
            this.dataZatrudnienia = dataZatrudnienia;
            this.wynagrodzenie = wynagrodzenie;
        }
        public void WypiszInfo()
        {
            Console.WriteLine(imie + " " + nazwisko + " zatrudniony w " + dataZatrudnienia + " wynagrodzenie:" + wynagrodzenie);
        }
    }
    class Osoba
    {
        protected string imie;
        protected string nazwisko;

        public Osoba()
        {
            imie = "brak";
            nazwisko = "brak";
        }
        public Osoba(string imie,string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
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
            Autor autor = new Autor("Henryk", "Sienkiewicz","Niemic");
            Ksiazka ksi = new Ksiazka("Wolfik", 3, "Helion", 2020, 600);
            ksi.DodajAutora(autor);
            ksi.WypiszInfo();
            Pozycja pozycja = katalog1.ZnajdzPozycjePoId(2);
            pozycja.WypiszInfo();
            Biblioteka biblioteka = new Biblioteka("Czestochowa");
            Bibliotekarz Adam = new Bibliotekarz("Adam", "Kowalski", "2015", 3000);
            Bibliotekarz Jan = new Bibliotekarz("Jan", "Kowalski", "2013", 3200);
            biblioteka.DodajBibliotekarza(Adam);
            biblioteka.DodajBibliotekarza(Jan);
            biblioteka.WypiszBibliotekarzy();
            biblioteka.DodajKatalog(katalog1);
            biblioteka.WypiszWszystkiePozycje();




            Console.ReadKey();

            
        }
    }
}
