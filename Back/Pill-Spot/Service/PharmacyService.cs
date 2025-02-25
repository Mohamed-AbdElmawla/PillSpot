using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed  class PharmacyService : IPharmacyService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        public PharmacyService(IRepositoryManager repository, IMapper mapper,
            UserManager<User> userManager, IFileService fileService = null)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
        }
    }
}
