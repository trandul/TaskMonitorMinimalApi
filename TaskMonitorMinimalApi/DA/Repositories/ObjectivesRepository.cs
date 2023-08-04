using Microsoft.EntityFrameworkCore;
using TaskMonitorMinimalApi.DA.EF;
using TaskMonitorMinimalApi.DA.Interfaces;
using TaskMonitorMinimalApi.Models;

namespace TaskMonitorMinimalApi.DA.Repositories
{
    public class ObjectivesRepository : IObjectiveRepository
    {
        private ApplicationContext _db;
        public ObjectivesRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(ObjectiveCreate objective)
        {
            var objectiveToDB = new Objective
            {
                Id = Guid.NewGuid(),
                Created = objective.Created,
                Expired = objective.Expired,
                Name = objective.Name,
                Priority = objective.Priority,
                Performers = _db.Users.Where(x => objective.PerformersId.Contains(x.Id)).ToArray(),
                Manager = _db.Users.FirstOrDefault(x =>x.Id==objective.ManagerId)

            };
            _db.Objectives.Add(objectiveToDB);
            _db.SaveChanges();
        }

        public void Delete(Guid entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Objective> GetAll()
        {
            return _db.Objectives
                .Include(c=>c.Performers)        
                .Include(c=>c.Manager)
                .ToList();
        }

        public Objective GetById(Guid id)
        {
            return _db.Objectives.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Objective entity)
        {
            throw new NotImplementedException();
        }
    }
}
