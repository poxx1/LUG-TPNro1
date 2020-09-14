
namespace BE
{
    public class Localidades
    {
        public int ID_Localidad { get; set; }
        public string Nombre_Localidad { get; set; }

        //Sobreescribis el metodo
        public override string ToString()
        {
            return ID_Localidad + " " + Nombre_Localidad;
        }
    }
}
