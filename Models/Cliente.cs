namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            PlansCliente = new HashSet<PlansCliente>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdClie { get; set; }

        [Required]
        [StringLength(20)]
        public string NombreClie { get; set; }

        [Required]
        [StringLength(15)]
        public string TelefonoClie { get; set; }

        [Required]
        [StringLength(20)]
        public string DireccionClie { get; set; }

        [Required]
        [StringLength(20)]
        public string CiudadClie { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacClie { get; set; }

        [Required]
        [StringLength(50)]
        public string CorreoClie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlansCliente> PlansCliente { get; set; }
    }
}
