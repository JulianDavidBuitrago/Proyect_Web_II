//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZOO_PROYECT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ParqueadreoVehiculo
    {
        public int IdParqueadreoVehiculo { get; set; }
        public int IdPar { get; set; }
        public int IdVehi { get; set; }
        public System.DateTime FechaEntradaParVehi { get; set; }
        public System.TimeSpan HoraEntradaParVehi { get; set; }
        public System.DateTime FechaSalidaParVehi { get; set; }
        public System.TimeSpan HoraSalidaParVehi { get; set; }
        public int NumPersonasPlansClie { get; set; }
        public int ValorPlansClie { get; set; }
    
        public virtual Parqueadreo Parqueadreo { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}