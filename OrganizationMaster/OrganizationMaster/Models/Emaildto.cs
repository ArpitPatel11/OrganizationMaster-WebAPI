namespace OrganizationMaster.Models
{
    public class Emaildto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<IFormFile> Attachment { get; set; }  = new List<IFormFile>();
    }
}
