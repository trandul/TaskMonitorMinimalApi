using TaskMonitorMinimalApi.DA.Entities;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.DA.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<JobDTO>> GetAll();
        Task<Job?> GetById(Guid id);
        Task Add(JobCreateDTO jobDTO);
        Task Update(JobUpdateDTO jobDTO);
        void Delete(Guid entity);
    }
}
