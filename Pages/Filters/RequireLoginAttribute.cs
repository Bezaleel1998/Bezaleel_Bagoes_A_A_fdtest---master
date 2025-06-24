using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Bezaleel_Bagoes_A_A_fdtest.Data;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Filters
{
    public class RequireLoginAttribute : Attribute, IPageFilter
    {
        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                context.Result = new RedirectToPageResult("/Index");
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }
    }
}
