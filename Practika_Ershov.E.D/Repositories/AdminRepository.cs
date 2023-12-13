using Practika_Ershov.E.D.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practika_Ershov.E.D.Repositories
{
    public class AdminRepository : RepositoryBase, IAdminInterface
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public bool AuthenticateAdmin(NetworkCredential credential)
        {
            bool validAdmin;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from[admins] where username=@username and [password]=@password";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                validAdmin = command.ExecuteScalar() == null ? false : true;
            }
            return validAdmin;
        }
        public bool AuthenticateUser(NetworkCredential credential)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdminModel> GetByAll()
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
    }
}
