using Microsoft.AspNetCore.Mvc;
using Magma.Security.Claims;

namespace Magma.AspNetCore.Mvc
{
    public sealed class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(Controller controller)
        {
            return controller.User.Identity.GetNameId();
        }
    }
}
