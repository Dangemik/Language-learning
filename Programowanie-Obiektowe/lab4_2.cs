using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2
{
    
    class Lista
    {
        private Element pierwszyElement=null;
        private int liczbaElementow=0;

        public void Dodaj(Osoba e)
        {
            Element element = new Element(e);
            if (pierwszyElement == null)
            {
                pierwszyElement = element;
                liczbaElementow++;
            }
            else if(pierwszyElement!=null)
            {
                Element el = pierwszyElement;
                while (el.NastepnyElement != null)
                {
                    el = el.NastepnyElement;

                }
                el.NastepnyElement = element;
                liczbaElementow++;
            }
        }
        public Osoba Pobierz(int index)
        {
            if (index==0)
            {
                Osoba result = pierwszyElement.Wartosc;
                pierwszyElement = pierwszyElement.NastepnyElement;
                return result;
            }

            else if(index<liczbaElementow)
            {
             
                Element poprzedni = pierwszyElement;
                Element result = pierwszyElement.NastepnyElement;
                for (int i = 2; i <= index; i++)
                {
                    poprzedni = result;
                    result = result.NastepnyElement;
                    
                   
                }
                poprzedni.NastepnyElement = result.NastepnyElement;
                liczbaElementow--;
                return result.Wartosc;
            }
            else
            {
                return null; 
            }
            
        }
        public void Wstaw(Osoba e,int index)
        {
            Element element = new Element(e);
            if (index == 0)
            {
                element.NastepnyElement = pierwszyElement;
                pierwszyElement = element;
            }
            else if (index < liczbaElementow)
            {
                
                Element poprzedni = pierwszyElement;
                Element result = pierwszyElement.NastepnyElement;
                for (int i = 2; i <= index; i++)
                {
                    poprzedni = result;
                    result = result.NastepnyElement;
                }
                poprzedni.NastepnyElement = element;
                element.NastepnyElement = result;
                liczbaElementow++;
            }
        }
        public void Wypisz()
        {
            Element e = pierwszyElement;
            while (e != null)
            {
                e.Wartosc.WypiszInfo();
                e = e.NastepnyElement;
            }
        }
    }
    
    class Element
    {
        public Osoba Wartosc { get; set; }
        public Element NastepnyElement { get; set; }

        public Element(Osoba Wartosc)
        {
            this.Wartosc = Wartosc;
        }
    }

    class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Osoba(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }
        public void WypiszInfo()
        {
            Console.WriteLine(Imie + " " + Nazwisko);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            
            Osoba o = new Osoba("Alicja","Nowak");
            Osoba o2 = new Osoba("Karolina","Kowalska");
            Osoba o3 = new Osoba("Michal","Jabloński");
            Osoba o4 = new Osoba("Karol","Wiśniewski");

            Lista l = new Lista();

            l.Dodaj(o);
            l.Dodaj(o2);
            l.Dodaj(o3);
            l.Dodaj(o4);

            l.Wypisz();
            Console.WriteLine();
            l.Pobierz(2);
            l.Pobierz(0);
            l.Pobierz(1);

            l.Wypisz();
            Console.WriteLine();
            l.Wstaw(o3, 0);
            l.Wstaw(o4, 1);
            l.Wstaw(o, 2);

            l.Wypisz();

            Console.ReadKey(); 
        }
    }
}
