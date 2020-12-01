using System.Collections.Generic;
using System.Threading.Tasks;
using Chromely.Core.Configuration;
using Chromely.Core.Host;
using Chromely.Core.Network;

namespace ChromelyMin51.Controllers
{
    [ControllerProperty(Name = "WindowController")]
    public class WindowController : ChromelyController
    {
        private const string COMMANDMAXRESPONSE = "toggleRestoreMaxButton(1);";
        private const string COMMANDRESTORERESPONSE = "toggleRestoreMaxButton(0);";

        private readonly IChromelyConfiguration _config;
        private readonly IChromelyWindow _window;

        public WindowController(IChromelyConfiguration config, IChromelyWindow window)
        {
            _config = config;
            _window = window;
        }

        [CommandAction(RouteKey = "/window/minimize")]
        public void Minimize(IDictionary<string, string> queryParameters)
        {
            _window.Minimize();
        }

        [CommandAction(RouteKey = "/window/maximize")]
        public void Maximize(IDictionary<string, string> queryParameters)
        {
            _window.Maximize();
            RunResponseScript(COMMANDMAXRESPONSE);
        }

        [CommandAction(RouteKey = "/window/restore")]
        public void Restore(IDictionary<string, string> queryParameters)
        {
            _window.Restore();
            RunResponseScript(COMMANDRESTORERESPONSE);
        }

        [CommandAction(RouteKey = "/window/close")]
        public void Close(IDictionary<string, string> queryParameters)
        {
            _window.Close();
        }

        private void RunResponseScript(string script)
        {
            try
            {
                Task.Run(() =>
                {
                    var scriptExecutor = _config?.JavaScriptExecutor;
                    if (scriptExecutor != null)
                    {
                        scriptExecutor.ExecuteScript(script);
                    }

                });
            }
            catch {}
        }
    }
}