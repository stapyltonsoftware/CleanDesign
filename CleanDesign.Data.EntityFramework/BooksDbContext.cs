﻿using CleanDesign.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Data.EntityFramework
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options): base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
