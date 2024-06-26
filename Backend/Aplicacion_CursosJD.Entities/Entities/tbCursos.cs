﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Aplicacion_CursosJD.Entities.Entities
{
    public partial class tbCursos
    {
        public tbCursos()
        {
            tbCusrsosPorUsuario = new HashSet<tbCusrsosPorUsuario>();
            tbInstructoresPorCurso = new HashSet<tbInstructoresPorCurso>();
            tbRecursos = new HashSet<tbRecursos>();
        }

        public int Cur_Id { get; set; }
        public string Cur_Nombre { get; set; }
        public int Cat_Id { get; set; }
        public int Cur_UsuarioCreacion { get; set; }
        public DateTime Cur_FechaCreacion { get; set; }
        public int? Cur_UsuarioModificacion { get; set; }
        public DateTime? Cur_FechaModificacion { get; set; }
        public bool? Cur_Estado { get; set; }

        public virtual tbCategorias Cat { get; set; }
        public virtual tbUsuarios Cur_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Cur_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbCusrsosPorUsuario> tbCusrsosPorUsuario { get; set; }
        public virtual ICollection<tbInstructoresPorCurso> tbInstructoresPorCurso { get; set; }
        public virtual ICollection<tbRecursos> tbRecursos { get; set; }
    }
}