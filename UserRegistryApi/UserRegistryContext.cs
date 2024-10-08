﻿using Microsoft.EntityFrameworkCore;
using UserRegistryApi.Models;

namespace UserRegistryApi
{
    public class UserRegistryContext : DbContext
    {
        public DbSet<User> users { get; set; }

        private bool _useInMemory;

        public UserRegistryContext(DbContextOptions<UserRegistryContext> options, bool useInMemory = false)
            : base(options)
        {
            _useInMemory = useInMemory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine($"---[DEBUG]--- useInMemory: {_useInMemory}");
            if (_useInMemory)
                optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }
    }
}
