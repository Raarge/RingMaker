using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RingMaker.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(RingMaker.Droid.DependencyServices.ClipboardService))]
namespace RingMaker.Droid.DependencyServices
{
    public class ClipboardService : IClipboardService
    {
        [Obsolete]
        public void CopyToClipboard(string text)
        {
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            ClipData clip = ClipData.NewPlainText("Android Clipboard", text);
            clipboardManager.PrimaryClip = clip;
        }
    }
}