using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Laborator_2.Activitati
{
     [Activity(Label = "AddActivity")]
     public class AddActivity : Activity
     {
          protected override void OnCreate(Bundle savedInstanceState)
          {
               base.OnCreate(savedInstanceState);
               SetContentView(Resource.Layout.AddLayout);
               Toast.MakeText(this, "Add hehey", ToastLength.Long);
          }
     }
}