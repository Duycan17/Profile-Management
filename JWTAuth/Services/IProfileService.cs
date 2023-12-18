using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuth.Models;

namespace JWTAuth.Services
{
    public interface IProfileService
    {
        Task<Profile> GetProfileById(int profileId);
        Task<List<Profile>> GetAllProfiles();
        Task<Profile> CreateProfileAsync(ProfileDTO newProfile);
        Task<Profile> UpdateProfileAsync(int profileId, ProfileDTO updatedProfile);
        Task<bool> DeleteProfileAsync(int profileId);
        System.Threading.Tasks.Task SaveChangesAsync();
        Task<List<Profile>> FindByStandard(string standardName);
    }
}
