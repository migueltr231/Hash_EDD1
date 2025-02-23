namespace Hash
{
    class Programa
    {        
        static void Main(string args)
        {
            TablaHash tablaHash = new TablaHash(996);
            tablaHash.Insertar("Arroz", 245643); // Probando 1 ejemplo de la guia
            tablaHash.Mostrar();
            tablaHash.Insertar("Cabeza", 111000);
            tablaHash.Buscar(245643);
        }
    }
}
