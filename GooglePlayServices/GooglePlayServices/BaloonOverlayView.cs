using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Net;
using Android.Gms.Maps;

using Android.Gms.Common.Annotations;

namespace GooglePlayServicesTest
{
    public class BaloonOverlayView
    {


		
    }





    /// <summary>
    /// LimitLinearLayout class;
    /// </summary>
    public class LimitLinearLayout:LinearLayout
    {
        private static int MAX_WIDTH_DP = 280;
        private int ConvertPixelsToDp(float pixelValue)
		{
           
			var dp = (int) ((pixelValue)/Resources.DisplayMetrics.Density);
			return dp;
		}

        public LimitLinearLayout(Context context):base(context)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var metrics = Resources.DisplayMetrics.Density;
            var mode = MeasureSpec.GetMode(widthMeasureSpec);
            var measureWidth = MeasureSpec.GetSize(widthMeasureSpec);
            var adjustedMaxWidth = (int)(MAX_WIDTH_DP * metrics + 0.5f);

            var adjustedWidth = Math.Min(measureWidth, adjustedMaxWidth);
            var adjustedWidthMeasureSPec = MeasureSpec.MakeMeasureSpec(adjustedWidth, mode);
            base.OnMeasure(adjustedWidthMeasureSPec, heightMeasureSpec);
        }

    }


}

