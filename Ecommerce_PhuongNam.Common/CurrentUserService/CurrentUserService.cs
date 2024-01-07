using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam.Common.CurrentUserService;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    // public string IdUser => _httpContextAccessor.HttpContext.User.Claims
    public string IdUser { get; }
}