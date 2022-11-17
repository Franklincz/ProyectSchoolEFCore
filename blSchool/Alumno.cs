using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blSchool
{

    [Table("Alumno",Schema ="dbo")]
    public class Alumno
    {


        public int AlumnoId { get; set; }

        public string Nombres { get; set; }


        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }


        public Carrera Carrera { get; set; }


        public int CarreraId { get; set; }
        public int SemestreActual { get; set; }

        public int Estatus { get; set; }




    }
}
