using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blSchool
{

 //[Table("Carrera", Schema ="dbo")]
    public class Carrera



    {


        public int CarreraId { get; set; }

        [MaxLength(500), Required]
        public string Nombre { get; set; }
        public string Plan { get; set; }

        public int SemestreInicial { get; set; }

        public int SemestreFinal { get; set; }
        public ICollection<Course> Courses { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }
    }
}
