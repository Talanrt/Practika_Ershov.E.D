using Practika_Ershov.E.D.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Practika_Ershov.E.D.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection= connection;
                command.CommandText = "select *from[User] where Username=@Username and [Password]=@Password";
                command.Parameters.Add("@Username",System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
                return validUser;
        }
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand("select * from [User]", connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserModel
                        {
                            Id = Convert.ToInt32(reader["Id"]).ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
      

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(string ChangeLoginUser,string ChangePassword, string ChangeNameUser, string ChangeFamilyaUser, string ChangePochtaUser)
        {
            
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "UPDATE [User] SET Password = @Password,  Email = @Email, Name = @Name,LastName = @LastName where Username = @Username";
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = ChangeLoginUser;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = ChangePassword;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ChangeNameUser;
                    command.Parameters.Add("@LastName", SqlDbType.NChar).Value = ChangeFamilyaUser;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ChangePochtaUser;
                    command.ExecuteNonQuery();
                }
            
        }
    }
}
