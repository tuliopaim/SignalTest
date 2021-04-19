using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SignalTest.Domain.DTOs;
using SignalTest.Domain.Entities;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Domain.Interfaces.Repository;
using SignalTest.Domain.Interfaces.Services;

namespace SignalTest.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserInstanceRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly IUserNotificationService _notification;

        private readonly int MINUTOS_CONSIDERADOS_ONLINE = 5;

        public UserService(
            IUserInstanceRepository repository,
            UserManager<User> userManager,
            IUserNotificationService notification)
        {
            _repository = repository;
            _userManager = userManager;
            _notification = notification;
        }

        public async Task NotificarLogin(string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user is null) return;

            user.Atualizar();

            await _repository.Update(user);

            var userDto = ConverterParaViewModel(user);

            await _notification.NotificarNovoUsuarioOnline(userDto);
            await NotificarTodosOsUsuariosOnline();
        }

        public async Task EstouAqui(Guid userId)
        {
            var id = userId.ToString();
            await AtualizarVistoPorUltimo(userId);

            await NotificarTodosOsUsuariosOnline();
        }

        public async Task NotificarTodosOsUsuariosOnline()
        {
            var usuarios = await ObterTodosOnline();

            await _notification.NotificarUsuariosOnline(usuarios);
        }

        public async Task<IEnumerable<UserDto>> ObterTodosOnline()
        {
            var data = DateTime.Now.AddMinutes(-MINUTOS_CONSIDERADOS_ONLINE);

            var lista = await _repository.ObterTodosOnline(data);

            lista ??= new List<User>();

            return lista.Select(ConverterParaViewModel);
        }

        public async Task<UserDto> ObterPorId(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);
            return ConverterParaViewModel(user);
        }

        public async Task<IEnumerable<UserDto>> ObterTodos()
        {
            var lista = await _repository.ObterTodos();

            lista ??= new List<User>();

            return lista.Select(ConverterParaViewModel);
        }

        public async Task AtualizarVistoPorUltimo(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);

            if (user == null) return;

            user.Atualizar();

            await _repository.Update(user);
        }
        
        public async Task Update(User user)
        {
            await _repository.Update(user);
        }
        
        public async Task Remove(User user)
        {
            await _repository.Remove(user);
        }
        
        private static UserDto ConverterParaViewModel(User user)
        {
            if (user is null) return null;

            return new()
            {
                Id = user.Id,
                Nome = user.Nome,
                VistoPorUltimo = user.VistoPorUltimo
            };
        }
    }
}