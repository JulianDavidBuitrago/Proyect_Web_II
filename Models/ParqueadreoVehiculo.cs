namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ParqueadreoVehiculo")]
    public partial class ParqueadreoVehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdParqueadreoVehiculo { get; set; }

        public int IdPar { get; set; }

        public int IdVehi { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaEntradaParVehi { get; set; }

        public TimeSpan HoraEntradaParVehi { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaSalidaParVehi { get; set; }

        public TimeSpan HoraSalidaParVehi { get; set; }

        public int NumPersonasPlansClie { get; set; }

        public int ValorPlansClie { get; set; }

        public virtual Parqueadreo Parqueadreo { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
    }
}
