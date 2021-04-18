using System;

namespace SignalTest.Application.DTOs
{
    public class UserInstanceDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public DateTime VistoPorUltimo { get; set; }

        public string VistoPorUltimoStr => VistoPorUltimo.ToString("G");

    }
}