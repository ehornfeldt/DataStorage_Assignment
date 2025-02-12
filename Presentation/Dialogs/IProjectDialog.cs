
namespace Presentation.Dialogs
{
    public interface IProjectDialog
    {
        Task CreateProjectDialog();
        Task ViewProjectsDialog();
        Task ViewSingleProjectDialog();
        Task UpdateProjectDialog();
        Task DeleteProjectDialog();
    }
}