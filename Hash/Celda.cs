namespace Hash
{
    // Enum para asignar un estado a cada celda
    enum Estado
    {
        ocupado, libre
    }
    class Celda
    {
        private string valor;
        private int llave;
        private Estado estado;
        
        // Getters y Setters
        public string Valor { get => valor; set => valor = value; }
        public int Llave { get => llave; set => llave = value; }
        internal Estado Estado { get => estado; set => estado = value; }

        // Constructor
        public Celda()
        {
            valor = "";
            llave = 0;
            estado = Estado.libre;
        }

    }
}
