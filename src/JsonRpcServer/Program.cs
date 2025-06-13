using ApiService.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// �}�o���ҫ�ĳ�}�ҸԲӿ��~����
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// ��ݵ{����l��
app.BackendInitialize(app.Configuration);

app.Run();
