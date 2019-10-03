using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Osoba
    {
        protected string imie;
        protected string nazwisko;
        protected string dataUrodzenia;

        public Osoba(string imie,string nazwisko,string dataUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataUrodzenia = dataUrodzenia;
        }
        public virtual void WypiszInfo()
        {
            Console.WriteLine("Jestem osoba "+imie + " " + nazwisko + " Data urodzenia: " + dataUrodzenia);
        }
    }
    class Student : Osoba
    {
        private int rok;
        private int grupa;
        private int nrIndeksu;
        private List<Ocena> oceny = new List<Ocena>();
         

        public Student(string imie, string nazwisko, string dataUrodzenia,int rok,int grupa,int nrIndeksu):
            base(imie,nazwisko,dataUrodzenia)
        {
            this.rok = rok;
            this.grupa = grupa;
            this.nrIndeksu = nrIndeksu;

        }

        public override void WypiszInfo()
        {
            Console.WriteLine("Jestem studentem "+imie + " " + nazwisko + " Data urodzenia: " + dataUrodzenia+
                              ",rok: "+rok+",grupa: "+grupa+",nr indeksu: "+nrIndeksu);
            WypiszOceny();
        }
        public void DodajOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            Ocena oc = new Ocena(nazwaPrzedmiotu, data, wartosc);
            oceny.Add(oc);
        }
        public  void WypiszOceny()
        {
            Console.WriteLine("Oceny Studenta " + imie + " " + nazwisko);
            for(int i = 0; i < oceny.Count; i++)
            {

                oceny[i].WypiszInfo();
            }
        }
        public void WypiszOcene(string nazwaPrzedmiotu)
        {
            for(int i=0;i<oceny.Count;i++)
            {
                if(oceny[i].NazwaPrzedmiotu==nazwaPrzedmiotu)
                {
                    oceny[i].WypiszInfo();
                }
            }
        }
        public void UsunOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            for(int i=0;i<oceny.Count;)
            {
                Ocena o = oceny[i];
                if(o.NazwaPrzedmiotu==nazwaPrzedmiotu && o.Data==data && o.Wartosc == wartosc)
                {
                    oceny.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
            }
        }
        public void UsunOceny()
        {
            oceny.Clear();
        }
        public void UsunOceny(string nazwaPrzedmiotu)
        {
            
            for (int i = 0; i < oceny.Count;)
            {
                Ocena o = oceny[i];
                if (o.NazwaPrzedmiotu == nazwaPrzedmiotu)
                {
                    oceny.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
            }
        }

    }
    class Pilkarz : Osoba
    {
        private string pozycja;
        private string klub;
        private int liczbaGoli = 0;

        public Pilkarz(string imie, string nazwisko, string dataUrodzenia,string pozycja,string klub):
            base(imie, nazwisko, dataUrodzenia)
        {
            this.pozycja = pozycja;
            this.klub = klub;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("Jestem pilkarzem "+imie + " " + nazwisko + " Data urodzenia: " + dataUrodzenia +
                              ",pozycja: " + pozycja + ",klub: " + klub+",liczba strzelonych goli: "+liczbaGoli);
        }
        public virtual void StrzelGola()
        {
            liczbaGoli++;
        }

    }
    class PilkarzReczny : Pilkarz
    {
        public PilkarzReczny(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub) : 
        base(imie, nazwisko, dataUrodzenia, pozycja, klub) {}
        public override void StrzelGola() 
        {
            base.StrzelGola();
            Console.WriteLine("Ręczny strzelił");
        }
    }
    class PilkarzNozny : Pilkarz
    {
        public PilkarzNozny(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub) :
        base(imie, nazwisko, dataUrodzenia, pozycja, klub)
        { }
        public override void StrzelGola()
        {
            base.StrzelGola();
            Console.WriteLine("Nożny strzelił");
        }
    }



    class Ocena
    {
        private string nazwaPrzedmiotu;
        private string data;
        private double wartosc;

        public Ocena(string nazwaPrzedmiotu, string data, double wartosc)
        {
            this.NazwaPrzedmiotu = nazwaPrzedmiotu;
            this.Data = data;
            this.Wartosc = wartosc;
        }

        public string NazwaPrzedmiotu { get => nazwaPrzedmiotu; set => nazwaPrzedmiotu = value; }
        public string Data { get => data; set => data = value; }
        public double Wartosc { get => wartosc; set => wartosc = value; }

        public void WypiszInfo()
        {
            Console.WriteLine("Nazwa przedmiotu: " + NazwaPrzedmiotu + ",data:" + Data + ",ocena:" + Wartosc);
        }
    }
    



    class Program
    {
        static void Main(string[] args)
        {
            /*
            //zadanie 1
            Osoba o = new Osoba("Adam", "Miś", "20.03.1980");
            Osoba o2 = new Student("Michal", "Kot", "13.04.1990", 2, 1, 12345);
            Osoba o3 = new Pilkarz("Mateusz", "Żbik", "10.08.1986", "obrońca", "Fc Czestochowa");

            o.WypiszInfo();
            o2.WypiszInfo();
            o3.WypiszInfo();

            Student s = new Student("Krzysztof", "Jeż", "22.12.1990", 2, 5, 54321);
            Pilkarz p = new Pilkarz("Piotr", "Kos", "14.09.1986", "napastnik", "Fc Politechnika");

            s.WypiszInfo();
            p.WypiszInfo();

            ((Pilkarz)o3).StrzelGola();
            p.StrzelGola();
            p.StrzelGola();

            o3.WypiszInfo();
            p.WypiszInfo();

            //zadanie 2
            Console.WriteLine();
            Console.WriteLine("Zadanie 2");
            Console.WriteLine();
            ((Student)o2).DodajOcene("PO", "20.02.2011", 5.0);
            ((Student)o2).DodajOcene("Bazy Danych", "13.02.2011", 4.0);

            o2.WypiszInfo();

            s.DodajOcene("Bazy danych", "01.05.2011", 5.0);
            s.DodajOcene("AWW", "11.05.2011", 5.0);
            s.DodajOcene("AWW", "02.04.2011", 4.5);

            s.WypiszInfo();

            s.UsunOcene("AWW", "02.04.2011", 4.5);
            s.WypiszInfo();

            s.DodajOcene("AWW", "02.04.2011", 4.5);
            s.UsunOceny("AWW");

            s.WypiszInfo();

            s.DodajOcene("AWW", "02.04.2011", 4.5);
            s.UsunOceny();

            s.WypiszInfo();
            */
            //Zadanie 3
            Pilkarz x = new PilkarzNozny("Jan", "Kos", "14.09.1986", "napastnik", "Fc Barcelona");
            x.WypiszInfo();
            x.StrzelGola();
            x.WypiszInfo();
            Pilkarz y = new PilkarzReczny("Marian", "Knos", "12.09.1986", "napastnik", "Fc Politechnika");
            y.WypiszInfo();
            y.StrzelGola();
            y.WypiszInfo();

            y.StrzelGola();
            y.StrzelGola();
            y.WypiszInfo();
            Console.ReadKey();

        }
    }
}
