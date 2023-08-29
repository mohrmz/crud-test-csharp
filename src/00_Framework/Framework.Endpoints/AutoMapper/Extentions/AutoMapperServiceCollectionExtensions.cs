using Framework.Endpoints.AutoMapper.Contracts;
using Framework.Endpoints.AutoMapper.Options;
using Framework.Endpoints.AutoMapper.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace Framework.Endpoints.AutoMapper.Extentions;

public static class AutoMapperServiceCollectionExtensions
{
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        return services.AddAutoMapperProfiles(configuration.GetSection(sectionName));
    }

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration)
    {
        List<Assembly> assemblies = GetAssemblies(configuration.Get<AutoMapperOption>()!.AssmblyNamesForLoadProfiles);
        return services.AddAutoMapper(assemblies).AddSingleton<IMapperAdapter, AutoMapperAdapter>();
    }

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, Action<AutoMapperOption> setupAction)
    {
        AutoMapperOption autoMapperOption = new AutoMapperOption();
        setupAction(autoMapperOption);
        List<Assembly> assemblies = GetAssemblies(autoMapperOption.AssmblyNamesForLoadProfiles);
        return services.AddAutoMapper(assemblies).AddSingleton<IMapperAdapter, AutoMapperAdapter>();
    }

    private static List<Assembly> GetAssemblies(string assmblyNames)
    {
        List<Assembly> list = new List<Assembly>();
        foreach (RuntimeLibrary runtimeLibrary in DependencyContext.Default!.RuntimeLibraries)
        {
            if (IsCandidateCompilationLibrary(runtimeLibrary, assmblyNames.Split(',')))
            {
                Assembly item = Assembly.Load(new AssemblyName(runtimeLibrary.Name));
                list.Add(item);
            }
        }

        return list;
    }

    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assmblyName)
    {
        RuntimeLibrary compilationLibrary2 = compilationLibrary;
        string[] assmblyName2 = assmblyName;
        if (!assmblyName2.Any((d) => compilationLibrary2.Name.Contains(d)))
        {
            return compilationLibrary2.Dependencies.Any((d) => assmblyName2.Any((c) => d.Name.Contains(c)));
        }

        return true;
    }
}