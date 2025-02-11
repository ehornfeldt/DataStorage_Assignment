using Business.Models;
using Data.Entities;

namespace Business.Services
{
    public interface IProjectService
    {
        Task<ProjectEntity> CreateProjectAsync(ProjectRegistrationForm form);
        Task<bool> DeleteProjectAsync(int id);
        Task<IEnumerable<ProjectEntity>> GetProjectsAsync();
        Task GetProjectWithCustomerAsync(int projectId);
    }
}