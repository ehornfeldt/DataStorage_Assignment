using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
    {
        //ChatGPT
        public async Task<IEnumerable<ProjectEntity>> GetAllWithCustomersAsync()
        {

            //return await _context.Projects.Include(p => p.Customer).ToListAsync();
            var projects = await _context.Projects.Include(p => p.Customer).ToListAsync();
            Console.WriteLine($"Number of projects: {projects.Count}");
            foreach (var project in projects)
            {
                if (project.Customer == null)
                {
                    Console.WriteLine($"1:Project ID {project.Id} has no associated customer.");
                }
            }
            return projects;
        }

        //ChatGPT

        public async Task<ProjectEntity> GetProjectWithCustomerAsync(int projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                Console.WriteLine("Project not found.");
                return null!;
            }
            else
            {
                return project;
            }
        }
    }
    //public class ProjectRepository(DataContext context)
    //{
    //    private readonly DataContext _context = context;
    //}
}
