using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Context;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services;
using Programatica.Framework.Services.Handlers;
using Programatica.Framework.Services.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsDotNetCore.Context;
using WindowsFormsDotNetCore.Models;


//https://www.thecodebuzz.com/dependency-injection-net-core-windows-form-generic-hostbuilder/

namespace WindowsFormsDotNetCore
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ///Generate Host Builder and Register the Services for DI
            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddDbContext<IDbContext, AppDbContext>(opt =>
                   {
                       opt.UseSqlServer("Server=localhost;Database=TestWinForms;Trusted_Connection=True;");
                   });

                   services.AddSingleton<Form1>();
                   services.AddSingleton<Form2>();

                   // repository
                   services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

                   // adapters
                   services.AddTransient<IDateTimeAdapter, DateTimeAdapter>();
                   services.AddTransient<IAuthUserAdapter, AuthUserAdapter>();
                   services.AddTransient<IJsonSerializerAdapter, JsonSerializerAdapter>();

                   // event handler
                   services.AddTransient<IEventHandler<User>, AuditEventHandler<User>>();
                   services.AddTransient<IList<IEventHandler<User>>>(p => p.GetServices<IEventHandler<User>>().ToList());
                   services.AddTransient<IList<IEventHandler<TrackChange>>>(p => p.GetServices<IEventHandler<TrackChange>>().ToList());

                   // injector
                   services.AddTransient(typeof(IInjector<>), typeof(Injector<>));

                   // service
                   services.AddTransient(typeof(IService<>), typeof(Service<>));
               });

            var host = builder.Build();


            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {

                    var form1 = services.GetRequiredService<Form1>();
                    Application.Run(form1);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }

















            //Application.Run(new Form1());
        }
    }
}
