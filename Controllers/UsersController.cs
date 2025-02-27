using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace kyc_api_finclusion.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private static List<User> users = new List<User>();

        // POST api/users/kyc
        [HttpPost]
        [Route("api/users/kyc")]
        public IActionResult CompleteKYC([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            // Simulate KYC completion
            user.IsKYCCompleted = true;

            // Generate referral code
            user.ReferralCode = GenerateReferralCode(user);

            // Add user to the list
            user.Id = users.Count + 1;
            users.Add(user);

            return Ok(user);
        }

        private string GenerateReferralCode(User user)
        {
            // Generate a unique referral code using user's name and a random number
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string baseCode = user.Name.Replace(" ", "").ToUpper();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            string randomPart = new Random().Next(1000, 9999).ToString();
            return $"{baseCode}-{randomPart}";
        }

        // GET api/users
        [HttpGet]
        [Route("api/users")]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

    }


}
