namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trabajador")]
    public partial class Trabajador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTrab { get; set; }

        public int IdZona { get; set; }

        [Required]
        [StringLength(20)]
        public string NombreTrab { get; set; }

        [Required]
        [StringLength(15)]
        public string TelefonoTrab { get; set; }

        [Required]
        [StringLength(20)]
        public string DireccionTrab { get; set; }

        [Required]
        [StringLength(50)]
        public string CorreoTrab { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoSangreTrab { get; set; }

        public virtual Zona Zona { get; set; }
    }
}
