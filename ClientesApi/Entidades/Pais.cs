namespace ClientesApi.Entidades
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Relación inversa
        public ICollection<Cliente>? Clientes { get; set; }
    }
}
