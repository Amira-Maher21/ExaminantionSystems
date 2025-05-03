using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.middleware
{
    public class GlobalErrorHandling
    {
         RequestDelegate _next;

        public GlobalErrorHandling(RequestDelegate next)
        {
            _next = next;
            
        }

        // 
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                     
                 
            }
        }
    }
}
