using System;

namespace SignalTest.MVC.Domain.Entities
{
    public class UserInstance
    {
        public UserInstance(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            VistoPorUltimo = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public string Nome { get; set; }

        public DateTime VistoPorUltimo { get; private set; }
        
        public void Atualizar()
        {
            VistoPorUltimo = DateTime.Now;
        }
    }
}