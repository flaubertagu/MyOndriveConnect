using DriveConnect.UWP.Renderer;
using DriveConnect.ViewRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace DriveConnect.UWP.Renderer
{
    public class CustomSwitchRenderer : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Style = (Windows.UI.Xaml.Style)App.Current.Resources["CustomToggle"];
            }
        }
    }
}
