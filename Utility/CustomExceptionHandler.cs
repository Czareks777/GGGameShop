using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace GGameShop.Utility
{
    public class CustomExceptionHandler
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomExceptionHandler(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult HandleException()
        {
            var exceptionHandlerPathFeature =
                _httpContextAccessor.HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (_env.IsDevelopment())
            {
                
                return new ObjectResult(new { error = exceptionHandlerPathFeature.Error })
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
            else
            {
               
                return new ObjectResult(new { error = "Wystąpił błąd. Spróbuj ponownie później." })
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }
    }
}
