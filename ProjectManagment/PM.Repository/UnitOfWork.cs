﻿using PM.DAL;
using PM.Repository.Common;
using PM.Repository.Identity;
using System.Threading.Tasks;

namespace PM.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly PMAppContext _context;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        #endregion

        #region Constructors
        public UnitOfWork()
        {
            _context = new PMAppContext();
        }
        #endregion

        #region IUnitOfWork Members
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
    
}
