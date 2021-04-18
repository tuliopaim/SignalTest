using System;

namespace SignalTest.Domain.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public DateTime VistoPorUltimo { get; set; }

        public string VistoPorUltimoStr => VistoPorUltimo.ToString("G");
    }
}