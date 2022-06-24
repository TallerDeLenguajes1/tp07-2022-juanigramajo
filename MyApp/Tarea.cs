


public class Tarea
{
    private int tareaID;
    private string descripcion;
    private int duracion;

    public int TareaID { get => tareaID; set => tareaID = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }



    public void MostrarTarea()
    {
        Console.WriteLine($"\n\n-------------------------------------");
        Console.WriteLine($"\nTarea [{tareaID}]");
        Console.WriteLine($"\nDescripción: {descripcion}");
        Console.WriteLine($"\nDuración: {duracion}");
    }
}

