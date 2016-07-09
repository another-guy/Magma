using Microsoft.AspNetCore.Mvc;

namespace Magma.AspNetCore.Mvc
{
    public interface IUserIdProvider
    {
        string GetUserId(Controller controller);
    }
}
