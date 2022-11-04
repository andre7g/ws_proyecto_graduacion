namespace ws_proyecto.Models.Dietas
{
    public class AgregarIngesta
    {
        public int DietasId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Proteina_g { get; set; }
        public decimal GrasaTotal_g { get; set; }
        public decimal Carbohidratos_g { get; set; }
        public decimal Energia_KcaL { get; set; }
        public List<ListaAlimentos> ListaAlimentos { get; set; }

    }
    public class ListaAlimentos
    {
        public int AlimentosPorcion_Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Proteina_g { get; set; }
        public decimal GrasaTotal_g { get; set; }
        public decimal Carbohidratos_g { get; set; }
        public decimal Energia_KcaL { get; set; }

    }
}
