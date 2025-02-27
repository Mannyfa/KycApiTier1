namespace kyc_api_finclusion.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsKYCCompleted { get; set; }
        public string? ReferralCode { get; set; }

        public int? BVN { get; set; }
        public int? DateOfBirth { get; set; }

    }
}
