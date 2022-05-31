// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string[] descripcion = {"limpiar","cargar","despachar","descansar"};

List<tarea> tareasPendientes = new  List<tarea>();
List<tarea> tareasRealizadas = new  List<tarea>();
List<tarea> tareasBuscadas = new  List<tarea>();

int cantidadTareas=5; 
var rnd = new Random();
//CARGA DE TAREAS
for(int i=1; i<=cantidadTareas; i++)
{
    tarea T = new tarea();
    T.id = i;
    
    T.descripcion = descripcion[rnd.Next(0,3)];
    T.duracion = rnd.Next(10,100);

    tareasPendientes.Add(T);

}
foreach (tarea item in tareasPendientes)
{
    item.mostrarTarea();    
}

//REVISION DE TAREAS
Console.WriteLine("\n\tREVISION DE TAREAS");
foreach (tarea item in tareasPendientes)
{
    item.mostrarTarea();
    Console.WriteLine("\n----Se realizo la tarea? 1--SI 0--NO ");
    int opcion = Convert.ToInt32(Console.ReadLine());
    if(opcion==1){
        tareasRealizadas.Add(item);
    }
}

tareasPendientes = tareasPendientes.Except(tareasRealizadas).ToList(); //elimino las tareas pendientes que pasaron a realizadas
//se lee tareas pendientes va a ser igual a tareas pendientes excepto las tareas realizadas contenidas en tareas pendientes, y luego castea a lista porque except no es de lista
//duda: que pasa si en una segunda vuelta, tengo un tareasRealizadas con mas elementos que pendientes, funciona el except?
//MOSTRAR TAREAS REALIZADAS Y PENDIENTES
Console.WriteLine("\nLAS TAREAS REALIZADAS SON: ");
foreach(tarea item in tareasRealizadas){
    item.mostrarTarea();
}
Console.WriteLine("\nLAS TAREAS PENDIENTES SON: ");
foreach (tarea item in tareasPendientes)
{
    item.mostrarTarea();    
}

//BUSQUEDA DE TAREAS:

Console.WriteLine("\ningrese una descripcion para buscar la tarea: ");
string busqueda = Console.ReadLine();

foreach(tarea T in tareasPendientes){
    if(T.descripcion.Contains(busqueda)){
        tareasBuscadas.Add(T);
    }
}

foreach (tarea item in tareasBuscadas)
{
    item.mostrarTarea();
}


