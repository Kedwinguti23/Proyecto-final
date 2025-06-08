namespace GestionDeFarmacia.Models
{
    public class ItemReceta
{
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }

    public ItemReceta(Medicamento medicamento, int cantidad)
    {
        Medicamento = medicamento;
        Cantidad = cantidad;
    }

    public override string ToString()
    {
        return $"{Medicamento.Nombre} ({Medicamento.Descripcion}) x{Cantidad}";
    }
}
}
