using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.Artwork;

namespace Server.Services.Artwork
{
    public interface IArtworkService
    {
        void SetUserId(string userId);
        Task<bool> CreateArtworkMetaDataAsync(ArtworkCreate model);
    }
}