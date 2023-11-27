using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                        Id = m.Id,
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

        public async Task<MembershipTypeDetail> GetMembershipTypeDetailByIdAsync(int membershipId)
        {
            var entity = await _dbContext
                .MembershipTypes
                .FirstOrDefaultAsync(e => e.Id == membershipId);

            if (entity is null)
                return null;

            var detail = new MembershipTypeDetail
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                MonthlyAmount = entity.MonthlyAmount,
                YearlyAmount = entity.YearlyAmount,
                ArtworkLimit = entity.ArtworkLimit,
                ExperiencesLimit = entity.ExperiencesLimit,
                DateCreated = entity.DateCreated,
                DateModified = entity.DateModified
            };

            return detail;

        }

        //UPDATE

        public async Task<bool> EditMembershipTypeAsync(MembershipTypeEdit model)
        {
            var entity = await _dbContext.MembershipTypes.FindAsync(model.Id);

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.MonthlyAmount = model.MonthlyAmount;
            entity.YearlyAmount = model.YearlyAmount;
            entity.ArtworkLimit = model.ArtworkLimit;
            entity.ExperiencesLimit = model.ExperiencesLimit;
            entity.DateModified = DateTime.Now;


            return await _dbContext.SaveChangesAsync() == 1;
        }


        //DELETE
        public async Task<bool> DeleteMembershipTypeAsync(int id)
        {
            var entity = await _dbContext.MembershipTypes.FindAsync(id);

            _dbContext.MembershipTypes.Remove(entity);

            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}