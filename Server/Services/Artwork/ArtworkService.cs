using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.Models.Artwork;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.Artwork
{
    public class ArtworkService : IArtworkService
    {
        private readonly ApplicationDbContext _dbContext;

        private string _userId;

        public ArtworkService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetUserId(string userId) => _userId = userId;

        public async Task<bool> CreateArtworkMetaDataAsync(ArtworkCreate model)
        {

            var artworkEntity = new Models.Artwork
            {
                CreatorId = _userId,
                FullImage = "",
                Title = model.Title,
                Description = model.Description,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Country = model.Country,
                PostalCode = model.PostalCode,
                Materials = model.Materials,
                Width = model.Width,
                Height = model.Height,
                Price = model.Price,
                DateCreated = DateTime.Now
            };

            _dbContext.Artworks.Add(artworkEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        /*
        add the file update method

        public asycn Task<bool> UpdateArtworkFile...
        {
            var fileName = file.FileName;

            var extension = Path.GetExtension(fileName);

            generate new filename to avoid duplicates
            var newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}-{Guid.NewGuid().ToString()}{extension}";

            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images");
            var fullPath = Path.Combine(directoryPath, newFileName);

            Directory.CreateDirectory(directoryPath);

            using (var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(stream);
            }

        }
        */
    }
}