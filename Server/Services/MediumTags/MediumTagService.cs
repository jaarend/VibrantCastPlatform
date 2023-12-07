using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models.MediumTags;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.MediumTags
{
    public class MediumTagService : IMediumTagService
    {
        private readonly ApplicationDbContext _dbContext;

        public MediumTagService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
        public async Task<IEnumerable<MediumTagListName>> GetAllMediumTagsNameAsync()
        {
            var mediumTagNames = _dbContext
                .MediumTags
                .Select(n => 
                    new MediumTagListName
                    {
                        Id = n.Id,
                        Name = n.Name,
                    });
            return await mediumTagNames.ToListAsync();
        }

        public async Task<MediumTagEdit> GetMediumTagEditByIdAsync(int mediumTagId)
        {
            var entity = await _dbContext
                .MediumTags
                .FirstOrDefaultAsync(e => e.Id == mediumTagId);

            if (entity is null)
                return null;

            var detail = new MediumTagEdit
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                DateModified = entity.DateModified
            };

            return detail;

        }

        //UPDATE

        public async Task<bool> UpdateMediumTag(MediumTagEdit model, int mediumTagId)
        {
            if(model == null)
                return false;

            var entity = await _dbContext.MediumTags.FindAsync(mediumTagId);

            if(entity?.Id != mediumTagId) return false;
            
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.DateModified = model.DateModified;

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