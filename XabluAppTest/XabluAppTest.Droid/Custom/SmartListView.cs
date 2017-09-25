using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V4;
using XabluAppTest.Droid.Fragments;

namespace XabluAppTest.Droid.Custom
{
    [Register("xabluapptest.droid.custom.SmartListView")]
    public class SmartListView : MvxListView
    {
        float mPosX = 0;
        float mCurPosX = 0;
        float mPosY = 0;
        float mCurPosY = 0;

        public MvxFragment Test { get; set; }
        public FirstFragment FirstFragment { get; set; }
        public SmartListView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SmartListView(Context context, IAttributeSet attrs, IMvxAdapter adapter) : base(context, attrs, adapter)
        {
        }

        public SmartListView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            base.OnTouchEvent(e);
            
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    mPosX = e.GetX();
                    mCurPosX = mPosX;
                    mPosY = e.GetY();
                    mCurPosY = mPosY;
                    break;
                case MotionEventActions.Move:
                    mCurPosX = e.GetX();
                    mCurPosY = e.GetY();

                    float xDistance = Math.Abs(mCurPosX - mPosX);
                    float yDistance = Math.Abs(mCurPosY - mPosY);
                    if (xDistance > yDistance && mCurPosX - mPosX > 0)//Swip Right
                    {
                        //FirstFragment?.DoSwipe("RIGHT");
                        //DoSwipe("RIGHT");
                        var viewModel = Test.ViewModel.GetType().ToString();
                        if (viewModel.Equals("XabluAppTest.Core.ViewModels.FirstViewModel"))
                        {
                            var fragment = (FirstFragment) Test;
                            fragment?.DoSwipe("RIGHT");
                        }
                    }
                    else if (xDistance > yDistance && mCurPosX - mPosX < 0)//Swip Left
                    {
                        //FirstFragment?.DoSwipe("LEFT");
                        //DoSwipe("LEFT");

                        var viewModel = Test.ViewModel.GetType().ToString();
                        if (viewModel.Equals("XabluAppTest.Core.ViewModels.FirstViewModel"))
                        {
                            var fragment = (FirstFragment)Test;
                            fragment?.DoSwipe("LEFT");
                        }
                    }
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}