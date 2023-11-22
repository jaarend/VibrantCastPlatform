using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.Models.Artwork;
using VibrantCastPlatform.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

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


        //CREATE
        public void SetUserId(string userId) => _userId = userId;

        public async Task<bool> CreateArtworkAsync(ArtworkCreate model)
        {
            try
            {
                var artworkEntity = new Models.Artwork
                {
                    CreatorId = _userId,
                    FullImage = model.FullImage,
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
            catch
            {
                return false;
            }
        }

        //READ

        public async Task<IEnumerable<ArtworkDetail>> GetAllArtworkDetailAsync()
        {
            var artworkDetails = _dbContext
                .Artworks
                .Where(n => n.CreatorId == _userId)
                .Select(n =>
                    new ArtworkDetail
                    {
                        Id = n.Id,
                        Title = n.Title,
                        FullImage = n.FullImage,
                        Description = n.Description,
                        Address = n.Address,
                        City = n.City,
                        State = n.State,
                        Country = n.Country,
                        PostalCode = n.PostalCode,
                        Materials = n.Materials,
                        Width = n.Width,
                        Height = n.Height,
                        Price = n.Price,
                        DateCreated = n.DateCreated
                    });

            return await artworkDetails.ToListAsync();

        }
        public async Task<IEnumerable<ArtworkDetail>> GetAllPublicArtworkDetailAsync() //could change this to return new art first...
        {
            var artworkDetails = _dbContext
                .Artworks
                .Select(n =>
                    new ArtworkDetail
                    {
                        Id = n.Id,
                        Title = n.Title,
                        FullImage = n.FullImage,
                        Description = n.Description,
                        Address = n.Address,
                        City = n.City,
                        State = n.State,
                        Country = n.Country,
                        PostalCode = n.PostalCode,
                        Materials = n.Materials,
                        Width = n.Width,
                        Height = n.Height,
                        Price = n.Price,
                        DateCreated = n.DateCreated
                    });

            return await artworkDetails.ToListAsync();

        }

        public async Task<ArtworkDetail> GetArtworkDetailByIdAsync(int artworkId)
        {
            var entity = await _dbContext
                .Artworks
                .FirstOrDefaultAsync(e => e.Id == artworkId && e.CreatorId == _userId);

            if (entity is null)
                return null;

            var detail = new ArtworkDetail
            {
                Id = entity.Id,
                CreatorId = entity.CreatorId,
                Title = entity.Title,
                FullImage = entity.FullImage,
                Description = entity.Description,
                Address = entity.Address,
                City = entity.City,
                State = entity.State,
                Country = entity.Country,
                PostalCode = entity.PostalCode,
                Materials = entity.Materials,
                Width = entity.Width,
                Height = entity.Height,
                Price = entity.Price
            };

            return detail;

        }

        //UPDATE

        public async Task<bool> UpdateArtwork(ArtworkUpdate model)
        {
            if (model == null)
                return false;

            var entity = await _dbContext.Artworks.FindAsync(model.Id);

            if (entity?.CreatorId != _userId) return false;

            entity.Title = model.Title;
            entity.FullImage = model.FullImage;
            entity.Description = model.Description;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.State = model.State;
            entity.Country = model.Country;
            entity.PostalCode = model.PostalCode;
            entity.Materials = model.Materials;
            entity.Width = model.Width;
            entity.Height = model.Height;
            entity.Price = model.Price;
            entity.DateModified = DateTime.Now;

            return await _dbContext.SaveChangesAsync() == 1;
        }


        //DELETE

        public async Task<bool> DeleteArtworkAsync(int artworkId)
        {
            var entity = await _dbContext.Artworks.FindAsync(artworkId);
            if (entity.CreatorId != _userId)
                return false;

            _dbContext.Artworks.Remove(entity);
            return await _dbContext.SaveChangesAsync() == 1;
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