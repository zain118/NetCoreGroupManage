using Autofac;
using DevAl.Play.GroupManage.Business.Models;
using DevAl.Play.GroupManage.Business.Services;
using DevAl.Play.GroupManage.BusinessImpl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAl.Play.GroupManage.Web.IOC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //To Use the DI directly
           // builder.RegisterType<GroupService>().As<IGroupServices>().SingleInstance();

            //To Use Decorator
            builder.RegisterType<GroupService>().Named<IGroupServices>("named").SingleInstance();
            builder.RegisterDecorator<IGroupServices>((context, service) => new GroupServiceDecorator(service), "named");
        }
        /// <summary>
        /// Decorator For AutoFac
        /// </summary>
        private class GroupServiceDecorator : IGroupServices
        {
            private readonly IGroupServices _inner;

            public GroupServiceDecorator(IGroupServices inner)
            {
                _inner = inner;
            }
            public bool AddGroup(Group group)
            {
                return _inner.AddGroup(group);
            }

            public bool DelGroup(int id)
            {
                return _inner.DelGroup(id);
            }

            public bool EditGroup(Group group)
            {
                return _inner.EditGroup(group);
            }

            public IReadOnlyCollection<Group> GetAllGroups()
            {
                return _inner.GetAllGroups();
            }

            public Group GetGroupById(int Id)
            {
                return _inner.GetGroupById(Id);
            }
        }
    }
}
