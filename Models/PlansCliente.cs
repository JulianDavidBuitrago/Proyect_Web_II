namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlansCliente")]
    public partial class PlansCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPlansClie { get; set; }

        public int IdClie { get; set; }

        public int IdPlans { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaPlansCliente { get; set; }

        public int NumPersonasPlansClie { get; set; }

        public int ValorPlansClie { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Plans Plans { get; set; }
    }
}
