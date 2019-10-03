using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Samochod
    {
        private string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        private double srednieSpalanie;
        private string numerRejestracyjny;

        private static int iloscSamochodow = 0;
        //konstruktory
        public Samochod()
        {
            marka = "nieznana";
            model = "nieznany";
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0.0;
            numerRejestracyjny = "nieznany";
            iloscSamochodow++;
        }
        public Samochod(string marka_,string model_, int iloscDrzwi_,int pojemnoscSilnika_,double srednieSpalanie_,string numerRejestracyjny_)
        {
            marka = marka_;
            model = model_;
            iloscDrzwi = iloscDrzwi_;
            pojemnoscSilnika = pojemnoscSilnika_;
            srednieSpalanie = srednieSpalanie_;
            numerRejestracyjny = numerRejestracyjny_;
            iloscSamochodow++;
        }
        
        //setery getery
        public string Marka { get { return marka; } set { marka = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int IloscDrzwi { get { return iloscDrzwi; } set { iloscDrzwi = value; } }
        public int PojemnoscSilnika { get => pojemnoscSilnika; set => pojemnoscSilnika = value; }
        public double SrednieSpalanie { get => srednieSpalanie; set => srednieSpalanie = value; }
        public string NumerRejestracyjny { get => numerRejestracyjny; set => numerRejestracyjny = value; }

        //metody
        public double ObliczSpalanie(double dlugoscTrasy)
        {
            return (srednieSpalanie * dlugoscTrasy) / 100.0;
        }

        public double ObliczKosztPrzejazdu(double dlugoscTrasy,double cenaPaliwa)
        {
            return ObliczSpalanie(dlugoscTrasy) * cenaPaliwa;
        }
        public void WypiszInfo()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Ilość drzwi: " + iloscDrzwi);
            Console.WriteLine("Pojemność silnika: " + pojemnoscSilnika);
            Console.WriteLine("Średnie spalanie: " + srednieSpalanie);
            Console.WriteLine("Numer rejestracyjny: " + numerRejestracyjny);
        }
        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine("Ilość samochodów: " + iloscSamochodow);
        }
    }

    class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        //konstruktory
        public Garaz()
        {
            adres = "nieznany";
            pojemnosc = 0;
            samochody = null;
        }
        public Garaz(string adres_,int pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;
            samochody = new Samochod[pojemnosc];
        }

        //settery gettery
        public string Adres { get => adres; set => adres = value; }
        public int Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }
        //metody

        public void WprowadzSamochod(Samochod s)
        {
            if (liczbaSamochodow == pojemnosc)
            {
                Console.WriteLine("Brak miejsca!");
            }
            else
            { 
                samochody[liczbaSamochodow] = s;
                liczbaSamochodow++;
            }
            
        }

        public Samochod WyprowadzSamochod()
        {
            if(liczbaSamochodow==0)
            {
                Console.WriteLine("Garaż jest pusty!");
            }
            else
            {
                samochody[liczbaSamochodow - 1] = null;
                liczbaSamochodow--;
            }
            return samochody[liczbaSamochodow];

        }


        public void WypiszInfo()
        {
            Console.WriteLine("Adres grażu: " + adres);
            Console.WriteLine("Pojemność garażu: " + pojemnosc);
            Console.WriteLine("Liczba Samochodów: " + liczbaSamochodow);
            for(int i = 0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
            } 
        }
 
    }


        class Osoba
    {

        private string imie;
        private string nazwisko;
        private string adresZamieszkania;
        private int iloscSamochodow = 0;
        private string[] numeryRejestracyjne;

        private const int rozmair = 3;

        //konstruktory
        public Osoba()
        {
            Imie = "nieznane";
            Nazwisko = "nieznane";
            AdresZamieszkania = "nieznany";
            numeryRejestracyjne = null;
        }
        public Osoba(string imie_,string nazwisko_,string adresZamieszkania_,int iloscSamochodow_)
        {
            Imie = imie_;
            Nazwisko = nazwisko_;
            AdresZamieszkania = adresZamieszkania_;
            iloscSamochodow = iloscSamochodow_;
            numeryRejestracyjne = new string[rozmair];
            for (int i = 0; i < iloscSamochodow; i++)
            {
                Console.WriteLine("Wprowadź numery rejestracyjny: ");
                numeryRejestracyjne[i] = Console.ReadLine();
            }
            
        }
        //getery i setery
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string AdresZamieszkania { get => adresZamieszkania; set => adresZamieszkania = value; }

        //metody
        public void DodajSamochod(string nrRejestracyjny)
        {
            if(iloscSamochodow==rozmair)
            {
                Console.WriteLine("Przykro mi posiadasz juz 3 samochody");
            }
            else
            {
                numeryRejestracyjne[iloscSamochodow] = nrRejestracyjny;
                iloscSamochodow++;
            }
        }

        public void UsunSamochod(string numer)
        {
            if(iloscSamochodow==0)
            {
                Console.WriteLine("Nie masz samochodu do usuniecia!");
            }
            else
            {
                for(int i=0;i<iloscSamochodow;i++)
                {
                    if(numeryRejestracyjne[i]==numer)
                    {
                        
                        numeryRejestracyjne[i] = null;
                        for(int j =i; j<rozmair-1;j++)
                        {
                            numeryRejestracyjne[j] = numeryRejestracyjne[j + 1];
                        }

                        iloscSamochodow--;

                    }
                    
                }
                
            }
        }

        public void WypiszInfo()
        {

            Console.WriteLine("Imie: " + imie +", nazwisko: "+nazwisko+", Adres zamieszkania: "+adresZamieszkania+", Liczba Samochodów: "+iloscSamochodow);
            if (iloscSamochodow != 0)
                Console.WriteLine("Posiadam samochody o numerach: ");
            else
                Console.WriteLine("Nie posiadam samochodu");
            for (int i = 0; i < iloscSamochodow; i++)
                Console.WriteLine(numeryRejestracyjne[i]);
        }

    }




        class Program
    {
        static void Main(string[] args)
        {
            /*
            Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0,"KNS3292");
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6,"KGR3212");

            Garaz g1 = new Garaz();
            g1.Adres = "ul. Garażowa 1";
            g1.Pojemnosc = 1;

            Garaz g2 = new Garaz("ul. Garażowa 2", 2);

            g1.WprowadzSamochod(s1);
            g1.WypiszInfo();
            g1.WprowadzSamochod(s2);
            g2.WprowadzSamochod(s2);
            g2.WprowadzSamochod(s1);
            g2.WypiszInfo();

            g2.WyprowadzSamochod();
            g2.WypiszInfo();

            g2.WyprowadzSamochod();
            g2.WyprowadzSamochod();

            Console.WriteLine();
            */
            //Zadanie Domowe
            Console.WriteLine("ZADANIE DOMOWE");
            Osoba os1 = new Osoba("Dawid", "Kek", "Czarna Góra", 0);
            Osoba os2 = new Osoba("Jan", "Zam", "Kędzierzyn", 2);

            os2.DodajSamochod("KNS1232");
            os2.WypiszInfo();
            os2.UsunSamochod("KNS1232");
            os2.WypiszInfo();

            os1.DodajSamochod("KNS2122");
            os1.DodajSamochod("KNS3222");
            os1.DodajSamochod("KGR1111");
            os1.WypiszInfo();
            os1.UsunSamochod("KNS2122");
            os1.WypiszInfo();






            Console.ReadKey();


        }
    }
}
