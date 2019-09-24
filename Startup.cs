﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ResearchPillDiary.Entities;
//using ResearchPillDiary.Entities;

namespace ResearchPillDiary
{
    public class Startup
    {
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<PillDiaryTContext>();
            
        //    services.AddMvc()
        //      .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        //}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PillsDiaryContext>();
            services.AddScoped<IPillsDiaryRepository, PillsDiaryRepository>();

            services.AddMvc()                
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpClient();
            
            services.AddDbContext<PillsDiaryContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("ScribeDatabase")));
             
            }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
