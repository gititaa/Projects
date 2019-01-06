using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Models;

namespace ContactManager.Infrastructure
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext() : base("name=ContactConnection")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
