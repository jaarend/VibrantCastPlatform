using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models.MediumTags;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.MediumTags
{
    public class MediumTagService
    {
        private readonly ApplicationDbContext _dbContext;

        public MediumTagService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //add admin only check?

        //CREATE

        public async Task<bool> CreateMediumTagAsync(MediumTagCreate model)
        {
            var entity = new Models.MediumTag
            {
                Name = model.Name,
                Description = model.Description,
                DateCreated = DateTime.Now
            };

            _dbContext.MediumTags.Add(entity);

            return await _dbContext.SaveChangesAsync() == 1;
        }

        //READ

        public async Task<IEnumerable<MediumTagDetail>> GetAllMediumTagsAsync()
        {
            var mediumTagDetails = _dbContext
                .MediumTags
                .Select(n => 
                    new MediumTagDetail
                    {
                        Id = n.Id,
                        Name = n.Name,
                        Description = n.Description,
                        DateCreated = n.DateCreated,
                        DateModified = n.DateModified
                    });
            return await mediumTagDetails.ToListAsync();
        }

        //UPDATE

        public async Task<bool> UpdateMediumTag(MediumTagEdit model)
        {
            if(model == null)
                return false;

            var entity = await _dbContext.MediumTags.FindAsync(model.Id);

            if(entity?.Id != model.Id) return false;
            
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.DateModified = DateTime.Now;

            return await _dbContext.SaveChangesAsync() == 1;
        }

        //DELETE

        public async Task<bool> DeleteMediumTagAsync(int mediumTagId)
        {
            var entity = await _dbContext.MediumTags.FindAsync(mediumTagId);
            if(entity?.Id != mediumTagId)
                return false;
            
            _dbContext.MediumTags.Remove(entity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

    }
}