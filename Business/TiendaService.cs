using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Business
{
    public class TiendaService
    {
        private readonly Repository<Tienda> _tiendaRepository;

        public TiendaService(Repository<Tienda> tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }
        public async Task<IEnumerable<Tienda>> ObtenerTiendas() => await _tiendaRepository.GetAllAsync();
        public async Task AgregarTienda(Tienda tienda) => await _tiendaRepository.AddAsync(tienda);
    }
}
