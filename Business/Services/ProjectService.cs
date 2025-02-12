using Business.Factories;
using Business.Models;
using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ProjectService(ProjectRepository projectRepository) : IProjectService
    {
        private readonly ProjectRepository _projectRepository = projectRepository;

        public async Task<ProjectEntity> CreateProjectAsync(ProjectRegistrationForm form)
        {
            //skapa ej kund om den redan finns
            var projectEntity = ProjectFactory.Create(form);
            await _projectRepository.AddAsync(projectEntity!);

            return projectEntity!;
        }
        public async Task<IEnumerable<ProjectEntity>> GetProjectsAsync()
        {
            //var projectEntities = await _projectRepository.GetAsync();
            //return projectEntities.Select(ProjectFactory.Create)!;

            var projectEntities = await _projectRepository.GetAllWithCustomersAsync();
            return projectEntities.Select(ProjectFactory.Create)!;
        }

        public async Task<ProjectEntity> GetProjectWithCustomerAsync(int projectId)
        {
            return await _projectRepository.GetProjectWithCustomerAsync(projectId);
        }
        //public async Task<CustomerEntity> GetCustomerByIdAsync(int id) { }
        public async Task<bool> UpdateCustomerAsync(int id, ProjectRegistrationForm updatedProject) {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
            if (projectEntity == null)
            {
                return false;
            }
            projectEntity.Name = updatedProject.Name;
            projectEntity.StartDate = updatedProject.StartDate;
            projectEntity.EndDate = updatedProject.EndDate;
            projectEntity.CustomerId = updatedProject.CustomerId;
            projectEntity.ProjectLeader = updatedProject.ProjectLeader;
            projectEntity.Status = updatedProject.Status;
            projectEntity.Service = updatedProject.Service;
            projectEntity.Price = updatedProject.Price;

            await _projectRepository.UpdateAsync(projectEntity!);
            return true;
        }
        public async Task<bool> DeleteProjectAsync(int id)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
            if (projectEntity == null)
            {
                Console.WriteLine($"No project with id {id}");
                return false;
            }
            await _projectRepository.RemoveAsync(projectEntity!);
            return true;
        }
        //private readonly DataContext _context = context;

        //public ProjectEntity AddProject(ProjectEntity project)
        //{
        //    _context.Projects.Add(project);
        //    _context.SaveChanges();
        //    return project;
        //}

        //public IEnumerable<ProjectEntity> GetAllProjects()
        //{

        //    var projects = _context.Projects.Include(x => x.Customer).ToList();
        //    return projects;
        //}

        //public ProjectEntity GetProject(int id)
        //{
        //    var project = _context.Projects.FirstOrDefault(x => x.Id == id);
        //    return project ?? null!;
        //}

        //public ProjectEntity UpdateProject(ProjectEntity project)
        //{
        //    _context.Projects.Update(project);
        //    _context.SaveChanges();
        //    return project;
        //}
        //public bool DeleteProject(int id)
        //{
        //    var project = GetProject(id);
        //    if (project != null)
        //    {
        //        _context.Projects.Remove(project);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
