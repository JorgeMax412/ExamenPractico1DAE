using System;

namespace Examen_practico_1_DAE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Menu Principal:\n");
                Console.WriteLine("1- Costo de llamadas telefonicas");
                Console.WriteLine("2- Gestion de libros");
                Console.WriteLine("3- Salir");
                Console.Write("Seleccione una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CostoLlamadas();
                        break;
                    case "2":
                        GestionLibros();
                        break;
                    case "3":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Intente de nuevo");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPulse Enter para regresar al menu principal");
                    Console.ReadLine();
                }
            }
        }

        static void CostoLlamadas()
        {
            int[] clavesZonas = { 12, 15, 18, 19, 23 };
            double[] preciosPorMinuto = { 2.0, 2.2, 4.5, 3.5, 6.0 };

            bool claveValida = false;
            int claveZona = 0;

            Console.Clear();
            Console.WriteLine("Costo de llamadas telefonicas\n");

            while (!claveValida)
            {
                Console.WriteLine("Ingrese la clave de la zona: ");
                if (int.TryParse(Console.ReadLine(), out claveZona))
                {
                    if (Array.IndexOf(clavesZonas, claveZona) >= 0)
                    {
                        claveValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Clave de zona no valida. Por favor ingrese una clase de zona valida");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no valida. Por favor ingrese un numero entero como clave de zona");
                }
            }

            Console.WriteLine("Ingrese la cantidad de minutos hablados: ");
            double minutosHablados = double.Parse(Console.ReadLine());

            int indice = Array.IndexOf(clavesZonas, claveZona);
            double precioPorMinuto = preciosPorMinuto[indice];

            double costoTotal = minutosHablados * precioPorMinuto;

            Console.WriteLine($"El costo total de la llamada es: {costoTotal:C}");
        }

        public class Libro {
            public int Codigo { get; set; }
            public string Titulo { get; set; }
            public string ISBN { get; set; }
            public string Edicion { get; set; }
            public string Autor { get; set; }

        }
        static void GestionLibros()
        {
            Console.Clear();
            int maxLibros = 100;
            int cantidadLibros = 0;
            Libro[] libros = new Libro[maxLibros];

            while (true)
            {
                Console.WriteLine("Gestion de Libros\n");
                Console.WriteLine("1- Agregar un libro");
                Console.WriteLine("2- Mostrar todos los libros");
                Console.WriteLine("3- Buscar libro por codigo");
                Console.WriteLine("4- Editar libro por codigo");
                Console.WriteLine("5- Salir");
                Console.Write("Seleccione una opcion: ");

                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            if (cantidadLibros < maxLibros)
                            {
                                Console.WriteLine($"Informacion del libro {cantidadLibros + 1}");

                                Libro libro = new Libro();

                                Console.Write("Ingrese el codigo del libro: ");
                                libro.Codigo = int.Parse(Console.ReadLine());

                                Console.Write("Ingrese el titulo del libro: ");
                                libro.Titulo = (Console.ReadLine());

                                Console.Write("Ingrese el ISBN del libro: ");
                                libro.ISBN = (Console.ReadLine());

                                Console.Write("Ingrese la edicion del libro: ");
                                libro.Edicion = (Console.ReadLine());

                                Console.Write("Ingrese el autor del libro: ");
                                libro.Autor = (Console.ReadLine());

                                libros[cantidadLibros] = libro;
                                cantidadLibros++;

                                Console.WriteLine("Libro agregado exitosamente");
                            }
                            else
                            {
                                Console.WriteLine("Cantidad de libros maxima. No se pueden agregar mnas");
                            }
                            break;

                        case 2:
                            Console.Clear();
                            if (cantidadLibros > 0)
                            {
                                Console.WriteLine("Informacion de libros ingresada:");
                                Console.WriteLine("-----------------------------------------------------------------------");
                                Console.WriteLine("| Codigo |   Título   |     ISBN     |   Edicion   |     Autor     |");
                                Console.WriteLine("-----------------------------------------------------------------------");
                                for (int i = 0; i < cantidadLibros; i++)
                                {
                                    Console.WriteLine($"| {libros[i].Codigo,-6} | {libros[i].Titulo,-10} | {libros[i].ISBN,-13} | {libros[i].Edicion,-12} | {libros[i].Autor,-13} |");

                                }
                                Console.WriteLine("-----------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("No hay libros para mostrar :c\n");
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write("Ingrese el codigo del libro: ");
                            int coodigoBuscar = int.Parse(Console.ReadLine());
                            bool encontrado = false;

                            Console.WriteLine("Informacion de libros ingresada:");
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine("| Codigo |   Título   |     ISBN     |   Edicion   |     Autor     |");
                            Console.WriteLine("-----------------------------------------------------------------------");

                            for (int i = 0; i < cantidadLibros; i++)
                            { 
                                if (libros[i].Codigo == coodigoBuscar)
                                {
                                    Console.WriteLine($"| {libros[i].Codigo,-6} | {libros[i].Titulo,-10} | {libros[i].ISBN,-13} | {libros[i].Edicion,-12} | {libros[i].Autor,-13} |");
                                    encontrado = true; break; 
                                }
                            }
                            Console.WriteLine("-----------------------------------------------------------------------");
                            if (!encontrado)
                            {
                                Console.WriteLine("Libro no encontrado.\n");
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Ingrese el codigo del libro que desea buscar: ");
                            int codigoEditar = int.Parse(Console.ReadLine());
                            bool encontradoEditar = false;

                            for (int i = 0; i < cantidadLibros; i++)
                            {
                                if (libros[i].Codigo == codigoEditar)
                                {
                                    Console.WriteLine("Ingrese los nuevos datos: ");

                                    Console.Write("Nuevo titulo: ");
                                    libros[i].Titulo = Console.ReadLine();

                                    Console.Write("Nuevo ISBN: ");
                                    libros[i].ISBN = Console.ReadLine();

                                    Console.Write("Nueva edicion: ");
                                    libros[i].Edicion = Console.ReadLine();

                                    Console.Write("Nuevo Autor: ");
                                    libros[i].Autor = Console.ReadLine();

                                    Console.WriteLine("Libro editado exitosamente\n");
                                    encontradoEditar = true;
                                    break;

                                }
                            }
                            if (!encontradoEditar)
                            {
                                Console.WriteLine("Libro no encontrado\n");
                            }
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Saliendo del programa");
                            return;

                        default:
                            Console.WriteLine("Opcion no valida. Por favor seleccione una opcion valida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor ingrese un numero valido");
                }
            }
        }

    }
}
