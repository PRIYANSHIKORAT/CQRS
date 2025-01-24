using AutoMapper;
using CleanArchWithCQRSandMediator.Domain.Entity;
using System.Reflection;
using CleanArchWithCORSandMediator.Application.Common.Mappings;
using CleanArchWithCORSandMediator.Application.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

        CreateMap<Blog, BlogDto>().ReverseMap();
        CreateMap<BlogPost, BlogPostDto>()
            .ForMember(dest => dest.PublishDate, opt =>
                opt.MapFrom(src => src.PublishDate.HasValue
                    ? src.PublishDate.Value.ToString("yyyy-MM-dd")
                    : null)); 
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var mapFromType = typeof(IMapFrom<>);

        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapFromType))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var method = type.GetMethod("Mapping")
                ?? type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapFromType)
                    ?.GetMethod("Mapping");

            method?.Invoke(instance, new object[] { this });
        }
    }
}







//using AutoMapper;
//using CleanArchWithCORSandMediator.Application.Blogs.Quaries.GetBlog;
//using CleanArchWithCORSandMediator.Application.Blogs.Queries.GetBlog;
//using CleanArchWithCORSandMediator.Application.Common.Mappings;
//using CleanArchWithCQRSandMediator.Domain.Entity;
//using System.Reflection;

//public class MappingProfile : Profile
//{
//    public MappingProfile()
//    {
//        ApplyMappingsFromAssemly(Assembly.GetExecutingAssembly());
//        CreateMap<BlogPost, BlogPostVm>();
//        CreateMap<Blog, BlogVm>();
//    }
//    private void ApplyMappingsFromAssemly(Assembly assembly)
//    {
//        var mapFormType = typeof(IMapFrom<>);
//        var mappingMethodName = nameof(IMapFrom<object>);
//        bool hasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFormType;
//        var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(hasInterface)).ToList();
//        var argumentTypes = new Type[] { typeof(Profile) };

//        foreach (var type in types)
//        {
//            var instance = Activator.CreateInstance(type);
//            var methodInfo = type.GetMethod(mappingMethodName);

//            if (methodInfo != null)
//            {
//                methodInfo.Invoke(instance, new object[] { this });
//            }
//            else
//            {
//                var interfaces = type.GetInterfaces().Where(hasInterface).ToList();
//                foreach (var @interface in interfaces)
//                {
//                    var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);
//                    interfaceMethodInfo?.Invoke(instance, new object[] { this });
//                }
//            }
//        }
//    }
//}
