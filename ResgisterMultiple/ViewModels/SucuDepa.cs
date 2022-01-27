using ResgisterMultiple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResgisterMultiple.ViewModels
{
    public class SucuDepa
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Departament { get; set; }
        public List<departament> Departamets { get; set; }
        public List<sucursal> Sucursals { get; set; }
    }
}