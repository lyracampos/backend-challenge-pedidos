using System;
namespace BackendChallenge.Pedidos.Domain.Entities
{
    public abstract class Entidade
    {
        public Entidade()
        {
            DataCriacao = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }

        public abstract bool IsValid { get; protected set; }
        protected abstract bool Validar();

        protected virtual void Atualizar()
        {
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
