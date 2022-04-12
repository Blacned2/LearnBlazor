using LearnBlazor.Context;

namespace LearnBlazor.AppService.Services
{
    public abstract class BaseAppService
    {
        public readonly BlazorDbContext _context;
        public BaseAppService(BlazorDbContext context)
        {
            this._context = context;
        }
    }
}
