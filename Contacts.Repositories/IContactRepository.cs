using System;
using Contacts.Shared;

namespace Contacts.Repository
{
	public interface IContactRepository
	{
		Task<bool> InsertContact(Contact contact);
        Task<bool> UpdateContact(Contact contact, int id);
        Task DeleteContact(int id);
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
    }
}

