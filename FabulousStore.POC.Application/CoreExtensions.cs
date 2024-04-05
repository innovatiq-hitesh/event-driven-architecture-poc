using FabulousStore.POC.Core.Abstractions.Services;
using FabulousStore.POC.Core.Abstractions.Utils;
using FabulousStore.POC.Core.DomainTransferObjects;
using FabulousStore.POC.Core.Services;
using FabulousStore.POC.Core.Utils;
using FabulousStore.POC.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FabulousStore.POC.Core
{
    public static class CoreExtensions
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //If Need to Add Auto Validations
           // services.AddFluentValidationAutoValidation(opt =>
           // {
           //     opt.DisableDataAnnotationsValidation = true;
           // })
           //.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton<IDispatcher, Dispatcher>();

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITenantService, TenantService>();

            services.AddTransient<IValidator<TransactionRequestDTO>, TransactionRequestValidator>();
        }
    }
}
