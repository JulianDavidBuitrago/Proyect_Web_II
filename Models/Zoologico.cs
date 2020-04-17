namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zoologico")]
    public partial class Zoologico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zoologico()
        {
            Parqueadreo = new HashSet<Parqueadreo>();
            Plans = new HashSet<Plans>();
            Zona = new HashSet<Zona>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdZoo { get; set; }

        [Required]
        [StringLength(20)]
        public string NombreZoo { get; set; }

        [Required]
        [StringLength(20)]
        public string DireccionZoo { get; set; }

        [Required]
        [StringLength(15)]
        public string TelefonoZoo { get; set; }

        [Required]
        [StringLength(50)]
        public string CorreoZoo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parqueadreo> Parqueadreo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plans> Plans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zona> Zona { get; set; }
    }
}
