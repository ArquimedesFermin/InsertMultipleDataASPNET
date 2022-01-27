using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResgisterMultiple.Helpers.DTO
{
    public class SucuDepaDTO
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Departament { get; set; }
        public bool Exists { get; set; }
    }
}