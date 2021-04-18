using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SignalTest.Application.DTOs;
using SignalTest.Application.Services.Interfaces;
using SignalTest.Domain.Entities;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Domain.Interfaces.Repository;

namespace SignalTest.Application.Services
{
    public class UserService : IUserInstanceService
    {
        private readonly IUserInstanceRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly IUserNotificationService _notification;

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

            await NotificarUsuariosOnlineHub();
        }
        
        public async Task EstouAqui(string idString)
        {
            if (!Guid.TryParse(idString, out var id))
                return;

            await AtualizarVistoPorUltimo(id);

            await NotificarUsuariosOnlineHub();
        }

        public async Task NotificarLogin(UserInstanceDto userDto)
        {
            await _notification.NotificarUsuarioOnline(userDto.Nome);
        }

        public async Task<IEnumerable<UserInstanceDto>> ObterTodosOnline()
        {
            var data = DateTime.Now.AddMinutes(-5);

            var lista = await _repository.ObterTodosOnline(data);

            lista ??= new List<User>();

            return lista.Select(ConverterParaViewModel);
        }

        public async Task<UserInstanceDto> ObterPorId(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);
            return ConverterParaViewModel(user);
        }

        public async Task<IEnumerable<UserInstanceDto>> ObterTodos()
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
        
        private static UserInstanceDto ConverterParaViewModel(User user)
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