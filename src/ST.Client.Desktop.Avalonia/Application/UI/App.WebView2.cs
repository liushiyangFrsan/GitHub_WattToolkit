#if WINDOWS

using System.IO;
using Avalonia.Controls;
using System.Application.UI.Resx;
using Microsoft.Web.WebView2.Core;

namespace System.Application.UI;

partial class App
{
#if DEBUG
    [Obsolete("use WebView2.AvailableWebView2", true)]
    public static bool AvailableWebView2 => WebView2.IsSupported;

    [Obsolete("use WebView2.VersionString", true)]
    public static string? WebView2VersionString => WebView2.VersionString;
#endif

    static void InitWebView2()
    {
        if (WebView2.IsSupported)
        {
            WebView2.DefaultCreationProperties = new()
            {
                Language = R.Culture.TwoLetterISOLanguageName,
                UserDataFolder = GetUserDataFolder(),
            };

            static string GetUserDataFolder()
            {
                var path = Path.Combine(IOPath.AppDataDirectory, "AppData", "WebView2", "UserData");
                return IOPath.DirCreateByNotExists(path);
            }
        }
    }

    // WebView2AutoInstaller
    // https://github.com/ProKn1fe/WebView2.Runtime/blob/62011b09436944143996fdb0039cd2c5dbb5c300/WebView2.Runtime.AutoInstaller/WebView2.Runtime.AutoInstaller/WebView2AutoInstaller.cs
}

#endif