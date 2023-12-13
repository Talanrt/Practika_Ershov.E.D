using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practika_Ershov.E.D.Models
{
    public interface IAdminInterface
    {
        bool AuthenticateAdmin(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<AdminModel> GetByAll();
       
    }
}
