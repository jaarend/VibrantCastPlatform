using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.Organization;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.Organization
{
    public class OrganizationService :IOrganizationService
    {
        private readonly ApplicationDbContext _dbContext;

        private string _userId;

        public OrganizationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetUserId(string userId) => _userId = userId;

        public async Task<bool> CreateOrganizationAsync(OrganizationCreate model)
        {
            var entity = new Models.Organization
            {

            };


            _dbContext.Organizations.Add(entity);

            return await _dbContext.SaveChangesAsync() == 1;

        }
    }
}