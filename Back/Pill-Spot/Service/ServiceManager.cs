using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {


        public ServiceManager(IRepositoryManager repositoryManager, ILogger<IServiceManager> logger, UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            
        }

    }
}
