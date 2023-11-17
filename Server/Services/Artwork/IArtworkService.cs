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
        Task<IEnumerable<ArtworkDetail>> GetAllArtworkDetailAsync();
        Task<ArtworkDetail> GetArtworkDetailByIdAsync(int artworkId);
        Task<bool> UpdateArtworkMetaData(ArtworkUpdate model);

        Task<bool> DeleteArtworkAsync(int artworkId);
    }
}