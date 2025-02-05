using Data.Entities;

namespace Business.Services
{
    public interface IProjectService
    {
        ProjectEntity AddProject(ProjectEntity project);
        bool DeleteProject(int id);
        IEnumerable<ProjectEntity> GetAllProjects();
        ProjectEntity GetProject(int id);
        ProjectEntity UpdateProject(ProjectEntity project);
    }
}