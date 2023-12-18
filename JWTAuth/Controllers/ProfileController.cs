using Microsoft.AspNetCore.Mvc;
using JWTAuth.Models;
using JWTAuth.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace JWTAuth.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{profileId}")]
        public async Task<ActionResult<Profile>> GetProfileById(int profileId)
        {
            var profile = await _profileService.GetProfileById(profileId);

            if (profile == null)
                return NotFound(); // Return 404 if profile not found

            return Ok(profile);
        }

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetAllProfiles()
        {
            var profiles = await _profileService.GetAllProfiles();
            return Ok(profiles);
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProfile([FromForm] ProfileDTO profileDTO)
        {
            if (profileDTO.ProfileFile == null || profileDTO.ProfileFile.Length == 0)
            {
                // Handle the case where no file is provided
                return BadRequest("No file provided.");
            }
            var createdProfile = await _profileService.CreateProfileAsync(profileDTO);

            return CreatedAtAction(nameof(GetProfileById), new { profileId = createdProfile.ProfileId }, createdProfile);
        }

        [HttpPut("{profileId}")]
        public async Task<ActionResult<Profile>> UpdateProfile(int profileId, [FromForm] ProfileDTO updatedProfile)
        {
            var updated = await _profileService.UpdateProfileAsync(profileId, updatedProfile);

            if (updated == null)
                return NotFound(); // Return 404 if profile not found

            return Ok(updated);
        }

        [HttpDelete("{profileId}")]
        public async Task<ActionResult> DeleteProfile(int profileId)
        {
            var result = await _profileService.DeleteProfileAsync(profileId);

            if (!result)
                return NotFound(); // Return 404 if profile not found

            return NoContent(); // Return 204 No Content for successful deletion
        }
        [HttpGet("st/{standardName}")]
        public async Task<ActionResult<List<Profile>>> FindByStandard(string standardName)
        {
            var profiles = await _profileService.FindByStandard(standardName);
            return Ok(profiles);
        }
    }
}

