﻿using Microsoft.Extensions.Logging;
using pocketbook.Core.IConfiguration;
using pocketbook.Core.IRepository;
using pocketbook.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pocketbook.Data
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");


            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public  void Dispose()
        {
            _context.DisposeAsync();
        }
        
       
    }
}
