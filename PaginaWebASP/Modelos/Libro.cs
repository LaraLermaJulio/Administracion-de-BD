using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Libro
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int Numero_Edicion { get; set; }
        public int Anio_Publicacion { get; set; }
        public string Autores { get; set; }
        public string Pais_Publicacion { get; set; }
        public string Sinopsis { get; set; }
        public string Carrera { get; set; }
        public string Materia { get; set; }

        public Libro() { }
        public Libro(int id, string isbn, string titulo, int numeroEdicion, int anioPublicacion, string autores, string paisPublicacion, string sinopsis, string carrera, string materia)
        {
            ID = id;
            ISBN = isbn;
            Titulo = titulo;
            Numero_Edicion = numeroEdicion;
            Anio_Publicacion = anioPublicacion;
            Autores = autores;
            Pais_Publicacion = paisPublicacion;
            Sinopsis = sinopsis;
            Carrera = carrera;
            Materia = materia;
        }

    }
}
