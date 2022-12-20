namespace OrganizationMaster.Models
{
    public class PaginationResponse
    {
        public List<Tblorganizationmaster> organizationMasters { get; set; } = new List<Tblorganizationmaster>();

        public int Pages { get; set; }

        public int CurrentPage { get; set; }
    }
}
