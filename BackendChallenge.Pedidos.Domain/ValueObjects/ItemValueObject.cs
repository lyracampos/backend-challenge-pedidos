namespace BackendChallenge.Pedidos.Domain.ValueObjects
{
    public class ItemValueObject
    {
        public ItemValueObject()
        {

        }
        public ItemValueObject(string produto, decimal preco, int quantidade)
        {
            Produto = produto;
            Preco = preco;
            Quantidade = quantidade;
        }

        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get { return (Preco * Quantidade); } }
    }
}
