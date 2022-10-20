using Microsoft.AspNetCore.Mvc.Filters;

namespace ApWithFilter.Filters
{
    public class MyCustomFilter: Attribute, IActionFilter, IOrderedFilter
    {
        private readonly string _filterName;
        public int Order { get; set; }

        public MyCustomFilter(string name, int order=-1)
        {
            _filterName = name;
            Order = order;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("My Custom Action filter before action executed " + _filterName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("My custom Action Filter after action executed " + _filterName);
        }
    }
}
