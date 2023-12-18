using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JWTAuth.Models;

namespace JWTAuth.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DataContext _dbContext;

        public ProfileService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Profile> GetProfileById(int profileId)
        {
            return await _dbContext.Profiles.FindAsync(profileId);
        }

        public async Task<List<Profile>> GetAllProfiles()
        {
            return await _dbContext.Profiles.ToListAsync();
        }
        public async Task<Profile> CreateProfileAsync(ProfileDTO newProfileDTO)
        {
            // Read the contents of the file into a byte array
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await newProfileDTO.ProfileFile.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            var newProfile = new Profile
            {
                ProfileTitle = newProfileDTO.ProfileTitle,
                ProfileFile = fileBytes,
                StandardName = newProfileDTO.StandardName
            };

            _dbContext.Profiles.Add(newProfile);
            await SaveChangesAsync();
            return newProfile;
        }
        public async Task<Profile> UpdateProfileAsync(int id, ProfileDTO updatedProfileDTO)
        {
            var existingProfile = await _dbContext.Profiles.FindAsync(id);

            if (existingProfile == null)
                return null;

            // Read the contents of the file into a byte array
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await updatedProfileDTO.ProfileFile.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            // Update properties from DTO to the existing profile entity
            existingProfile.ProfileTitle = updatedProfileDTO.ProfileTitle;
            existingProfile.ProfileFile = fileBytes;
            // Update other properties as needed...

            await SaveChangesAsync();
            return existingProfile;
        }





        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            var profileToDelete = await _dbContext.Profiles.FindAsync(profileId);

            if (profileToDelete == null)
                return false; // Profile not found

            _dbContext.Profiles.Remove(profileToDelete);
            await SaveChangesAsync();
            return true;
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Profile>> FindByStandard(string standardName)
        {
            var profiles = await _dbContext.Profiles.Where(p => p.StandardName.Contains(standardName)).ToListAsync();
            return profiles;
        }
    }
}
