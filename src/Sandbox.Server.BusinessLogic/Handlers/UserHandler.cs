using System.Threading.Tasks;
using Sandbox.Server.BusinessLogic.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Handlers;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using Sandbox.Server.DomainObjects.Interfaces.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.BusinessLogic.Handlers
{
    public class UserHandler : EntityHandler<User, IEntityRepository<User>>, IUserHandler
    {
        public UserHandler(IUserRepository repository) : base(repository)
        {
        }


        public async Task<User> Create(User instance)
        {
            // TODO hash password

            return await _repository.Create(instance);
        }

    }
}