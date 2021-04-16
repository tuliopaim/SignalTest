using System;

namespace SignalTest.MVC.Domain.Entities
{
    public class UserInstance
    {
        public UserInstance()
        {
            Id = Guid.NewGuid();
            VistoPorUltimo = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public DateTime VistoPorUltimo { get; private set; }

        public string VistoPorUltimoStr => VistoPorUltimo.ToString("G");

        public void Atualizar()
        {
            VistoPorUltimo = DateTime.Now;
        }
    }
}