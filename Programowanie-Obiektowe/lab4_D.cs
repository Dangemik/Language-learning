using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_D
{
    class Program
    {
        //STOS
        class Element
        {
            public Object Wartosc { get; set; }
            public Element PoprzedniElement { get; set; }
            public Element(Object war)
            {
                Wartosc = war;
            }
        }
        class Stos
        {
            private Element wierzcholek;

            public Stos()
            {
                wierzcholek = null;
            }
 
            public void Dodaj(Object e)
            {
                Element el = new Element(e);
                Element temp = wierzcholek;
                wierzcholek = el;
                wierzcholek.PoprzedniElement = temp;
               
            }
            public void Usun()
            {
                if (wierzcholek != null)
                {
                    wierzcholek = wierzcholek.PoprzedniElement;
                }
                else
                {
                    Console.WriteLine("Stos jest pusty");
                }
            }
            public int Zlicz()
            {
                if (wierzcholek != null)
                {
                    int licznik = 0;
                    Element temp = wierzcholek;
                    while (temp != null)
                    {
                        licznik++;
                        temp = temp.PoprzedniElement;
                    }
                    return licznik;
                }
                else
                {
                    return 0;
                }
            }
            public void Wypisz()
            {
                if (wierzcholek != null)
                {
                    Element temp = wierzcholek;
                    while (temp != null)
                    {
                        Console.WriteLine(temp.Wartosc);
                        temp = temp.PoprzedniElement;
                    }
                }
                else
                {
                    Console.WriteLine("Stos jest pusty");
                }
            }
        }
        //KOLEKCJA Z LISTY DWUKIERUNKOWEJ

        class Elem
        {
            public Object Wartosc { get; set; }
            public Elem PoprzedniElement { get; set; }
            public Elem NastepnyElement { get; set; }
            public Elem(Object war)
            {
                Wartosc = war;
            }
        }
        class Kolekcja
        {
            private Elem pierwszyElement=null;
            private int liczbaElementow = 0;
            
            public void Dodaj(Object e)
            {
                Elem element = new Elem(e);
                if (pierwszyElement == null)
                {
                    pierwszyElement = element;
                    liczbaElementow++;
                }
                else if (pierwszyElement != null)
                {
                    Elem el = pierwszyElement;
                    Elem temp = pierwszyElement.PoprzedniElement;
                    while (el.NastepnyElement != null)
                    {
                        temp = el;
                        el = el.NastepnyElement;
                        
                    }
                    el.NastepnyElement = element;
                    el.PoprzedniElement = temp;
                    liczbaElementow++;
                }
            }
            public Object Usun(int index)
            {
                if (index == 0)
                {
                    object result = pierwszyElement.Wartosc;
                    pierwszyElement = pierwszyElement.NastepnyElement;
                    return result;
                }

                else if (index < liczbaElementow)
                {

                    Elem poprzedni = pierwszyElement;
                    Elem result = pierwszyElement.NastepnyElement;
                    for (int i = 2; i <= index; i++)
                    {
                        poprzedni = result;
                        result = result.NastepnyElement;


                    }
                    Elem temp = poprzedni;
                    poprzedni.NastepnyElement = result.NastepnyElement;
                    result.PoprzedniElement = temp;
                    liczbaElementow--;
                    return result.Wartosc;
                }
                else
                {
                    return null;
                }
            }

            public void Wstaw(Object e, int index)
            {
                Elem element = new Elem(e);
                if (index == 0)
                {
                    element.NastepnyElement = pierwszyElement;
                    pierwszyElement = element;
                }
                else if (index < liczbaElementow)
                {

                    Elem poprzedni = pierwszyElement;
                    Elem result = pierwszyElement.NastepnyElement;
                    for (int i = 2; i <= index; i++)
                    {
                        poprzedni = result;
                        result = result.NastepnyElement;
                    }

                    poprzedni.NastepnyElement = element;
                    element.PoprzedniElement = poprzedni;
                    element.NastepnyElement = result;
                   
                    liczbaElementow++;
                }
            }

            public void Wypisz()
            {
                Elem e = pierwszyElement;
                while (e != null)
                {
                    Console.WriteLine( e.Wartosc.ToString());
                    e = e.NastepnyElement;
                }
               
            }

        }


        static void Main(string[] args)
        {
            //STOS
            Console.WriteLine("STOS");
            string s1 = "Dawid";
            string s2 = "Jan";
            string s3 = "Kowalski";
            Stos stos = new Stos();

            stos.Dodaj(s1);
            stos.Dodaj(s2);
            stos.Dodaj(s3);
           
            stos.Wypisz();
            Console.WriteLine("liczba elementow na stosie: "+ stos.Zlicz());
            stos.Usun();
            stos.Usun();
            stos.Wypisz();
            Console.WriteLine("liczba elementow na stosie: " + stos.Zlicz());

            Console.WriteLine("KOLEKCJA Z LISTY DWUKIERUNKOWEJ");
            //KOLEKCJA Z LISTY DWUKIERUNKOWEJ
            string k1 = "kon";
            string k2 = "ptak";
            string k3 = "kaczor";
            Kolekcja kolekcja = new Kolekcja();
            kolekcja.Dodaj(k1);
            kolekcja.Dodaj(k2);
            kolekcja.Dodaj(k3);
            kolekcja.Wypisz();
            Console.WriteLine();
            kolekcja.Usun(2);
            kolekcja.Usun(0); 
            kolekcja.Wypisz();
            Console.WriteLine();
            kolekcja.Wstaw("Malpa", 1);
            kolekcja.Wstaw("Osa", 1);
            kolekcja.Wypisz();

            Console.ReadKey();
        }
    }
}
