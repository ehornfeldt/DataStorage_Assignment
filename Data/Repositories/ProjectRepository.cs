using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
    {
        public async Task<IEnumerable<ProjectEntity>> GetAllWithCustomersAsync()
        {
            var projects = await _context.Projects.Include(x => x.Customer).ToListAsync();
            return projects;
        }

        public async Task<ProjectEntity> GetProjectWithCustomerAsync(int id)
        {
            var project = await _context.Projects
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);

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
}
