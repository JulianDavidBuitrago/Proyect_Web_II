namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehiculo")]
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            ParqueadreoVehiculo = new HashSet<ParqueadreoVehiculo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVehi { get; set; }

        [Required]
        [StringLength(20)]
        public string MarcaVehi { get; set; }

        [Required]
        [StringLength(20)]
        public string PlacaVehi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParqueadreoVehiculo> ParqueadreoVehiculo { get; set; }
    }
}
