using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Models;

namespace ContactManager.Infrastructure
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactDbContext dbContext)
        {
            DatabaseCotext = dbContext;
        }

        public Contact Get(int id)
        {
            return DatabaseCotext.Contacts.Find(id);
        }
    }
}
