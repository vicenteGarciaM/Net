using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Business
{
    public class ArticuloService
    {
        private readonly Repository<Articulo> _articuloRepository;

        public ArticuloService(Repository<Articulo> articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }
        public async Task<IEnumerable<Articulo>> ObtenerArticulos() => await _articuloRepository.GetAllAsync();
        public async Task AgregarArticulo(Articulo articulo) => await _articuloRepository.AddAsync(articulo);
    }
}
