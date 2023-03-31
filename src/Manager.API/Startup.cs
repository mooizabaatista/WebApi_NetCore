using AutoMapper;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Manager.Infra.Repositories;
using Manager.Services.Interfaces;
using Manager.Services.Products.Commands;
using Manager.Services.Products.Queries;
using Manager.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using MediatR;
using Manager.Services.Dtos;

namespace Manager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manager.API", Version = "v1" });
            });

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoDto, Produto>().ReverseMap();
                cfg.CreateMap<ProdutoDtoFlat, Produto>().ReverseMap();
                cfg.CreateMap<CategoriaDto, Categoria>().ReverseMap();
                cfg.CreateMap<CategoriaDtoFlat, Categoria>().ReverseMap();

                cfg.CreateMap<ProductCreateCommand, Produto>().ReverseMap();
                cfg.CreateMap<ProductCreateCommand, ProdutoDto>().ReverseMap();
                cfg.CreateMap<ProductCreateCommand, ProdutoDtoFlat>().ReverseMap();

                cfg.CreateMap<ProductUpdateCommand, Produto>().ReverseMap();
                cfg.CreateMap<ProductUpdateCommand, ProdutoDto>().ReverseMap();
                cfg.CreateMap<ProductUpdateCommand, ProdutoDtoFlat>().ReverseMap();

                cfg.CreateMap<ProductDeleteCommand, Produto>().ReverseMap();

                cfg.CreateMap<GetProductQuery, Produto>().ReverseMap();
                cfg.CreateMap<GetProductQuery, ProdutoDto>().ReverseMap();
                cfg.CreateMap<GetProductByIdQuery, Produto>().ReverseMap();
                cfg.CreateMap<GetProductByIdQuery, ProdutoDto>().ReverseMap();

            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            services.AddDbContext<ManagerContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:USER_MANAGER"]));
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            var handlers = AppDomain.CurrentDomain.Load("Manager.Services");
            services.AddMediatR(handlers);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
