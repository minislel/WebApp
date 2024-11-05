namespace WebApplication1.Models
{
    public class ContactMapper
    {
        public static ContactModel FromEntity(ContactEntity entity)
        {
            return new ContactModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                BirthDate = entity.BirthDate,

            };
        }
        public static ContactEntity ToEntity(ContactModel model)
        {
            return new ContactEntity()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,

            };
        }
    }
}

