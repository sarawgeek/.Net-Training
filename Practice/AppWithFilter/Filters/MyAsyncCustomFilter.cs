using Microsoft.AspNetCore.Mvc.Filters;

namespace AppWithFilter.Filters
{
    public class MyAsyncCustomFilter : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public MyAsyncCustomFilter(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("My Async Action filter before action executed " + _name);

            await next();

            Console.WriteLine("My Async Action filter after action executed " + _name);
        }
    }
}
