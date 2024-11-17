using System;
using System.Net;
using System.Text.Json;
using KikoStore.Api.Errors;

namespace KikoStore.Api.Middleware;

public class ExceptionMiddleware(IHostEnvironment environment,RequestDelegate next){

    public async Task InvokeAsync(HttpContext context){
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            
            await HandleExceptionAsync(context,ex,environment);
        }
    }


    private  static Task HandleExceptionAsync
    (HttpContext context,Exception ex,IHostEnvironment environment){
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        var stackTrace = ex.StackTrace ?? string.Empty;
        var response = environment.IsDevelopment()?
        new ApiErrorResponse(context.Response.StatusCode,ex.Message,stackTrace)
        : new ApiErrorResponse(context.Response.StatusCode,ex.Message,"internal Server error");

        var options  = new JsonSerializerOptions{PropertyNamingPolicy= JsonNamingPolicy.CamelCase};

        var json=  JsonSerializer.Serialize(response , options);
        return context.Response.WriteAsync(json);
    }
}
