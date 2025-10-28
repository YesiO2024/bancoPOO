/*
 * Created by SharpDevelop.
 * User: Compumar
 * Date: 21/10/2025
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace tp.final
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			
			Banco miBanco = new Banco("Nombre Del Banco");
			string rutaArchivoClientes = "clientes.csv";
            string rutaArchivoCuentas="cuentas.csv";			

               
           //cargar clientes desde funcion
            CargarClientesDesdeArchivo(miBanco, rutaArchivoClientes);
               
           //cargar cuentas desde funcion
            CargarCuentasDesdeArchivo(miBanco,rutaArchivoCuentas);
            
            
           // Empezar con el menú
           
           int opcion=0 ; // Variable para guardar la opción del usuario

do 
{              
	              Console.Clear();
                
                Console.WriteLine("Operaciones bancarias");
                mostrarMenu();
                Console.Write("Ingrese una opción: ");
                opcion=Convert.ToInt32(Console.ReadLine());  
   

    switch (opcion)
    {
        case 1:
            AgregarNuevaCuenta(miBanco);
            break;
        case 2:
            // Lógica para eliminar cuenta...
            break;
        case 3:
            // Lógica para eliminar cuenta...
            break;
        case 4:
            // Lógica para eliminar cuenta...
            break;
        case 5:
            // Lógica para eliminar cuenta...
            break;
        case 6:
            // Lógica para eliminar cuenta...
            break;
        case 7:
            // Lógica para eliminar cuenta...
            break;
        case 8:
            // Lógica para eliminar cuenta...
            break;
        case 9:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("El número ingresado no representa una opcion de este menú.");
            break;
    }
   

} while (opcion != 9); // La condición: Repetir mientras la opción NO sea "x"


    		
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		
		//cargar clientes desde archivo

        public static void CargarClientesDesdeArchivo(Banco miBanco, string rutaArchivoClientes)
        {
            if (File.Exists(rutaArchivoClientes)) 
            {
            // Agregar bloque try aquí para manejar errores de archivo/formato?
                Console.WriteLine("Archivo de clientes encontrado. Cargando...");
             using(StreamReader lecturaArchivo= new StreamReader(rutaArchivoClientes))//se crea un objeto de tipo streamreader
             {
                string linea;//se declara una variable
                while( (linea= lecturaArchivo.ReadLine())!= null)//en esa variable se guarda la lectura del archivo y si es distinta de null , entra al while
                {
                	Console.WriteLine( linea);
                	string[] partes= linea.Split(',');
                	Cliente nuevoCliente = new Cliente(partes[0], partes[1], partes[2],partes[3], partes[4], partes[5]);
                	miBanco.AgregarCliente(nuevoCliente);
                    
                }
                
             }
                    Console.WriteLine("Clientes cargados.");
               List<Cliente> listaParaMostrar = miBanco.TodosLosClientes();
              }
               else
              {
                 // Si se entra aca, el archivo no existe en la carpeta de ejecución.
                Console.WriteLine("ADVERTENCIA: No se encontró el archivo 'clientes.csv' en la carpeta del programa.");
               }
        }
        
        public static void CargarCuentasDesdeArchivo(Banco miBanco,string rutaArchivoCuentas)
        { if (File.Exists(rutaArchivoCuentas))
        	{
        		    Console.WriteLine("Archivo de clientes encontrado. Cargando...");
             using(StreamReader lecturaCuentas= new StreamReader(rutaArchivoCuentas))//se crea un objeto de tipo streamreader
             {
                string linea;//se declara una variable
                while( (linea=lecturaCuentas.ReadLine())!= null)//en esa variable se guarda la lectura del archivo y si es distinta de null , entra al while
                {
                	Console.WriteLine(linea);
                	string[] partes= linea.Split(',');
                	try // Añadido para capturar error si el saldo no es un número
                    {
                	 double saldoInicial = double.Parse(partes[5]);
                	
                	Cuenta nuevaCuenta= new Cuenta(partes[0], partes[1], partes[2],partes[3], saldoInicial);
                	
                	miBanco.AgregarCuenta(nuevaCuenta);
                    List<Cuenta> listaParaMostrar = miBanco.TodasLasCuentas();
                    }
                    catch (FormatException) // Error si partes[4] no es un número double válido
                    {
                         Console.WriteLine("ADVERTENCIA: Saldo inválido en línea: " + linea);
                    }
                    catch (IndexOutOfRangeException) // Error s
                    {
                         Console.WriteLine("ADVERTENCIA: Faltan datos en línea:" + linea);
                    }
                }
                
             }
                    Console.WriteLine("Cuentas cargadas.");
               
              }
               else
              {
                 // Si se entra aca, el archivo no existe en la carpeta de ejecución.
                Console.WriteLine("ADVERTENCIA: No se encontró el archivo 'clientes.csv' en la carpeta del programa.");
               }
        	}
        
        static void mostrarMenu(){
			Console.WriteLine("1. Agregar una cuenta al banco.");
		    Console.WriteLine("2. Eliminar una cuenta");
		    Console.WriteLine("3.Listado de clientes que tienen más de una cuenta");
		    Console.WriteLine("4.Listado de clientes");
		    Console.WriteLine("5.Listado de cuenta");
		    Console.WriteLine("6.Realizar una extracción.");
            Console.WriteLine("7.Depositar dinero");
            Console.WriteLine("8.Transferir dinero"); 
		    Console.WriteLine("9.Salir");
		}
        
        public static void AgregarNuevaCuenta(Banco miBanco) 
        {   Console.Clear(); // Limpia la consola para esta operación
            Console.WriteLine("\n--- Agregar Nueva Cuenta ---");
            Console.Write("Ingrese DNI del titular: ");
            string dniTitular = Console.ReadLine();
            
            //buscar si cliente existe
            Cliente clienteExistente = miBanco.BuscarClientePorDNI(dniTitular);
            
            string nombreTitular;
            string apellidoTitular;
            string direccionTitular;
            string telefonoTitular;
            string mailTitular;
            
            //si no existe
            
            if (clienteExistente == null)
            {     Console.WriteLine("Cliente no encontrado. Se creará uno nuevo.");
                  Console.Write("Ingrese Nombre del titular: ");
                  nombreTitular = Console.ReadLine();
                  Console.Write("Ingrese Apellido del titular: ");
                  apellidoTitular = Console.ReadLine();
                  Console.Write("Ingrese Dirección del titular: ");
                  direccionTitular= Console.ReadLine();
                  Console.Write("Ingrese telefono del titular: ");
                  telefonoTitular = Console.ReadLine();
                  Console.Write("Ingrese Mail del titular: ");
                  mailTitular = Console.ReadLine();
                       
                  
                  // Crear y agregar nuevo cliente
                   Cliente nuevoCliente = new Cliente(nombreTitular, apellidoTitular, dniTitular, direccionTitular,telefonoTitular,mailTitular );
                   miBanco.AgregarCliente(nuevoCliente);
                  Console.WriteLine("Cliente " +nombreTitular+" "+ apellidoTitular+ " "+ " agregado.");
                 
            }else  {
       
                  nombreTitular = clienteExistente.NombreCliente;
                  apellidoTitular = clienteExistente.ApellidoCliente;
                  Console.WriteLine("Cliente encontrado:"+nombreTitular+" "+ apellidoTitular+ ".");
                                   
    }
            // Pedir Datos para la Cuenta
               Console.Write("Ingrese Número de la nueva cuenta: ");
               string numeroCuenta = Console.ReadLine();
               
             double montoDeposito = 0;
        bool montoValido = false;

        while (!montoValido)
        {
            Console.Write("Ingrese Monto del depósito inicial (positivo): ");
            string iDeposito = Console.ReadLine(); // Lee la entrada

            try // Intenta convertir y validar
            {
                // PASO 1: Intenta convertir usando Parse()
                montoDeposito = double.Parse(iDeposito);

                // PASO 2: Si la conversión funcionó, verifica si es positivo
                if (montoDeposito > 0)
                {
                    montoValido = true; // ¡Válido! Salimos del while.
                }
                else
                {
                    // Es un número, pero no positivo (0 o negativo).
                    Console.WriteLine("Monto inválido. Debe ser un número positivo.");
                    // montoValido sigue false, el while repetirá.
                }
            }
            catch (FormatException) 
            {
                // La conversión falló.
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
                // montoValido sigue false, el while repetirá.
            }
            // También podría haber otros errores (OverflowException),
            // pero FormatException es el más común aquí.
        }
       
        
        Cuenta nuevaCuenta = new Cuenta(numeroCuenta, nombreTitular, apellidoTitular, dniTitular, montoDeposito);

        miBanco.AgregarCuenta(nuevaCuenta);

        // Muestra el mensaje de éxito SI TODO LO ANTERIOR FUNCIONÓ
        Console.WriteLine("Creación de cuenta exitosa.");
        Console.WriteLine("\nPresione una tecla para volver al menú...");
        Console.ReadKey(); 
    
      
       
    }
        
		
	}
	
	}