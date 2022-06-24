// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();
Random rnd = new Random();

char salida;
int num = 1;
char realizosn;


Console.WriteLine("\n----------CARGA DE TAREAS----------");

do
{
    Console.WriteLine($"\n----------Tarea [{num}]----------");

    cargarTareas(num);

    Console.WriteLine("\n¿Desea ingresar una nueva tarea?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
    salida = Char.ToLower(Convert.ToChar(Console.ReadLine()));
    while ((salida != 's') && (salida != 'n'))
    {
        Console.WriteLine("\nError de formato.\n¿Desea ingresar una nueva tarea?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
        salida = Char.ToLower(Convert.ToChar(Console.ReadLine()));
    }

    num++;

} while ((salida != 'n') && (salida != 'N'));





cambiarEstado(tareasPendientes);





void cargarTareas(int num)
{
    Tarea Ntarea = new Tarea();

    Ntarea.TareaID = num;

    Console.WriteLine("\nIngrese la descripción de la tarea: ");
    Ntarea.Descripcion = Console.ReadLine();

    Ntarea.Duracion = rnd.Next(10,100);


    tareasPendientes.Add(Ntarea);
}

void cambiarEstado(List<Tarea> listadoTareas)
{
    foreach (Tarea TareaX in listadoTareas)
    {
        TareaX.MostrarTarea();

        Console.WriteLine("\n¿Realizó la tarea?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
        realizosn = Char.ToLower(Convert.ToChar(Console.ReadLine()));

        while ((realizosn != 's') && (realizosn != 'n'))
        {
            Console.WriteLine("\nError de formato.\n¿Realizó la tarea?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
            realizosn = Char.ToLower(Convert.ToChar(Console.ReadLine()));
        }

        if((realizosn == 's') || (realizosn == 'S'))
        {
            tareasRealizadas.Add(TareaX);
            Console.WriteLine("\nTarea completada con éxito");
        }

        tareasPendientes = tareasPendientes.Except(tareasRealizadas).ToList();
    }
}