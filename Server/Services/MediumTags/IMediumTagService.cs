using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.MediumTags;

namespace Server.Services.MediumTags
{
    public interface IMediumTagService
    {
        Task<bool> CreateMediumTagAsync(MediumTagCreate model);

        Task<IEnumerable<MediumTagDetail>> GetAllMediumTagsAsync();

        Task<bool> UpdateMediumTag(MediumTagEdit model);

        Task<bool> DeleteMediumTagAsync(int mediumTagId);
        
    }
}