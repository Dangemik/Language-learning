using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    class Element
    {
        public Object Wartosc { get; set; }
        public Element nastepnyElement { get; set; }
        public Element(Object Wartosc)
        {
            this.Wartosc = Wartosc;
        }
        
       
    }
    class Kolejka
    {
        private Element pierwszyElement;
        private Element ostatniElement;
        public int LiczbaElementow { get; set; }



        public Kolejka()
        {
            pierwszyElement = null;
            ostatniElement = null;
            LiczbaElementow = 0;
        }
        public void Dodaj(Object wartosc)
        {
            Element e = new Element(wartosc);
            if (pierwszyElement == null)
            {
           
                pierwszyElement = e;
                ostatniElement = e;
                LiczbaElementow++;
            }else if (pierwszyElement != null)
            {
                ostatniElement.nastepnyElement = e;
                ostatniElement = e;
                LiczbaElementow++;
            }
        }
        public Object Pobierz()
        {
            if (pierwszyElement == null)
            {
                Console.WriteLine("Kolejka pusta");
                return null;
            }
            else
            {
                Element element = pierwszyElement;
                pierwszyElement = pierwszyElement.nastepnyElement;

                LiczbaElementow--;

                return element.Wartosc;
            }
                
        }
       
        public void Wypisz()
        {
            Element e = pierwszyElement;
            while(e!=null)
            {
                Console.WriteLine(e.Wartosc.ToString());
                e = e.nastepnyElement;
            }
        }
        



    }


    class Program
    {
        static void Main(string[] args)
        {

            Kolejka k = new Kolejka();
            k.Dodaj(1);
            k.Dodaj(5);
            k.Dodaj(3);
            k.Dodaj(8);
            k.Wypisz();
           
            Console.WriteLine("Liczba elementow: {0}", k.LiczbaElementow);
            int element = (int)k.Pobierz();
            Console.WriteLine("Liczba elementow: {0}", element);
            k.Wypisz();
            Console.WriteLine("Liczba elementow: {0}", k.LiczbaElementow);
            k.Dodaj(7);
            k.Dodaj(4);
            k.Wypisz();
            Console.WriteLine("Liczba elementow: {0}", k.LiczbaElementow);
            element = (int)k.Pobierz();
            Console.WriteLine("Liczba elementow: {0}", element);
            k.Wypisz();
            Console.WriteLine("Liczba elementow: {0}", k.LiczbaElementow);

            Console.ReadKey();
        }
    }
}
