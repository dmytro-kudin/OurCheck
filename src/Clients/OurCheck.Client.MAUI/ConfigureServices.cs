// using System.ComponentModel;
//
// namespace OurCheck.Client.MAUI;
//
// public static class ConfigureServices
// {
//     private const int NameRemoveCount = 4;
//
//     extension(IServiceCollection services)
//     {
//         /// <summary>
//         /// Extension method. Registers every available View and ViewModel using type deduction and naming convention.
//         /// </summary>
//         public IServiceCollection RegisterPresentationModels()
//         {
//             // Get the assembly where your views and view models are located
//             var assembly = typeof(MainPage).Assembly;
//
//             // Register all views and view models using reflection
//             foreach (var type in assembly.GetTypes())
//             {
//                 // Check if the type is a view
//                 // if (type.BaseType == typeof(HeaderFooterPage))
//                 // {
//                 //     services.AddSingleton(type);
//                 // }
//
//                 // Check if the type is a view model
//                 if (type.Name.EndsWith("ViewModel") && type.GetInterfaces()
//                         .Contains(typeof(INotifyPropertyChanged)))
//                 {
//                     services.AddSingleton(type);
//                 }
//             }
//
//             return services;
//         }
//
//         /// <summary>
//         /// Extension method. Registers every available navigation route using naming conventions
//         /// </summary>
//         public IServiceCollection RegisterRoutes()
//         {
//             // foreach (var (routeName, pageType) in
//             //          // Routes are naming convention based.
//             //          services.Where(type => type.ServiceType.BaseType == typeof(HeaderFooterPage))
//             //              .Select(cPage =>
//             //              {
//             //                  var nameOfPage = cPage.ServiceType.Name;
//             //                  var routeName = nameOfPage.Remove(nameOfPage.Length - NameRemoveCount, NameRemoveCount) +
//             //                                  "ViewModel";
//             //                  var pageType = cPage.ServiceType;
//             //                  return (routeName, pageType);
//             //              }))
//             // {
//             //     Routing.RegisterRoute(routeName, pageType);
//             // }
//             return services;
//         }
//
//         public IServiceCollection RegisterPresentationServices()
//         {
//             // services.AddSingleton<INavigationService, MauiNavigationService>();
//
//             return services;
//         }
//     }
// }