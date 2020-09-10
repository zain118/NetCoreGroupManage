using DevAl.Play.GroupManage.Business.Models;
using DevAl.Play.GroupManage.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAl.Play.GroupManage.Web.Mappings
{
    public static class GroupMappings
    {
        public static GroupViewModel ToViewModel(this Group group)
        {
            if(group != null)
            {
                GroupViewModel gvm = new GroupViewModel();
                gvm.Id = group.Id;
                gvm.Name = group.Name;
                return gvm;
            }
            return null;
        }
        public static Group ToGroup(this GroupViewModel gvm)
        {
            return gvm != null ?  new Group(){ Id = gvm.Id, Name = gvm.Name } : null;
        }

        public static IReadOnlyCollection<GroupViewModel> ToViewModelCollection(this IReadOnlyCollection<Group> groups)
        {
            if(groups.Count == 0)
            {
                return Array.Empty<GroupViewModel>();
            }
            else
            {
                GroupViewModel[] gvms = new GroupViewModel[groups.Count];
                for (int i = 0; i < groups.Count; i++)
                {
                    gvms[i] = groups.ElementAt(i).ToViewModel();
                }
                return new ReadOnlyCollection<GroupViewModel>(gvms);
            }
        }
    }
}
