using DirectoryService.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgramDependencies();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DirectoryService"));
}

app.Run();
