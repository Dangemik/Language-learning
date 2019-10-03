using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Student
    {
        public string Imie { set; get; }
        public string Nazwisko { set; get; }
        public int Nr_indeksu { set; get; }
        public string Kierunek { set; get; }



        public Student(string Imie,string Nazwisko, int Nr_indeksu, string Kierunek)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.Nr_indeksu = Nr_indeksu;
            this.Kierunek = Kierunek;
        }


    }
}
