using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blSchool
{
  //  [Table("Course", Schema = "dbo")]
    public class Course
    {
        public int CourseId { get; set; }

        [MaxLength(500),Required]
        public String nombre { get; set; }
        
        public int CarreraId { get; set; }



        public Carrera Carrera { get; set; }

        public int Semestre { get; set; }

        public int CourseRequisitoId { get; set; }


    }
}
