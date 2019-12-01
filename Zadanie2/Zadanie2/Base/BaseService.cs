using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie2.Models;
using Zadanie2.Models.Nhibernate;

namespace Zadanie2.Base
{
    public class BaseService
    {

        public void DodajDoKoszyka(int id, int ilosc)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(new Produkt()
                    {
                        IdProduktu = id,
                        IloscProduktu = ilosc
                    });
                    transaction.Commit();
                }
            }
        }
        public void UsunZKoszyka(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Produkt produkt = session.Get<Produkt>(id);
                    session.Delete(produkt);
                    transaction.Commit();
                }
            }
        }
        public Dictionary<int,int> PobierzKoszyk()
        {
            Dictionary<int, int> slownik = new Dictionary<int, int>();
            using (ISession session = NHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    slownik = session.Query<Produkt>().ToList().ToDictionary(x => x.IdProduktu, x => x.IloscProduktu);
                }
            }
            return slownik;
        }
    }
}