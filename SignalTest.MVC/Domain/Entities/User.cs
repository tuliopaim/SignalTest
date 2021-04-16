using System;
using Microsoft.AspNetCore.Identity;

namespace SignalTest.MVC.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public DateTime VistoPorUltimo { get; private set; }
        
        public void Atualizar()
        {
            VistoPorUltimo = DateTime.Now;
        }
    }
}