using System;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Shared
{
	public class Contact
	{
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }

		public string FullName => $"{LastName}, {FirstName}";
	}
}

