using Business.Models;
using Data.Entities;
using Data.Migrations;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? null : new()
        {
            Name = form.Name,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            CustomerId = form.CustomerId,
            Status = form.Status,
            ProjectLeader = form.ProjectLeader,
            Service = form.Service,
            Price = form.Price,
        };

        public static ProjectEntity? Create(ProjectEntity entity) => entity == null ? null : new()
        {
            Id = entity.Id,
            Name = entity.Name,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            CustomerId = entity.CustomerId,
            Customer = entity.Customer,
            Status = entity.Status,
            ProjectLeader = entity.ProjectLeader,
            Service = entity.Service,
            Price = entity.Price,
        };
    }
}
