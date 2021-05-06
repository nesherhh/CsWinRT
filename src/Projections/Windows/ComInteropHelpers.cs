﻿#if UAC_VERSION_13
#define UAC_VERSION_12
#endif
#if UAC_VERSION_12
#define UAC_VERSION_11
#endif
#if UAC_VERSION_11
#define UAC_VERSION_10
#endif
#if UAC_VERSION_10
#define UAC_VERSION_9
#endif
#if UAC_VERSION_9
#define UAC_VERSION_8
#endif
#if UAC_VERSION_8
#define UAC_VERSION_7
#endif
#if UAC_VERSION_7
#define UAC_VERSION_6
#endif
#if UAC_VERSION_6
#define UAC_VERSION_5
#endif
#if UAC_VERSION_5
#define UAC_VERSION_4
#endif
#if UAC_VERSION_4
#define UAC_VERSION_3
#endif
#if UAC_VERSION_3
#define UAC_VERSION_2
#endif
#if UAC_VERSION_2
#define UAC_VERSION_1
#endif

using System;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;
using Windows.Graphics.Printing;
using Windows.Graphics.Printing3D;
using Windows.Media.PlayTo;
using Windows.Security.Credentials.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.ViewManagement;
using WinRT;
using WinRT.Interop;
using Windows.UI.Input;
using Windows.UI.Input.Core;
using Windows.UI.Input.Spatial;
using Windows.Media;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using System.Runtime.InteropServices;

namespace WinRT.Interop
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
    public interface IWindowNative
    {
        IntPtr WindowHandle { get; }
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
    public interface IInitializeWithWindow
    {
        void Initialize(IntPtr hwnd);
    }
}

namespace Windows.ApplicationModel.DataTransfer.DragDrop.Core
{
#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class DragDropManagerInterop
    {
        private static IDragDropManagerInterop dragDropManagerInterop = CoreDragDropManager.As<IDragDropManagerInterop>();
        
        public static CoreDragDropManager GetForWindow(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(ICoreDragDropManager));
            return (CoreDragDropManager)dragDropManagerInterop.GetForWindow(appWindow, iid);
        }
    }
#endif
}

namespace Windows.Graphics.Printing
{
    // Windows.Graphics.Printing3D.Printing3DContract, v1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows.Graphics.Printing3D.Printing3DContract - please use ApiInformation checks.")]
#endif
    public static class Printing3DManagerInterop
    {
        private static IPrinting3DManagerInterop printing3DManagerInterop = Print3DManager.As<IPrinting3DManagerInterop>();

        public static Print3DManager GetForWindow(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IPrint3DManager));
            return (Print3DManager)printing3DManagerInterop.GetForWindow(appWindow, iid);
        }

        public static IAsyncOperation<bool> ShowPrintUIForWindowAsync(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IAsyncOperation<bool>));
            return (IAsyncOperation<bool>)printing3DManagerInterop.ShowPrintUIForWindowAsync(appWindow, iid);
        }
    }

#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class PrintManagerInterop
    {
        private static IPrintManagerInterop printManagerInterop = PrintManager.As<IPrintManagerInterop>();

        public static PrintManager GetForWindow(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IPrintManager));
            return (PrintManager)printManagerInterop.GetForWindow(appWindow, iid);
        }

        public static IAsyncOperation<bool> ShowPrintUIForWindowAsync(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IAsyncOperation<bool>));
            return (IAsyncOperation<bool>)printManagerInterop.ShowPrintUIForWindowAsync(appWindow, iid);
        }
    }
#endif
}

namespace Windows.Media
{
#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class SystemMediaTransportControlsInterop
    {
        private static ISystemMediaTransportControlsInterop systemMediaTransportControlsInterop = SystemMediaTransportControls.As<ISystemMediaTransportControlsInterop>();

        public static SystemMediaTransportControls GetForWindow(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(ISystemMediaTransportControls));
            return (SystemMediaTransportControls)systemMediaTransportControlsInterop.GetForWindow(appWindow, iid);
        }
    }
#endif
}

namespace Windows.Media.PlayTo
{
#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class PlayToManagerInterop
    {
        private static IPlayToManagerInterop playToManagerInterop = PlayToManager.As<IPlayToManagerInterop>();
        
        public static PlayToManager GetForWindow(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IPlayToManager));
            return (PlayToManager)playToManagerInterop.GetForWindow(appWindow, iid);
        }

        public static void ShowPlayToUIForWindow(IntPtr appWindow)
        {
            playToManagerInterop.ShowPlayToUIForWindow(appWindow);
        }
    }
#endif
}

namespace Windows.Security.Credentials.UI
{
#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class UserConsentVerifierInterop
    {
        private static IUserConsentVerifierInterop userConsentVerifierInterop = UserConsentVerifier.As<IUserConsentVerifierInterop>();

        public static IAsyncOperation<UserConsentVerificationResult> RequestVerificationForWindowAsync(IntPtr appWindow, string message)
        {
            var iid = GuidGenerator.CreateIID(typeof(IAsyncOperation<UserConsentVerificationResult>));
            return (IAsyncOperation<UserConsentVerificationResult>)userConsentVerifierInterop.RequestVerificationForWindowAsync(appWindow, message, iid);
        }
    }
#endif
}

