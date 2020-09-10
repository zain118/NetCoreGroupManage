using DevAl.Play.GroupManage.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAl.Play.GroupManage.Business.Services
{
    public interface IGroupServices
    {
        Group GetGroupById(int Id);
        IReadOnlyCollection<Group> GetAllGroups();
        bool EditGroup(Group group);
        bool DelGroup(int id);
        bool AddGroup(Group group);

}
}
