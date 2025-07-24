using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaBlogsPersonales.Model.Models
{
    public abstract class EntidadBase
    {
        [Key]
        [Column("ID")]
        public virtual Guid Id { get; set; }

        [Column("FECHA_CREACION")]
        [DataType(DataType.DateTime)]
        public virtual DateTime FechaCreacion { get; set; }

        [Column("USUARIO_CREACION")]
        [DataType(DataType.Text)]
        [MaxLength(150, ErrorMessage = "El valor ingresado supera los 150 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el usuario de creación")]
        public virtual string UsuarioCreacion { get; set; }


        [Column("FECHA_ACTUALIZACION")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? FechaActualizacion { get; set; }

        [Column("USUARIO_ACTUALIZACION")]
        [DataType(DataType.Text)]
        [MaxLength(150, ErrorMessage = "El valor ingresado supera los 150 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el usuario de actualización")]
        public virtual string? UsuarioActualizacion { get; set; }

        [Column("REGISTRO_ELIMINADO")]
        public virtual bool RegistroEliminado { get; set; } = false;

        [Column("FECHA_ELIMINACION")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? FechaEliminacion { get; set; }

        [Column("USUARIO_ELIMINACION")]
        [DataType(DataType.Text)]
        [MaxLength(150, ErrorMessage = "El valor ingresado supera los 150 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el usuario de eliminación")]
        public virtual string? UsuarioEliminacion { get; set; }


    }
}
