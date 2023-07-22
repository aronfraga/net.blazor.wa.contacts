using System;
using System.Net.Http.Json;
using Contacts.Shared;

namespace Contacts.Client.Services
{
	public class ContactService : IContactService
	{
		private readonly HttpClient _httpClient;

		public ContactService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task SaveContact(Contact contact)
		{
			if (contact.Id == 0)
				await _httpClient.PostAsJsonAsync($"api/Contacts", contact);
			else
				await _httpClient.PutAsJsonAsync($"api/Contacts/{contact.Id}", contact);
		}

		public async Task DeleteContact(int id)
		{
			await _httpClient.DeleteAsync($"api/Contacts/{id}");
		}

		public async Task<IEnumerable<Contact>> GetAllContact()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>($"api/Contacts");
		}

		public async Task<Contact> GetContactDetails(int id)
		{
			return await _httpClient.GetFromJsonAsync<Contact>($"api/Contacts/{id}");
		}
	}
}

