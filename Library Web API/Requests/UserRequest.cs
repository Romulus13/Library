using System.ComponentModel.DataAnnotations;

namespace Library_Web_API.Requests
{
    public class UserRequest
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        public List<UserContactRequestModel>? UserContacts { get; set;}
    }
}
