²����routing �i�H�z�L Map�F���A�d�Ҧp�U
// ...
public class Startup
{
    // ...
    public void Configure(IApplicationBuilder app)
    {
        // ...
        app.Map("/first", mapApp =>
        {
            mapApp.Run(async context =>
            {
                await context.Response.WriteAsync("First. \r\n");
            });
        });
        app.Map("/second", mapApp =>
        {
            mapApp.Run(async context =>
            {
                await context.Response.WriteAsync("Second. \r\n");
            });
        });
    }
}

1.�[�J Routing ���A�ȡG
�b Startup.cs �� ConfigureServices���[�Jservices.AddRouting();

