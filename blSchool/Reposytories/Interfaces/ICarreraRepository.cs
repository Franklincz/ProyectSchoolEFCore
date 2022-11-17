using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blSchool.Reposytories.Interfaces
{
    public interface ICarreraRepository
    {
        public void AddCarrera(Carrera carrera);
        public void UpdateCarrera(Carrera carrera);
        
       public void DeleteCarrera(int carreraId);
        public Carrera GetCarreraById(int CarreraId, bool conCourses);
        public List<Carrera> GetAllCarreras();   




    }
}
