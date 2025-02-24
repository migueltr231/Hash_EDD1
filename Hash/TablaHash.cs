using System;

namespace Hash
{
    public class TablaHash
    {
        private static Celda[] tabla;
        private static int tamanio;

        public string Buscar(int llave)
        {
            int numIntentos = 0;
            string valor = "";

            // Se obtiene la primera direccion del registro
            int dirRegistro = FuncionHash(llave, numIntentos);
            
            // Se obtienen el o los elementos correspondientes a esa clave
            while (tabla[dirRegistro].Estado == Estado.ocupado)
            {             
                // Anexo de cada nuevo elemento a el retorno de la funcion
                valor = valor + $"\nElemento {dirRegistro} = [{tabla[dirRegistro].Llave}," +
                    $"{tabla[dirRegistro].Valor}]";
                numIntentos++;
                // Se obtiene la direccion por cada iteracion
                dirRegistro = FuncionHash(llave, numIntentos);
            }            
            return valor;
        }
        public int FuncionHash(int llave, int intento)
        {
            // Mitad del cuadrado

            // Se transforma el cuadrado del parametro llave en una cadena
            string strLlave = Math.Pow(llave, 2).ToString();

            // Se obtienen los 3 numeros siguientes a el centro de el cuadrado
            int indice= int.Parse(strLlave.Substring(strLlave.Length / 2, 3)) - 1;

            // Resolucion de colisiones: Direccionamiento abierto
            return (indice + intento) % tamanio;
        }
        public void Insertar(string valor,int llave)
        {    
            int numIntentos = 0;
            int dirRegistro;
            do
            {
                // Se obtiene la direccion absoluta del valor a insertar
                dirRegistro = FuncionHash(llave, numIntentos);
                // Si la celda de la tabla esta libre se puede establecer un valor
                if (tabla[dirRegistro].Estado == Estado.libre)
                {
                    tabla[dirRegistro].Estado = Estado.ocupado;
                    tabla[dirRegistro].Valor = valor;
                    tabla[dirRegistro].Llave = llave;
                    break;
                }
                else
                    numIntentos++;
            }
            while (tabla[dirRegistro].Estado == Estado.ocupado); // Se ejecutara mientras la celda no este ocupada
        }
        public void Mostrar()
        {
            // Imprimimos en pantalla los elementos de la tabla
            for (int i = 0; i < tamanio; i++)
                Console.WriteLine($"Elemento {i} = [{tabla[i].Llave},{tabla[i].Valor}]");
        }

        // Constructor
        public TablaHash(int t)
        {
            tamanio = t;
            tabla = new Celda[tamanio];

            // Inicializamos la tabla
            for (int i = 0; i < tamanio; i++)
                tabla[i] = new Celda();
        }
    }
}
