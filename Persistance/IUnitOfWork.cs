using System.Threading.Tasks;

namespace TechAche.Persistance
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}