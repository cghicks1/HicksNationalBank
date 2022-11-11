using Account.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Tests
{
    public class MockAccountDbContext : AccountDbContext

    {

        public Mock<AccountDbContext> MockDbContext { get; private set; }



        public MockAccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)

        {

            var optionsBuilder = new DbContextOptionsBuilder<AccountDbContext>();

            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            MockDbContext = new Mock<AccountDbContext>(options);

        }



        public static MockAccountDbContext CreateDbContext()

        {

            var optionsBuilder = new DbContextOptionsBuilder<AccountDbContext>();

            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            return new MockAccountDbContext(optionsBuilder.Options);

        }

    }
}
