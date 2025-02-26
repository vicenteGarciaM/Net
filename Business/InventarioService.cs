using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;

namespace Business
{
    public class InventarioService
    {
        private readonly InventarioRepository _inventarioRepository;

        public InventarioService(InventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }
    }
}
