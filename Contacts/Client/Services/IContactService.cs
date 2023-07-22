using System;
using Contacts.Shared;

namespace Contacts.Client.Services
{
	public interface IContactService
	{
		Task SaveContact(Contact contact);
		Task DeleteContact(int id);
		Task <IEnumerable<Contact>> GetAllContact();
		Task <Contact> GetContactDetails(int id);
	}
}

