using BackendChallenge.Pedidos.Domain.Validations;
namespace BackendChallenge.Pedidos.Domain.Entities
{
    public class Item : Entidade
    {
        protected Item()
        {

        }
        public Item(string produto, decimal preco, int quantidade)
        {
            Produto = produto;
            Preco = preco;
            Quantidade = quantidade;
        }
        public string Produto { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
        public Pedido Pedido { get; set; }

        public override bool IsValid { get { return Validar(); } protected set { } }
        protected override bool Validar() => new ItemValidacoes().Validate(this).IsValid;

        public void Atualizar(string produto, decimal preco, int quantidade)
        {
            base.Atualizar();
            Produto = produto;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}