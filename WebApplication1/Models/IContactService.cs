namespace WebApplication1.Models
{
    public interface IContactService
    {
        void Add(ContactModel contact);
        void Delete(int id);
        void Update(ContactModel contact);
        List<ContactModel> FindAll();
        ContactModel? FindById(int id);
        List<OrganizationEntity> FindAllOrganizations();
    }
}
