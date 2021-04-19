using System.Collections.Generic;
using SignalTest.Domain.DTOs;

namespace SignalTest.MVC.Models
{
    public class HomeModel
    {
        public string UsuarioLogado { get; set; }
        public IEnumerable<UserDto> Usuarios { get; set; }
    }
}