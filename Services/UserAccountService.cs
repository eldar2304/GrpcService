using Grpc.Core;
using GrpcService.Models;

namespace GrpcService.Services
{

    public class UserAccountService : UserAccount.UserAccountBase
    {
        private readonly ILogger<UserAccountService> _logger;
        public UserAccountService(ILogger<UserAccountService> logger)
        {
            _logger = logger;
        }


        public override Task<UserReply> GetUserById(UserRequest request, ServerCallContext context)
        {
            ApplicationContext contextDb = new ApplicationContext();
            Client res = contextDb.Clients.Where(x => x.Id == request.Id).ToList().FirstOrDefault(new Client());

            return Task.FromResult(new UserReply
            {
                Name = res.Name,
                Phone = res.Phone
            });
            
        }
    }
}