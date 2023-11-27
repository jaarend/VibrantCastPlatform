using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.Models.MembershipType;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.MembershipType
{
    public class MembershipTypeService : IMembershipTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        private string _userId;

        public MembershipTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetUserId(string userId) => _userId = userId;
        //use userroles to only allow admins to access and create?


        //CREATE
        public async Task<bool> CreateMembershipTypeAsync(MembershipTypeCreate model)
        {
            var entity = new Models.MembershipType
            {
                Name = model.Name,
                Description = model.Description,
                MonthlyAmount = model.MonthlyAmount,
                YearlyAmount = model.YearlyAmount,
                ArtworkLimit = model.ArtworkLimit,
                ExperiencesLimit = model.ExperiencesLimit,
                DateCreated = DateTime.Now
            };

            _dbContext.MembershipTypes.Add(entity);

            return await _dbContext.SaveChangesAsync() == 1;
        }

        //READ

        public async Task<IEnumerable<MembershipTypeDetail>> GetAllMembershipTypesAsync()
        {
            var membershipTypeList = _dbContext
                .MembershipTypes
                .Select(m =>
                    new MembershipTypeDetail
                    {
                        Name = m.Name,
                        Description = m.Description,
                        MonthlyAmount = m.MonthlyAmount,
                        YearlyAmount = m.YearlyAmount,
                        ArtworkLimit = m.ArtworkLimit,
                        ExperiencesLimit = m.ExperiencesLimit,
                        DateCreated = m.DateCreated,
                        DateModified = m.DateModified
                    });

            return await membershipTypeList.ToListAsync();
        }
    }
}