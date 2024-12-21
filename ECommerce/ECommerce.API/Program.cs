using ECommerce.Business.Abstract;
using ECommerce.Business.Concrate;
using ECommerce.Business.Mapping;
using ECommers.Data.Abstrack;
using ECommers.Data.Concrate;
using ECommers.Data.Concrate.Contexts;
using ECommers.Data.Concrate.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// IUnitOfWork nesne yaratýcaz fakat interface oldugu için nesne yaratamýcaz. nesne yaratamamýz için UnitOfWork öne sürüp IUnitOfWork olarak nesne çaðirabilecegiz.

builder.Services.AddScoped ( typeof(IGenericRepository<>),typeof(GenericRepository<>));
// ben senden IGenericRepository isteyebilirim , bana vermen gereken GenericRepository.
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICategoryService,CategoryService>();



builder.Services.AddAutoMapper(typeof(MappingProfile));//AutoMap ekliyoruz çaðirabilmek için. Ve class'ýn içindekileri dönüþtürüp bana ver.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 //book adýnda bir entity oluþturun (baseentityden miras alsýn name outhor Pagecount bilgileri olsun )
 //* gerekli DTOLARI olsun
 //* gerekli servis classlarýný oluþturun
 //* controllarý oluþturun
 //* ve gerekli testleri yapýn
 //* create getall getbyýd yap
 