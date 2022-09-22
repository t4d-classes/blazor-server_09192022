using System.Threading.Tasks;

namespace ToolsApp.Core.Interfaces.Web
{
    public interface IScreenBlocker
    {
        Task BlockScreen();
        Task UnblockScreen();
    }
}