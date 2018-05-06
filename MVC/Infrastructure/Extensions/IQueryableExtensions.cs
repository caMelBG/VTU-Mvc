using DataBase.Models;
using System.Linq;

namespace MVC.Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Student> TypedOrder(this IQueryable<Student> collection, OrderType order)
        {
            if (order == OrderType.ByFirstNameAsc)
            {
                return collection.OrderBy(x => x.FirstMidName);
            }
            else if (order == OrderType.ByLastNameAsc)
            {
                return collection.OrderBy(x => x.LastName);
            }
            else if (order == OrderType.ByFirstNameDesc)
            {
                return collection.OrderByDescending(x => x.FirstMidName);
            }
            else if (order == OrderType.ByLastNameDesc)
            {
                return collection.OrderByDescending(x => x.LastName);
            }
            else
            {
                return collection.OrderBy(x => x.EnrollmentDate);
            }
        }
    }
}