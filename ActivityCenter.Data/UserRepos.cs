using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivityCenter.Data
{
	public class UserRepos
	{
		private readonly string _connectionString;

		public UserRepos(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void AddUser(User user)
		{
			user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
			using (var context = new ActivityCenterContext(_connectionString))
			{
				context.Users.Add(user);
				context.SaveChanges();
			}
		}

		public string GetPasswordForEmail(string email)
		{
			string password = "";
			using (var context = new ActivityCenterContext(_connectionString))
			{
				password = context.Users.FirstOrDefault(u => u.Email == email).Password;
			}
			return password;
		}
		
		public int GetIdForEmail(string email)
		{
			int id = 0;
			using (var context = new ActivityCenterContext(_connectionString))
			{
				id = context.Users.FirstOrDefault(u => u.Email == email).Id;
			}
			return id;
		}	
	}
}
