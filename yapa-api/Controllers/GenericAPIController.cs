using Microsoft.AspNetCore.Mvc;
using System;
using yapa_api.Contracts;

namespace yapa_api.Controllers
{
    [ApiController]
    public abstract class GenericAPIController<T> : ControllerBase where T: class, IEntity
    {
        private readonly IRepository<T> _repository;
        public GenericAPIController(IRepository<T> repository)
        {
            _repository = repository;
        }
        
    }
}
