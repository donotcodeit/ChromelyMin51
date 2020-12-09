using Chromely.Core.Host;
using Chromely.NativeHost;

namespace ChromelyMin51
{
    public class CustomChromelyWinFramelessHost : ChromelyWinHost
    {
        public CustomChromelyWinFramelessHost(IWindowMessageInterceptor messageInterceptor, IKeyboadHookHandler keyboadHandler)
            : base(messageInterceptor, keyboadHandler)
        {
        }
    }
}
