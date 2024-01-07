using AutoMapper;
using BusBookTicket.AddressManagement.Services.RegionService;
using BusBookTicket.AddressManagement.Services.UnitService;
using Ecommerce_PhuongNam.Address.Address.Application.Common.Mapper;
using Ecommerce_PhuongNam.Address.Address.Application.Services.DistrictService;
using Ecommerce_PhuongNam.Address.Address.Application.Services.ProvinceService;
using Ecommerce_PhuongNam.Address.Address.Application.Services.RegionService;
using Ecommerce_PhuongNam.Address.Address.Application.Services.UnitService;
using Ecommerce_PhuongNam.Address.Address.Application.Services.WardService;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.Repositories;
using Ecommerce_PhuongNam.Common.CurrentUserService;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

#region -- Config auto mapping --

var mappingProfileConfigs = new MapperConfiguration(cfp => cfp.AddProfile(new MappingProfile()));
IMapper mapper = mappingProfileConfigs.CreateMapper();
services.AddSingleton(mapper);

services.AddAuthorization();
services.AddControllers();
services.AddEndpointsApiExplorer();
#endregion -- Config auto mapping --

#region -- Scoped --
services.AddSingleton<ICurrentUserService, CurrentUserService>();
services.AddScoped<IRegionService, RegionService>();
services.AddScoped<IUnitService, UnitService>();
services.AddScoped<IProvinceService, ProvinceService>();
services.AddScoped<IDistrictService, DistrictService>();
services.AddScoped<IWardService, WardService>();
services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion -- Scoped --

services.AddDbContext<AddressDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AddressDB")));

services.AddHttpContextAccessor();

var app = builder.Build();
app.UseRouting();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
    endpoints.MapControllers()) ;
app.Run();