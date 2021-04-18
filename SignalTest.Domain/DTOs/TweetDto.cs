using System;

namespace SignalTest.Domain.DTOs
{
    public class TweetDto
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
        public string DataStr => Data.ToString("G");
        public string NomeUsuario { get; set; }
    }
}