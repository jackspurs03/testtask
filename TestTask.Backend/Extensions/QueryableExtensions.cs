using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TestTask.Backend.Args;

namespace TestTask.Backend.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> source, IPageArgs args)
        {
            if (args.Page == 0) return source;

            return source.Skip((args.Page - 1) * args.PageSize).Take(args.PageSize);
        }

        public static IQueryable<T> OrderByColumn<T>(this IQueryable<T> source, IOrderedArgs args) where T : class
        {
            if (args.OrderBy == null) return source;
            if (args.OrderBy.IsNullOrEmpty()) return source;
            if (typeof(T).GetProperty(args.OrderBy) == null) throw new Exception($"Ошибка при сортировке. Поля \"{args.OrderBy}\" не существует");

            return source.OrderBy(p => EF.Property<object>(p, args.OrderBy));
        }
    }
}
