using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shin.Services.ProductApi.DbContexts;
using Shin.Services.ProductApi.Repository.Interfaces;
using Shin.Services.ProductApi.Repository;
using System;

namespace Shin.Services.ProductApi;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShinDb")));
		IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
		builder.Services.AddSingleton(mapper);
		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		builder.Services.AddScoped<IProductRepository, ProductRepository>();
		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}