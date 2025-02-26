using Data.Repository;
using Entities;

namespace Business
{
    public class CompraService
    {
        private readonly CompraRepository _compraRepository;

        public CompraService(CompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }
        public async Task<List<Compra>> GetAllAsync() => await _compraRepository.GetAllAsync();
    }
}