namespace Windows.Security.Authentication.Web.Core
{
#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class WebAuthenticationCoreManagerInterop
    {
        private static IWebAuthenticationCoreManagerInterop webAuthenticationCoreManagerInterop = WebAuthenticationCoreManager.As<IWebAuthenticationCoreManagerInterop>();

        public static IAsyncInfo RequestTokenForWindowAsync(IntPtr appWindow, WebTokenRequest request)
        {
            var iid = GuidGenerator.CreateIID(typeof(IAsyncOperation<WebTokenRequestResult>));
            return (IAsyncInfo)webAuthenticationCoreManagerInterop.RequestTokenForWindowAsync(appWindow, request, iid);
        }

        public static IAsyncInfo RequestTokenWithWebAccountForWindowAsync(IntPtr appWindow, WebTokenRequest request, WebAccount webAccount)
        {
            var iid = GuidGenerator.CreateIID(typeof(IAsyncOperation<WebTokenRequestResult>));
            return (IAsyncInfo)webAuthenticationCoreManagerInterop.RequestTokenWithWebAccountForWindowAsync(appWindow, request, webAccount, iid);
        }
    }
#endif
}

namespace Windows.UI.ApplicationSettings
{
#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class AccountsSettingsPaneInterop
    {
        private static IAccountsSettingsPaneInterop accountsSettingsPaneInterop = AccountsSettingsPane.As<IAccountsSettingsPaneInterop>();

        public static AccountsSettingsPane GetForWindow(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IAccountsSettingsPane));
            return (AccountsSettingsPane)accountsSettingsPaneInterop.GetForWindow(appWindow, iid);
        }

        public static IAsyncAction ShowManageAccountsForWindowAsync(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IAsyncAction));
            return (IAsyncAction)accountsSettingsPaneInterop.ShowManageAccountsForWindowAsync(appWindow, iid);
        }

        public static IAsyncAction ShowAddAccountForWindowAsync(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IAsyncAction));
            return (IAsyncAction)accountsSettingsPaneInterop.ShowAddAccountForWindowAsync(appWindow, iid);
        }
    }
#endif
}

namespace Windows.UI.Input
{
#if UAC_VERSION_3
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.14393.0")]
#endif
    public static class RadialControllerConfigurationInterop
    {
        private static IRadialControllerConfigurationInterop radialControllerConfigurationInterop 
            = RadialControllerConfiguration.As<IRadialControllerConfigurationInterop>();
        
        public static RadialControllerConfiguration GetForWindow(IntPtr hwnd)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IRadialControllerConfiguration));
            return (RadialControllerConfiguration)radialControllerConfigurationInterop.GetForWindow(hwnd, iid);
        }
    }

#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.14393.0")]
#endif
    public static class RadialControllerInterop
    {
        private static IRadialControllerInterop radialControllerInterop = RadialController.As<IRadialControllerInterop>();

        public static RadialController CreateForWindow(IntPtr hwnd)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IRadialController));
            return (RadialController)radialControllerInterop.CreateForWindow(hwnd, iid);
        }
    }
#endif
}

namespace Windows.UI.Input.Core
{
#if UAC_VERSION_4
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.15063.0")]
#endif
    public static class RadialControllerIndependentInputSourceInterop
    {
        private static IRadialControllerIndependentInputSourceInterop radialControllerIndependentInputSourceInterop 
            = RadialControllerIndependentInputSource.As<IRadialControllerIndependentInputSourceInterop>();

        public static RadialControllerIndependentInputSource CreateForWindow(IntPtr hwnd)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IRadialControllerIndependentInputSource));
            return (RadialControllerIndependentInputSource)radialControllerIndependentInputSourceInterop.CreateForWindow(hwnd, iid);
        }
    }
#endif
}

namespace Windows.UI.Input.Spatial
{
#if UAC_VERSION_2
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10586.0")]
#endif
    public static class SpatialInteractionManagerInterop
    {
        private static ISpatialInteractionManagerInterop spatialInteractionManagerInterop = SpatialInteractionManager.As<ISpatialInteractionManagerInterop>();
        
        public static SpatialInteractionManager GetForWindow(IntPtr window)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(ISpatialInteractionManager));
            return (SpatialInteractionManager)spatialInteractionManagerInterop.GetForWindow(window, iid);
        }
    }
#endif
}

namespace Windows.UI.ViewManagement
{
#if UAC_VERSION_1
#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class InputPaneInterop
    {
        private static IInputPaneInterop inputPaneInterop = InputPane.As<IInputPaneInterop>();

        public static InputPane GetForWindow(IntPtr appWindow)
        {
            Guid iid = GuidGenerator.CreateIID(typeof(IInputPane));
            return (InputPane)inputPaneInterop.GetForWindow(appWindow, iid);
        }
    }

#if !NETSTANDARD2_0
    [global::System.Runtime.Versioning.SupportedOSPlatform("Windows10.0.10240.0")]
#endif
    public static class UIViewSettingsInterop
    {
        private static IUIViewSettingsInterop uIViewSettingsInterop = UIViewSettings.As<IUIViewSettingsInterop>();

        public static UIViewSettings GetForWindow(IntPtr hwnd)
        {
            var iid = GuidGenerator.CreateIID(typeof(IUIViewSettings));
            return (UIViewSettings)uIViewSettingsInterop.GetForWindow(hwnd, iid);
        }
    }
#endif
}