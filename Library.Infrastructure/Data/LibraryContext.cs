﻿using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Address> Adresses => Set<Address>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Domain> Domains => Set<Domain>();
        public DbSet<Lector> Lectors => Set<Lector>();
        public DbSet<Rentail> Rentails => Set<Rentail>();

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { } // à voir pourquoi ?

    }
}