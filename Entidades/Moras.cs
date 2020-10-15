using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPrestamos.Entidades
{
    public class Moras
    {
        [Key] 
        public int MoraId{ get; set;}

        public DateTime FechaMora{ get; set;}

        public float Total{ get; set;}

        [ForeignKey("MoraId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();


        
    }

}