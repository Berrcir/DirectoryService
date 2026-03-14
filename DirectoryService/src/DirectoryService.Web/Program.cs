using DirectoryService.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgramDependencies(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DirectoryService"));
}

app.Run();
