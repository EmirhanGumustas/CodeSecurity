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
// IUnitOfWork nesne yarat�caz fakat interface oldugu i�in nesne yaratam�caz. nesne yaratamam�z i�in UnitOfWork �ne s�r�p IUnitOfWork olarak nesne �a�irabilecegiz.

builder.Services.AddScoped ( typeof(IGenericRepository<>),typeof(GenericRepository<>));
// ben senden IGenericRepository isteyebilirim , bana vermen gereken GenericRepository.
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICategoryService,CategoryService>();



builder.Services.AddAutoMapper(typeof(MappingProfile));//AutoMap ekliyoruz �a�irabilmek i�in. Ve class'�n i�indekileri d�n��t�r�p bana ver.

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
 //book ad�nda bir entity olu�turun (baseentityden miras als�n name outhor Pagecount bilgileri olsun )
 //* gerekli DTOLARI olsun
 //* gerekli servis classlar�n� olu�turun
 //* controllar� olu�turun
 //* ve gerekli testleri yap�n
 //* create getall getby�d yap
 