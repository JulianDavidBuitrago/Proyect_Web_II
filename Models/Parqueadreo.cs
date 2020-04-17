namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parqueadreo")]
    public partial class Parqueadreo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parqueadreo()
        {
            ParqueadreoVehiculo = new HashSet<ParqueadreoVehiculo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPar { get; set; }

        public int IdZooPar { get; set; }

        [Required]
        [StringLength(20)]
        public string TelefonoPar { get; set; }

        public int ValorHora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParqueadreoVehiculo> ParqueadreoVehiculo { get; set; }

        public virtual Zoologico Zoologico { get; set; }
    }
}
