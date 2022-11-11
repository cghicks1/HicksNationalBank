using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Model
{
    public partial class AccountDbContext : DbContext
    {
        public static AccountDbContext NewAccountDbContext(string connection) {
            var options = new DbContextOptionsBuilder<AccountDbContext>();
                options.UseSqlServer(connection);
            return new AccountDbContext(options.Options);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //Extend Model creation here if necessary
        }
    }
}
