using TaskMonitorMinimalApi.Models;

namespace TaskMonitorMinimalApi.DA.Interfaces
{
    public interface IObjectiveRepository
    {
        IEnumerable<Objective> GetAll();
        Objective GetById(Guid id);
        void Add(ObjectiveCreate objective);
        void Update(Objective entity);
        void Delete(Guid entity);
    }
}
