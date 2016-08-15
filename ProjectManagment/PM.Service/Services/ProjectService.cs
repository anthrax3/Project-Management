﻿using PM.Common.Filters;
using PM.Model.Common;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Service
{
    /// <summary>
    /// Project service.
    /// </summary>
    public class ProjectService : BaseService, IProjectService
    {
        #region Constructors

        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the <see cref="IProject"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<IProject> GetProjectAsync(Guid id)
        {
            return UnitOfWork.ProjectRepository.GetProjectAsync(id);
        }

        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IProject"/>. </returns>
        public async Task<bool> AddAsync(IProject model)
        {
            model.Id = Guid.NewGuid();
            model.DateCreated = DateTime.UtcNow;
            model.DateUpdated = DateTime.UtcNow;

            await UnitOfWork.ProjectRepository.AddAsync(model);
            return await UnitOfWork.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Finds the list of <see cref="IProject"/>'s asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public Task<IList<IProject>> FindAsync(ProjectFilter filter)
        {
            return UnitOfWork.ProjectRepository.FindAsync(filter);
        }

        #endregion Methods
    }
}