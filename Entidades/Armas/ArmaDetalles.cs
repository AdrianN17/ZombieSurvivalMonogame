namespace Entidades
{
    public class ArmaDetalles
    {
        public int stock;
        public int MaxStock;
        public int municion;
        public int maxMunicion;
        public float velocidad;
        public float dano;
        public float intervalo;

        public ArmaDetalles(int stock, int maxStock, int municion, int maxMunicion, float velocidad, float dano, float intervalo)
        {
            this.stock = stock;
            this.MaxStock = maxStock;
            this.municion = municion;
            this.maxMunicion = maxMunicion;
            this.velocidad = velocidad;
            this.dano = dano;
            this.intervalo = intervalo;
        }
    }
}
