using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    interface IInfo
    {
        void WypiszInfo();
    }
    class Osoba : IInfo
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string DataUrodzenia { get; set; }

        public Osoba()
        {
            Imie = "";
            Nazwisko = "";
            DataUrodzenia = "";
        }

        public Osoba(string i, string n, string d)
        {
            Imie = i;
            Nazwisko = n;
            DataUrodzenia = d;
        }

        public virtual void WypiszInfo()
        {
            Console.WriteLine(Imie + " " + Nazwisko + " " + DataUrodzenia);
        }
    }
    class Wykladowca : Osoba
    {
        public string TytulNakowy { get; set; }
        public string Stanowisko { get; set; }

        public Wykladowca() :
            base()
        {
            TytulNakowy = "";
            Stanowisko = "";
        }
        public Wykladowca(string i, string n, string d, string stan, string tyt) :
            base(i, n, d)
        {
            TytulNakowy = stan;
            Stanowisko = tyt;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine(Imie + " " + Nazwisko + " " + DataUrodzenia +
                            " " + TytulNakowy + " " + Stanowisko);
        }

    }

    class Student : Osoba
    {
        public string Kierunek { get; set; }
        public string Specialnosc { get; set; }
        public int Rok { get; set; }
        public int Grupa { get; set; }
        public int NrIndeksu { get; set; }

        public List<OcenaKoncowa> ocenyKoncowe = new List<OcenaKoncowa>();

        public Student() : base()
        {
            Kierunek = "";
            Specialnosc = "";
            Rok = 0;
            Grupa = 0;
            NrIndeksu = 0;
            ocenyKoncowe = null;
        }
        public Student(string i, string n, string d, string kier,
            string spec, int ro, int gr, int nr) : base(i, n, d)
        {
            Kierunek = kier;
            Specialnosc = spec;
            Rok = ro;
            Grupa = gr;
            NrIndeksu = nr;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine(Imie + " " + Nazwisko + " " + DataUrodzenia +
                            " " + Kierunek + " " + Specialnosc + " " + Rok + " " + Grupa + " " + NrIndeksu);
        }
        public void InfoOceny()
        {
            for (int i = 0; i < ocenyKoncowe.Count; i++)
            {
                ocenyKoncowe[i].WypiszInfo();
            }
        }
        public bool DodajOcene(Przedmiot przedmiot, double oce, string dat)
        {
            ocenyKoncowe.Add(new OcenaKoncowa(oce, dat, przedmiot));
            return true;
        }

    }

    class OcenaKoncowa : IInfo
    {
        public double Wartosc { get; set; }
        public string Data { get; set; }

        public Przedmiot przedmiot { get; set; }

        public OcenaKoncowa()
        {
            Wartosc = 0.0;
            Data = "";
            przedmiot = null;
        }
        public OcenaKoncowa(double ocena, string Da, Przedmiot prze)
        {
            Wartosc = ocena;
            Data = Da;
            przedmiot = prze;

        }


        public void WypiszInfo()
        {
            przedmiot.WypiszInfo();
            Console.WriteLine("Ocena: " + Wartosc + " Data: " + Data);
        }
    }

    class Przedmiot : IInfo
    {
        public string Nazwa { get; set; }
        public string Kierunek { get; set; }
        public string Specialnosc { get; set; }
        public int Semestr { get; set; }
        public int ilGodzin { get; set; }

        public Przedmiot()
        {
            Nazwa = "";
            Kierunek = "";
            Specialnosc = "";
            Semestr = 0;
            ilGodzin = 0;
        }
        public Przedmiot(string na, string kie, string spec, int sem, int ilG)
        {
            Nazwa = na;
            Kierunek = kie;
            Specialnosc = spec;
            Semestr = sem;
            ilGodzin = ilG;
        }

        public void WypiszInfo()
        {
            Console.WriteLine(Nazwa + " " + Kierunek + " " + Specialnosc + " " + Semestr + " " + ilGodzin);
        }
    }
    class Jednostka : IInfo
    {
        public string Nazwa { get; set; }
        public string Adres { get; set; }

        public List<Wykladowca> wykladowcy = new List<Wykladowca>();

        public Jednostka()
        {
            Nazwa = "";
            Adres = "";
            wykladowcy = null;
        }
        public Jednostka(string nazwa, string adres)
        {
            Nazwa = nazwa;
            Adres = adres;
        }
        public void DodajWykladowce(Wykladowca wyk)
        {
            wykladowcy.Add(wyk);
        }
        public bool UsunWykladowce(Wykladowca wyk)
        {
            wykladowcy.Remove(wyk);
            return true;
        }
        public bool UsunWykladowce(string im, string nazw)
        {
            for (int i = 0; i < wykladowcy.Count; i++)
            {
                if (wykladowcy[i].Imie == im && wykladowcy[i].Nazwisko == nazw)
                {
                    wykladowcy.RemoveAt(i);
                }
            }

            return true;
        }

        public void InfoWykladowcy()
        {
            for (int i = 0; i < wykladowcy.Count; i++)
            {
                wykladowcy[i].WypiszInfo();
            }
        }
        public void WypiszInfo()
        {
            Console.WriteLine(Nazwa + " " + Adres + " ");
            InfoWykladowcy();
        }
    }

    class Wydzial
    {
        public List<Jednostka> jednoski = new List<Jednostka>();
        public List<Przedmiot> przedmioty = new List<Przedmiot>();
        public List<Student> studenci = new List<Student>();
        public void DodajJednostke(string nazwa, string adres)
        {
            jednoski.Add(new Jednostka(nazwa, adres));
        }
        public void DodajPrzedmiont(Przedmiot p)
        {
            przedmioty.Add(p);
        }
        public void DodajStudenta(Student s)
        {
            studenci.Add(s);
        }
        public bool DodajWykladowce(Wykladowca w, string jednostka)
        {
            for (int i = 0; i < jednoski.Count; i++)
            {
                if (jednoski[i].Nazwa == jednostka)
                {
                    jednoski[i].DodajWykladowce(w);
                }
            }
            return true;
        }
        public void InfoStudenci(bool infoOceny)
        {
            if (studenci.Count == 0)
            {
                Console.WriteLine("Brak studenotow na Wydziale!");
            }
            else
            {
                if (infoOceny == false)
                {
                    for (int i = 0; i < studenci.Count; i++)
                    {
                        studenci[i].WypiszInfo();
                    }
                }
                else if (infoOceny == true)
                {
                    for (int i = 0; i < studenci.Count; i++)
                    {
                        studenci[i].WypiszInfo();
                        studenci[i].InfoOceny();
                    }
                }
            }
        }
        public void InfoJednostki(bool infoWykladowcy)
        {
            if (jednoski.Count == 0)
            {
                Console.WriteLine("Brak jednostek na Wydziale!");
            }
            else
            {
                if (infoWykladowcy == false)
                {
                    for (int i = 0; i < jednoski.Count; i++)
                    {
                        jednoski[i].WypiszInfo();
                    }
                }
                else if (infoWykladowcy == true)
                {
                    for (int i = 0; i < jednoski.Count; i++)
                    {
                        jednoski[i].InfoWykladowcy();
                        

                    }
                }
            }
        }
        public void InfoPrzedmioty()
        {
            for (int i = 0; i < przedmioty.Count; i++)
            {
                przedmioty[i].WypiszInfo();
            }
        }
        public bool DodajOcene(int nrIndeksu, Przedmiot nazwaPrzedmiotu, int ocena, string data)
        {
            for (int i = 0; i < studenci.Count; i++)
            {
                if (nrIndeksu == studenci[i].NrIndeksu)
                {
                    studenci[i].DodajOcene(nazwaPrzedmiotu, ocena, data);
                    return true;
                }
            }

            return false;

        }
        public bool UsunStudenta(int nrIndeksu)
        {
            for (int i = 0; i < studenci.Count; i++)
            {
                if (studenci[i].NrIndeksu == nrIndeksu)
                {
                    studenci.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool PrzeniesWykladowce(Wykladowca w, string obecnaJednostka, string nowaJednostka)
        {
            for (int i = 0; i < jednoski.Count; i++)
            {
                if (jednoski[i].Nazwa == obecnaJednostka)
                {
                    jednoski[i].UsunWykladowce(w);
                }
            }
            for (int i = 0; i < jednoski.Count; i++)
            {
                if (jednoski[i].Nazwa == nowaJednostka)
                {
                    jednoski[i].DodajWykladowce(w);
                    return true;
                }
            }
            return false;
        }


        class Program
        {
            static void Main(string[] args)
            {
                Student s1 = new Student("kan", "jan", "21.02.1998", "IT", "API", 3, 2, 2121);

                s1.WypiszInfo();
                Przedmiot p = new Przedmiot("Inf", "IT", "API", 3, 2);
                s1.DodajOcene(p, 5.0, "02.03.2019");
                s1.InfoOceny();
                Wykladowca w1 = new Wykladowca("Jakub", "Kana", "02.02.1990", "Profesor", "drektor");
                w1.WypiszInfo();
                Jednostka jed = new Jednostka("Politechnika", "Dabrowskiego");
                jed.DodajWykladowce(w1);
                jed.WypiszInfo();
                jed.InfoWykladowcy();        
                Wydzial wydzial = new Wydzial();
                wydzial.DodajJednostke("Politechnika", "Dabrowskiego");
                wydzial.DodajPrzedmiont(p);
                wydzial.DodajStudenta(s1);
                wydzial.DodajWykladowce(w1, "Politechnika");
                wydzial.InfoStudenci(false);
                wydzial.InfoJednostki(true);
                wydzial.InfoJednostki(false);
                wydzial.InfoPrzedmioty();
                wydzial.DodajOcene(2121,p,5, "21.03.2019");
                wydzial.InfoStudenci(true);
                wydzial.UsunStudenta(2121);
                wydzial.InfoStudenci(true);
                wydzial.DodajJednostke("Ami", "Zana");
                wydzial.PrzeniesWykladowce(w1, "Politechnika", "Ami");
                wydzial.InfoJednostki(false);
                Console.ReadKey();


            }
        }
    }
}