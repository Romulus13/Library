using Library_BL.Enums;

namespace Library_Web_API.Requests
{
    public class UserContactRequestModel
    {
        public string? Value { get; set; }
        public ContactType Type { get; set; }
    }
}
