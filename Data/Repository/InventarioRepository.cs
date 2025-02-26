using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class InventarioRepository
    {
        private readonly AppDbContext _context;

        public InventarioRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
