// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();
Random rnd = new Random();

char salida;
int num = 1;
char realizosn;
int hsTrabajadas = 0;


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

} while ((salida != 'n'));



// main ahre

cambiarEstado(tareasPendientes);
Console.WriteLine($"\n\n-------------------------------------");
Console.WriteLine($"\n\nSumario de horas trabajadas: " + hsTrabajadas);
busqueda(tareasPendientes);




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

        if((realizosn == 's'))
        {
            tareasRealizadas.Add(TareaX);
            Console.WriteLine("\nTarea completada con éxito");
            hsTrabajadas = hsTrabajadas + TareaX.Duracion;
        }

        tareasPendientes = tareasPendientes.Except(tareasRealizadas).ToList();
    }
}

void busqueda(List<Tarea> listadoTareas)
{
    int controller = 0;

    Console.WriteLine($"\n\n-------------------------------------");
    Console.WriteLine("\n\n¿Quiere buscar una tarea pendiente?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
    char buscarsn = Char.ToLower(Convert.ToChar(Console.ReadLine()));

    while ((buscarsn != 's') && (buscarsn != 'n'))
    {
        Console.WriteLine("\nError de formato.\n¿Quiere buscar una tarea pendiente?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
        buscarsn = Char.ToLower(Convert.ToChar(Console.ReadLine()));
    }

    while(buscarsn == 's')
    {
        Console.WriteLine("\nIngrese una descripcion de la tarea pendiente que busca: ");
        string descBusqueda = Console.ReadLine();

        foreach(Tarea tareabuscar in listadoTareas)
        {
            if(tareabuscar.Descripcion.Contains(descBusqueda))
            {
                Console.WriteLine($"\n\n-------------------------------------");
                Console.WriteLine($"\nTareas encontradas:");
                tareabuscar.MostrarTarea();
                controller++;
                buscarsn = buscarOtra();
            }
        }

        if (controller == 0)
        {
            Console.WriteLine("\n\n\nNo hay tareas pendientes con esa descripción");
            buscarsn = buscarOtra();
        }
    }

    Console.WriteLine($"\n\nSee ya soon!\n");
}


char buscarOtra(){

    Console.WriteLine("\n¿Quiere buscar otra tarea pendiente?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
    char buscarsn = Char.ToLower(Convert.ToChar(Console.ReadLine()));

    while ((buscarsn != 's') && (buscarsn != 'n'))
    {
        Console.WriteLine("\nError de formato.\n¿Quiere buscar otra tarea pendiente?\nOPCIONES:\n[S] SI\n[N] NO\nIngrese una opción: ");
        buscarsn = Char.ToLower(Convert.ToChar(Console.ReadLine()));
    }

    return buscarsn;
}