using blSchool;
using blSchool.Reposytories.NewFolder;

namespace proyectSchool
{
    public static class Menu
    {

        public static void MenuCarreras(SchoolContext context)


        {
            int opcion = 0;
            bool valida = false;
            int indice = 0;
            CarreraRepository repoCarrera = new CarreraRepository(context);
            List<Carrera> ListCarreras = new List<Carrera>();

            do
            {

                Console.WriteLine("Menu Carreras");
                Console.WriteLine();
                Console.WriteLine("1.Agrega");
                Console.WriteLine("2.Modifica");
                Console.WriteLine("3.Elimina");
                Console.WriteLine("4.Agregar Materia  courses");
                Console.WriteLine("5.Ver Lista");
                Console.WriteLine("6.Ver una carrera con sus materias");
                Console.WriteLine("20.Salir");

                do
                {

                    valida = int.TryParse(Console.ReadLine(), out opcion);




                } while (!valida || opcion < 1 || opcion > 20);

                switch (opcion)
                {
                    case 1:
                        Carrera carrera = new Carrera();
                        PideDatos(carrera, false);
                        repoCarrera.AddCarrera(carrera);
                        break;
                    case 2:
                        ListCarreras = repoCarrera.GetAllCarreras();
                        printLista(ListCarreras);
                        Console.WriteLine("Dame el indice de la carrera a modificar");
                        indice= Convert.ToInt32(Console.ReadLine());
                        carrera = new Carrera();
                        carrera = ListCarreras[indice]; 
                        break;


                    case 3:
                        ListCarreras = repoCarrera.GetAllCarreras();
                        printLista(ListCarreras);
                        Console.WriteLine("Dame el indice de la carrera a eliminar:");
                        indice = Convert.ToInt32(Console.ReadLine());
                        repoCarrera.DeleteCarrera(ListCarreras[indice].CarreraId);
                        break;

                    case 4:
                        carrera = new Carrera();
                        PideDatos(carrera, false);
                        carrera.Courses = new List<Course>();
                        string nombreMateria = "";
                        do
                        {
                            Console.WriteLine("Dame el nombre de la materia:");
                            nombreMateria = Console.ReadLine();
                            if (nombreMateria != "")
                            {
                                Course materia = new Course();
                                materia.nombre = nombreMateria;
                                Console.WriteLine("Dame el semestre de la materia:");
                                materia.Semestre = Convert.ToInt32(Console.ReadLine());
                                materia.CourseRequisitoId = 0;
                                
                                carrera.Courses.Add(materia);
                            }
                        } while (nombreMateria != "");
                        repoCarrera.AddCarrera(carrera);
                        break;







                    case 5:
                        ListCarreras = repoCarrera.GetAllCarreras();
                        printLista(ListCarreras);
                        break;


                    case 6:
                        ListCarreras = repoCarrera.GetAllCarreras();
                        printLista(ListCarreras);
                        Console.WriteLine("Dame el indice de la carrera a mostrar con sus materias:");
                        indice = Convert.ToInt32(Console.ReadLine());
                        carrera = repoCarrera.GetCarreraById(ListCarreras[indice].CarreraId, true);
                        Console.WriteLine("carrera: " + carrera.Nombre);
                        foreach (Course item in carrera.Courses)
                        {
                            Console.WriteLine("materia: " + item.nombre);
                        }
                        break;
                    default:
                        break;

                }


            } while (opcion != 20);
        }


        private static void printLista(List<Carrera> carreras)
        {
            for(int i = 0; i < carreras.Count; i++)
            {
                Console.WriteLine("Indice : " + i.ToString() + "Nombre" + carreras[i].Nombre);
            }

        }


        public static void MuestraMateriasDepende(SchoolContext context)
        {
            CarreraRepository repoCarrera = new CarreraRepository(context);
            List<Carrera> Carreras = repoCarrera.GetAllCarreras();
            printLista(Carreras);
            Console.WriteLine("Dame el indice de la carrera de las materias a mostrar:");
            int indice = Convert.ToInt32(Console.ReadLine());
            CourseRepository repoMateria = new MateriaRepositorio(bd);
            List<clsMateriasDepende> materias = new List<clsMateriasDepende>();
            materias = repoMateria.ObtenRelacionadas(Carreras[indice].CarreraId);
            Console.WriteLine("Materia\t\t\tSemestre\t\t\tDepende de\t\t\tSemestre");
            foreach (var item in materias)
            {
                Console.WriteLine(item.NombreMateria + "\t" + item.Semestre.ToString() +
                                    "\t\t" + item.NombreMateriaDepende + "\t" +
                                    item.SemestreMateriaDepende.ToString());
            }
        }
















        private static void PideDatos(Carrera carrera, bool v)
        {
            Console.WriteLine("Nombre de carrera: ");
            carrera.Nombre = Console.ReadLine();
            Console.WriteLine("Plan  de carrera: ");
            carrera.Plan = Console.ReadLine();
            Console.WriteLine("Semestre INiciio: ");
            carrera.SemestreInicial = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Semestre Fin: ");
            carrera.SemestreFinal = Convert.ToInt32(Console.ReadLine());
        }
    }
}
