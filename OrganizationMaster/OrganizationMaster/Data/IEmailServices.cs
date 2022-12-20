
using OrganizationMaster.Models;

namespace OrganizationMaster.Data
{
    public interface IEmailServices
    {
        public void SendEmail(Emaildto request, List<IFormFile> attachments)
        {
            throw new NotImplementedException();
        }
    }
}
