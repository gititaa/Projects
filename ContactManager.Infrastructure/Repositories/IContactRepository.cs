using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Models;

namespace ContactManager.Infrastructure
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Contact Get(int id);
    }
}
