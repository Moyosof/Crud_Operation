using CRUD_Operation.Data;
using CRUD_Operation.Inferfaces;
using CRUD_Operation.Models;
using CRUD_Operation.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation.Services
{
    public class JobService : IJobService
    {
        private ApplicationDbContext _ctx;

        public JobService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Job> AddJob(JobViewModel jobView)
        {
            Job job = new Job()
            {
                Id = Guid.NewGuid(),
                Title= jobView.Title,
                Salary= jobView.Salary,
                Qualification= jobView.Qualification,
                Experience = jobView.Experience,
            };
            var obj = await _ctx.Jobs.AddAsync(job); 
            await _ctx.SaveChangesAsync();
            return job;
        }

        public async Task DeleteJob(Job job)
        {
            _ctx.Jobs.Remove(job);
            await _ctx.SaveChangesAsync();
            
        }

        public async Task<Job> GetJobById(Guid Id)
        {
            var obj = await _ctx.Jobs.FindAsync(Id);
            return obj;
        }

        public async Task<List<Job>> GetJobs()
        {
            var obj = await _ctx.Jobs.ToListAsync();
            return obj;
        }

        public async Task<Job> UpdateJob(Job job)
        {
            var obj =  _ctx.Jobs.Update(job);
            await _ctx.SaveChangesAsync();
            return job;

        }
    }
}
