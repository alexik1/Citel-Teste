using AutoMapper;
using Citel_Teste_Api.Dto;
using Citel_Teste_Core.Interfaces;
using Citel_Teste_Core.Services;
using Citel_Teste_Entity.Models;
using Citel_Teste_Infrastructure;
using Citel_Teste_Infrastructure.Interfaces;
using Citel_Teste_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Citel_Teste_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoDTO>().ReverseMap();
                cfg.CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var connection = Configuration.GetConnectionString(nameof(CitelDbContext));
            services.AddDbContext<CitelDbContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
            services.AddScoped<DbContext, CitelDbContext>();

            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<ICategoriaService, CategoriaService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Citel-Test API",
                    Description = "An ASP.NET Core Web API for managing the Citel-Test items.",
                    Contact = new OpenApiContact
                    {
                        Name = "Alessandro's Email",
                        Url = new Uri("mailto:alessandroromulocorrea@gmail.com")
                    }
                });
            });
        }
    }
}
