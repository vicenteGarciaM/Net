using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Business
{
    public class ClienteService
    {
        private readonly Repository<Cliente> _Repository;

        public ClienteService(Repository<Cliente> clienteRepository)
        {
            _Repository = clienteRepository;
        }
        public async Task<IEnumerable<Cliente>> ObtenerClientes() => await _Repository.GetAllAsync();
        public async Task AgregarCliente(Cliente cliente) => await _Repository.AddAsync(cliente);
    }
}
