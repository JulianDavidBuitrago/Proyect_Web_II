namespace ZOOLO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Plans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plans()
        {
            PlansCliente = new HashSet<PlansCliente>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPlans { get; set; }

        public int IdZooPlans { get; set; }

        [Required]
        [StringLength(20)]
        public string ZonaPlans { get; set; }

        public int ValorPlans { get; set; }

        [Required]
        [StringLength(50)]
        public string ZonaAdicPlans { get; set; }

        public virtual Zoologico Zoologico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlansCliente> PlansCliente { get; set; }
    }
}
