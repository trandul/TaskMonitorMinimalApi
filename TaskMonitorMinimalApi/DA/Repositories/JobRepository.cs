using Microsoft.EntityFrameworkCore;
using TaskMonitorMinimalApi.DA.EF;
using TaskMonitorMinimalApi.DA.Entities;
using TaskMonitorMinimalApi.DA.Interfaces;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.DA.Repositories
{
    public class JobsRepository : IJobRepository
    {
        private ApplicationContext _db;
        private readonly IServiceScopeFactory _scopeFactory;
        public JobsRepository(IServiceScopeFactory scopeFactory)
        {
            //_db = db;
            _scopeFactory = scopeFactory;
            _db = _scopeFactory.CreateAsyncScope().ServiceProvider.GetService<ApplicationContext>();
        }

        public async Task Add(JobCreateDTO jobDTO)
        {
            //TODO: добавить проверки
            //using (var scope = _scopeFactory.CreateAsyncScope())
            {
                //var _dbContext = scope.ServiceProvider.GetService<ApplicationContext>();
                var job = new Job(jobDTO);
                if (jobDTO.PerformersLogins == null)
                    job.Performers = await _db.Users.Where(x => jobDTO.PerformersLogins.Contains(x.Login)).ToArrayAsync();
                job.Manager = await _db.Users.FirstOrDefaultAsync(x => x.Login == jobDTO.ManagerLogin);
                await _db.Jobs.AddAsync(job);
                await _db.SaveChangesAsync();
            }

        }

        public void Delete(Guid entity)
        {
            //TODO: добавить проверки
            var job = _db.Jobs.FirstOrDefault(x => x.Id == entity);
            if (job != null)
            {
                _db.Jobs.Remove(job);
            }
        }

        public async Task<IEnumerable<JobDTO>> GetAll()
        {
            //TODO: добавить проверки
            var jobs = await _db.Jobs
                .Include(c => c.Performers)
                    .ThenInclude(x => x.Role)
                .Include(c => c.Manager)
                    .ThenInclude(x => x.Role)
                .Select(x => new JobDTO(x))
                .ToListAsync();
            return jobs;
        }

        public async Task<Job?> GetById(Guid id)
        {
            //TODO: добавить проверки
            return await _db.Jobs
                .Include(c => c.Performers)
                    .ThenInclude(x => x.Role)
                .Include(c => c.Manager)
                    .ThenInclude(x => x.Role)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(JobUpdateDTO jobDTO)
        {
            //TODO: добавить проверки
            var job = await _db.Jobs.FirstOrDefaultAsync(x => x.Id == jobDTO.Id);
            job.Name = jobDTO.Name;
            job.Expired = jobDTO.Expired;
            job.Priority = jobDTO.Priority;
            job.Manager = await _db.Users.FirstOrDefaultAsync(x => x.Login == jobDTO.ManagerLogin);
            job.Performers = await _db.Users.Where(x => jobDTO.PerformersLogins.Contains(x.Login)).ToArrayAsync();
            await _db.SaveChangesAsync();
        }
    }
}
