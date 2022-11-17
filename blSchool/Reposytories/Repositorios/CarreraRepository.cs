using blSchool.Reposytories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blSchool.Reposytories.NewFolder
{
    public class CarreraRepository : ICarreraRepository
    {

        private SchoolContext _context;


        public CarreraRepository(SchoolContext context)
        {
            this._context = context;
        }

        public void AddCarrera(Carrera carrera)
        {
           _context.Carrera.Add(carrera);
            _context.SaveChanges();
        }
            
        public void DeleteCarrera(int carreraId)
        {
            Carrera carrera = _context.Carrera.Find(carreraId);
            if(carrera != null)
            {
                _context.Carrera.Remove(carrera);
                _context.SaveChanges();
            }
        }

        public List<Carrera> GetAllCarreras()
        {
            return _context.Carrera.ToList();
        }

        public Carrera GetCarreraById(int CarreraId,bool conCourses)
        {
            Carrera carrera = _context.Carrera.Find(CarreraId);
            if (conCourses)
            
                _context.Entry(carrera).Collection("Courses").Load();
            

            return carrera;
        }

        public void UpdateCarrera(Carrera carrera)
        {
            Carrera nowCarrera = _context.Carrera.Find(carrera.CarreraId);
            nowCarrera.Nombre=carrera.Nombre;
            nowCarrera.Plan = carrera.Plan;
            nowCarrera.SemestreInicial = carrera.SemestreInicial;
            nowCarrera.SemestreFinal = carrera.SemestreFinal;
            _context.SaveChanges();

        }
    }
}
