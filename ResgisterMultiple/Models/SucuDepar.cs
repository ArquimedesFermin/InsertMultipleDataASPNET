namespace ResgisterMultiple.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SucuDepar")]
    public partial class SucuDepar
    {
        public int id { get; set; }

        public int? idDepartaments { get; set; }

        public int? idSucursals { get; set; }

        public virtual departament departament { get; set; }

        public virtual sucursal sucursal { get; set; }
    }
}
