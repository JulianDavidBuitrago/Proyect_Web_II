namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cita")]
    public partial class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCita { get; set; }

        public int IdAnimCita { get; set; }

        public int IdVeteCita { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaCita { get; set; }

        public TimeSpan HoraCita { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual Veterinario Veterinario { get; set; }
    }
}
