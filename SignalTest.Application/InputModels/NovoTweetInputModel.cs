using System;

namespace SignalTest.Application.InputModels
{
    public class NovoTweetInputModel
    {
        public Guid UsuarioId { get; set; }
        public string Mensagem { get; set; }
    }
}