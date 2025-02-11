using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ProjectService(DataContext context) : IProjectService
    {
        private readonly DataContext _context = context;

        public ProjectEntity AddProject(ProjectEntity project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public IEnumerable<ProjectEntity> GetAllProjects()
        {
                
            var projects = _context.Projects.Include(x => x.Customer).ToList();
            return projects;
        }

        public ProjectEntity GetProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            return project ?? null!;
        }

        public ProjectEntity UpdateProject(ProjectEntity project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            return project;
        }
        public bool DeleteProject(int id)
        {
            var project = GetProject(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
