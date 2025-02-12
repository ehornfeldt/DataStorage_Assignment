using Business.Models;
using Data.Entities;

namespace Business.Services
{
    public interface IProjectService
    {
        Task<ProjectEntity> CreateProjectAsync(ProjectRegistrationForm form);
        Task<IEnumerable<ProjectEntity>> GetProjectsAsync();
        Task<ProjectEntity> GetProjectWithCustomerAsync(int projectId);
        Task<bool> UpdateCustomerAsync(int id, ProjectRegistrationForm updatedProject);
        Task<bool> DeleteProjectAsync(int id);
    }
}