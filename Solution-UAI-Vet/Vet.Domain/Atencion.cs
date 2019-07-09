﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Services;

namespace Vet.Domain
{
   public partial class Atencion : IEntity
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public int IdSala { get; set; }
        public Doctor Doctor { get; set; }
        public Sala Sala { get; set; }
        public SharedKernel.TipoEspecialidad TipoEspecialidad
        {
            get
            {
                return TipoEspecialidad;
            }
   
            set
            {
                TipoEspecialidad = Doctor.TipoEspecialidad;
            }
            
        }
        public SharedKernel.HorarioTurno HorarioTurno { get; set; }
      
    }


    [MetadataType(typeof(AtencionMetadata))]

    public partial class Atencion
    {
        public class AtencionMetadata
        {
            [Key]
            [Column(Order = 1)]
            public int Id { get; set; }
            [ForeignKey("Doctor")]
            [Column(Order = 2)]
            [Required]
            public int IdDoctor { get; set; }
            [ForeignKey("Sala")]
            [Column(Order = 3)]
            [Required]
            public int IdSala { get; set; }
            [Required]
            public SharedKernel.TipoEspecialidad TipoEspecialidad { get; set; }
            [Required]
            public SharedKernel.HorarioTurno HorarioTurno { get; set; }
        }
    }
}