var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) => {
    //getting request url 
    var path = context.Request.Path;
    // getting request method
    var method = context.Request.Method;
    // return "Hello World!" + method ;
    //getting user-agent(who made request)
    var userAgent = "";
    if (context.Request.Headers.ContainsKey("User-Agent")) {
        userAgent = context.Request.Headers["User-Agent"];
    }
    //  return "hello " + userAgent;
    //setting response header
    context.Response.Headers["Content-Type"] = "text/html";
    return "hello world";
});
app.Run(async(HttpContext context) =>
{
    /*await context.Response.WriteAsync("Hello from server");*/
    string path = context.Request.Path;

    if(path == "/" || path == "/Home")
    {
        context.Response.StatusCode = 200;//setting up http status code for success
        await context.Response.WriteAsync("you are in home");
    }
    else
    {
        context.Response.StatusCode = 404;//setting http status code for page not found
        await context.Response.WriteAsync("page not found");
    }
});

app.Run();
