using CRUD_Operation.Models;
using CRUD_Operation.ViewModel;

namespace CRUD_Operation.Inferfaces
{
    public interface IJobService
    {
        // List all Jobs
        Task<List<Job>> GetJobs();

        // Get job by Id
        Task<Job> GetJobById(Guid Id);

        //Add job
        Task<Job> AddJob(JobViewModel jobView);

        // Update Job 
        Task<Job> UpdateJob(Job job);

        // Delete by Id
        Task DeleteJob(Job job);

    }
}
