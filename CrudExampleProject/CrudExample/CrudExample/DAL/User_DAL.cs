using System.Data.SqlClient;
using System.Configuration;
using CrudExample.Models;
using System.Reflection.PortableExecutable;

namespace CrudExample.DAL
{
	public class User_DAL
	{
		string conString = "Server=DESKTOP-705H4SM;Database=ProductManagement;Trusted_Connection=True";
        public bool AddUser(User user)
		{
			int UserLoginCheck = 0;
			using (SqlConnection connection = new SqlConnection(conString))
			{
				SqlCommand command = new SqlCommand("AddUser", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@UserName", user.UserName);
				command.Parameters.AddWithValue("@Password", user.Password);
				connection.Open();
				UserLoginCheck = command.ExecuteNonQuery();
				connection.Close();
			}
			if (UserLoginCheck > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		//UpdateUser
		public bool UpdateUser(User user)
		{
			int UserLoginCheck = 0;
			using (SqlConnection connection = new SqlConnection(conString))
			{
				SqlCommand command = new SqlCommand("UpdateUser", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@UserID", user.UserID);
				command.Parameters.AddWithValue("@UserName", user.UserName);
				command.Parameters.AddWithValue("@Password", user.Password);
				connection.Open();
				UserLoginCheck = command.ExecuteNonQuery();
				connection.Close();
			}
			if (UserLoginCheck > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		//DeleteUser
		public bool DeleteUser(User user)
		{
			int UserLoginCheck = 0;
			using (SqlConnection connection = new SqlConnection(conString))
			{
				SqlCommand command = new SqlCommand("DeleteUser", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@UserID", user.UserID);
				connection.Open();
				UserLoginCheck = command.ExecuteNonQuery();
				connection.Close();
			}
			if (UserLoginCheck > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool GetUser(User user)
		{
			int UserLoginCheck = 0;
			using (SqlConnection connection = new SqlConnection(conString))
			{
				SqlCommand command = new SqlCommand("GetUser", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@UserName", user.UserName);
				command.Parameters.AddWithValue("@Password", user.Password);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					return true;
				}
				else
				{
					return false;
				}
				connection.Close();
			}

		}
	}


}
