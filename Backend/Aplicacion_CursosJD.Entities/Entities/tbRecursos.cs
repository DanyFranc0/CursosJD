﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Aplicacion_CursosJD.Entities.Entities
{
    public partial class tbRecursos
    {
        public int Rec_Id { get; set; }
        public int Cur_Id { get; set; }
        public int? TpR_Id { get; set; }
        public string Rec_Nombre { get; set; }
        public string Rec_Url { get; set; }
        public int Rec_UsuarioCreacion { get; set; }
        public DateTime Rec_FechaCreacion { get; set; }
        public int? Rec_UsuarioModificacion { get; set; }
        public DateTime? Rec_FechaModificacion { get; set; }
        public bool? Rec_Estado { get; set; }

        public virtual tbCursos Cur { get; set; }
        public virtual tbUsuarios Rec_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Rec_UsuarioModificacionNavigation { get; set; }
        public virtual tbTiposRecursos TpR { get; set; }
    }
}