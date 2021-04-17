using System;
using Microsoft.AspNetCore.Identity;

namespace SignalTest.MVC.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User(string nome)
        {
            Nome = nome;
            VistoPorUltimo = DateTime.Now;
        }

        public DateTime VistoPorUltimo { get; private set; }
        
        public string Nome { get; private set; }

        public void Atualizar()
        {
            VistoPorUltimo = DateTime.Now;
        }
    }
}