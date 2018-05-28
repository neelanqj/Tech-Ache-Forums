using System.Collections.Generic;

namespace TechAche.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public int TotalItems {get;set;}
        public IEnumerable<T> Items {get;set;}
    }
}