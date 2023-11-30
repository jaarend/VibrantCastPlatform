using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Models.Artwork;
using Shared.Models.Artwork.ArtworkMapping;
using Shared.Models.MediumTags;

namespace Server.Services.Artwork
{
    public interface IArtworkService
    {
        void SetUserId(string userId);
        Task<bool> CreateArtworkAsync(ArtworkCreate model);

        Task<bool> AddMediumTagToArtwork(ArtworkMediumTagMapping model);

        Task<IEnumerable<MediumTagListName>> GetAllMediumTagsOnArt(int artworkId);
        Task<IEnumerable<ArtworkDetail>> GetAllArtworkDetailAsync();
        Task<ArtworkDetail> GetArtworkDetailByIdAsync(int artworkId);
        Task<IEnumerable<ArtworkDetail>> GetAllPublicArtworkDetailAsync();
        Task<bool> UpdateArtwork(ArtworkUpdate model);

        Task<bool> DeleteArtworkAsync(int artworkId);
    }
}