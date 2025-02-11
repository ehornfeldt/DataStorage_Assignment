using Data.Contexts;
using Data.Entities;

namespace Data.Repositories
{
    public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
    {
    }
    //public class ProjectRepository(DataContext context)
    //{
    //    private readonly DataContext _context = context;
    //}
}
