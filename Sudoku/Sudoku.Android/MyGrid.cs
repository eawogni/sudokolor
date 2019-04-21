using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Sudoku.Droid
{
    class MyGrid : GridView
    {
        public MyGrid(Context context) : base(context)
        {
        }

        public MyGrid(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public MyGrid(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public MyGrid(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected MyGrid(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnDrawForeground(Canvas canvas)
        {
            base.OnDrawForeground(canvas);

            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 20;

            canvas.DrawLine(20, 20, 20, 20, paint);
        }
    }
}