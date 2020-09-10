using DevAl.Play.GroupManage.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevAl.Play.GroupManage.Business.Services
{
    public class GroupService : IGroupServices
    {
        static List<Group> groups = new List<Group> { new Group { Id = 1, Name = "Man UTD" } };
        public bool AddGroup(Group group)
        {
            Group g = groups.Skip(groups.Count - 1).LastOrDefault();
            group.Id = g == null ? 1 : g.Id + 1;
            groups.Add(group);
            return true;
        }

        public bool DelGroup(int id)
        {
            groups.Remove(groups.FirstOrDefault(r => r.Id == id));
            return true;
        }

        public bool EditGroup(Group group)
        {
            groups.FirstOrDefault(r => r.Id == group.Id).Name = group.Name;
            return true;
        }

        public IReadOnlyCollection<Group> GetAllGroups()
        {
            return groups;
        }

        public Group GetGroupById(int Id)
        {
            return groups.FirstOrDefault(r => r.Id == Id);
        }
    }
}
