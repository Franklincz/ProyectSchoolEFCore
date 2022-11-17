using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blSchool
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

           
        }

        public DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Course> Course { get; set; }


        public virtual DbSet<Alumno> Alumnos { get; set; }
    } 

}
        

