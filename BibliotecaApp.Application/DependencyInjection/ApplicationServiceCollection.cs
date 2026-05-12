using BibliotecaApp.Application.Features.Books.Interfaces;
using BibliotecaApp.Application.Features.Books.Services;
using BibliotecaApp.Application.Features.Categories.Interfaces;
using BibliotecaApp.Application.Features.Categories.Services;
using BibliotecaApp.Application.Features.Customers.Interfaces;
using BibliotecaApp.Application.Features.Customers.Services;
using BibliotecaApp.Application.Features.Loans.Interfaces;
using BibliotecaApp.Application.Features.Loans.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaApp.Application.DependencyInjection;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {

        services.AddCustomerServices();
        services.AddCategoryServices();
        services.AddBookServices();
        services.AddLoanServices();
        return services;
    }


    private static IServiceCollection AddCustomerServices(this IServiceCollection services)
    {
        services.AddScoped<IGetAllCustomersService, GetAllCustomersService>();
        services.AddScoped<IGetCustomerByIdService, GetCustomerByIdService>();
        services.AddScoped<ICreateCustomerService, CreateCustomerService>();
        services.AddScoped<IUpdateCustomerService, UpdateCustomerService>();
        services.AddScoped<IDeleteCustomerService, DeleteCustomerService>();

        return services;

    }

    private static IServiceCollection AddCategoryServices(this IServiceCollection services)
    {
        services.AddScoped<IGetAllCategoriesService, GetAllCategoriesService>();
        services.AddScoped<IGetCategoryByIdService, GetCategoryByIdService>();
        services.AddScoped<ICreateCategoryService, CreateCategoryService>();
        services.AddScoped<IUpdateCategoryService, UpdateCategoryService>();
        services.AddScoped<IDeleteCategoryService, DeleteCategoryService>();

        return services;
    }

    private static IServiceCollection AddBookServices(this IServiceCollection services)
    {
        services.AddScoped<IGetAllBooksService, GetAllBooksService>();
        services.AddScoped<IGetBookByIdService, GetBookByIdService>();
        services.AddScoped<ICreateBookService, CreateBookService>();
        services.AddScoped<IUpdateBookService, UpdateBookService>();
        services.AddScoped<IDeleteBookService, DeleteBookService>();

        services.AddHttpClient<IExternalBookService, ExternalBookService>(client =>
        {
            client.BaseAddress = new Uri("https://openlibrary.org/");
        });

        return services;
    }

    private static IServiceCollection AddLoanServices(this IServiceCollection services)
    {
        services.AddScoped<IGetAllLoansService, GetAllLoansService>();
        services.AddScoped<IGetLoanByIdService, GetLoanByIdService>();
        services.AddScoped<ICreateLoanService, CreateLoanService>();
        services.AddScoped<IReturnLoanService, ReturnLoanService>();
        services.AddScoped<IRenewLoanService, RenewLoanService>();
        return services;
    }
}
