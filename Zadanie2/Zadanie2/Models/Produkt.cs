using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadanie2.Models
{
    public class Produkt
    {
        [Required(ErrorMessage = "Prosze wpisać id produktu")]
        public virtual int IdProduktu { get; set; }
        [Required(ErrorMessage = "Prosze wpisac ilość produktów")]
        public virtual int IloscProduktu { get; set; }
    }
}