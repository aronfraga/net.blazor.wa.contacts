using System;
using System.Data;
using Contacts.Repository.Exceptions;
using Contacts.Shared;
using Dapper;

namespace Contacts.Repository
{
	public class ContactRepository : IContactRepository
	{
		private readonly IDbConnection _dbConnection;

		public ContactRepository(IDbConnection dbConntection)
		{
			_dbConnection = dbConntection;
		}

        public async Task DeleteContact(int id)
        {
            try
            {
                string sql = @"DELETE 
                               FROM dbo.Contacts
                               WHERE Id = @Id";

                await _dbConnection.ExecuteAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            try
            {
                string sql = @"SELECT Id,
                                      FirstName,
                                      LastName,
                                      Phone,
                                      Address
                               FROM dbo.Contacts";

                return await _dbConnection.QueryAsync<Contact>(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact> GetContactById(int id)
        {
            try
            {
                string sql = @"SELECT Id,
                                      FirstName,
                                      LastName,
                                      Phone,
                                      Address
                               FROM dbo.Contacts 
                               WHERE Id = @Id";

                return await _dbConnection.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertContact(Contact contact)
        {
            try
            {
                if(contact is null)
                    throw new ContactCanNotNullException();
                
                string sql = @"INSERT INTO dbo.Contacts(FirstName, LastName, Phone, Address)
                               VALUES(@FirstName, @LastName, @Phone, @Address)";

                int result = await _dbConnection.ExecuteAsync(sql, new
                {
                    contact.FirstName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address
                });

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateContact(Contact contact,int id)
        {
            try
            {
                if (await GetContactById(contact.Id) is null || contact.Id != id)
                    throw new ContactNotFoundException();
                    
                string sql = @"UPDATE dbo.Contacts
                               SET FirstName = @FirstName, 
                                   LastName = @LastName, 
                                   Phone = @Phone, 
                                   Address = @Address
                               WHERE Id = @Id";

                int result = await _dbConnection.ExecuteAsync(sql, new
                {
                    contact.Id,
                    contact.FirstName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address
                });

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

