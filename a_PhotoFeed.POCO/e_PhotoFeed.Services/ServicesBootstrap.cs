using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using c_PhotoFeed.Repository.Implementations;
using c_PhotoFeed.Repository.Interfaces;
using e_PhotoFeed.Services.Implementations;
using e_PhotoFeed.Services.Interfaces;
using e_PhotoFeed.Services.Mappers;
using Unity;

namespace e_PhotoFeed.Services
{
    public class ServicesBootstrap
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>(); 
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static UnityContainer ConfigureUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            return container;
        }
    }
}
