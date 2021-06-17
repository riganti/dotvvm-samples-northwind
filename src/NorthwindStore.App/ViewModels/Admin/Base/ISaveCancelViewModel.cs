using System.Threading.Tasks;

namespace NorthwindStore.App.ViewModels.Admin.Base
{
    public interface ISaveCancelViewModel
    {

        Task Save();

        void Cancel();
    }
}