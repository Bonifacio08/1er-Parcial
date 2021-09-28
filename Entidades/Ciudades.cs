using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen1.Entidades
{
    public class Ciudades
    {
        [Key]
        public int CiudadID { get; set; }
        public string NombreCiudad { get; set; }
    }
}
