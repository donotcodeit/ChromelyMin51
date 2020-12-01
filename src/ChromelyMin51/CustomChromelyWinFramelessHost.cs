using Chromely.Core.Host;
using Chromely.NativeHost;
using WS = Chromely.Interop.User32.WS;

namespace ChromelyMin51
{
    public class CustomChromelyWinFramelessHost : ChromelyWinFramelessHost
    {
        protected override WindowStylePlacement GetWindowStylePlacement(WindowState state)
        {
            var placement = base.GetWindowStylePlacement(state);
            placement.Styles = WS.POPUPWINDOW | WS.CLIPCHILDREN | WS.CLIPSIBLINGS | WS.SIZEBOX | WS.MINIMIZEBOX | WS.MAXIMIZEBOX;

            return placement;
        }
    }
}
