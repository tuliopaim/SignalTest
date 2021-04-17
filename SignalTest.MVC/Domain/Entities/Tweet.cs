using System;

namespace SignalTest.MVC.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        public Tweet(Guid userId, string mensagem)
        {
            UserId = userId;
            Mensagem = mensagem;

            Data = DateTime.Now;
        } 

        public string Mensagem { get; private set; }
        public DateTime Data { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }
    }
}