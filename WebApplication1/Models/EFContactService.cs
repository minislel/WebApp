
namespace WebApplication1.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;
        public EFContactService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ContactModel contact)
        {
            _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Find(id));
            _context.SaveChanges();
        }

        public List<ContactModel> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public ContactModel? FindById(int id)
        {
           var entity = _context.Contacts.Find(id);
            return entity != null ? ContactMapper.FromEntity(entity) : null;
        }

        public void Update(ContactModel contact)
        {
           _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
