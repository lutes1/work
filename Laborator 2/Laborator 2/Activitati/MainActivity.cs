using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Laborator_2.Activitati;

namespace Laborator_2
{
     [Activity(Label = "Laborator_2", MainLauncher = true, Icon = "@drawable/icon")]
     public class MainActivity : Activity
     {
          Button addButton;
          Button removeButton;
          Button updateButton;
          Button searchButton;
          protected override void OnCreate(Bundle bundle)
          {
               base.OnCreate(bundle);
               SetContentView(Resource.Layout.Main);
               Initializer();
               EventHandlers();

          }
          public void Initializer()
          {
               addButton = FindViewById<Button>(Resource.Id.addButton);
               removeButton = FindViewById<Button>(Resource.Id.removeButton);
               updateButton = FindViewById<Button>(Resource.Id.updateButton);
               searchButton = FindViewById<Button>(Resource.Id.searchButton);

          }
          public void EventHandlers()
          {
               addButton.Click += AddButton_Click;
               removeButton.Click += RemoveButton_Click;
               updateButton.Click += UpdateButton_Click;
               searchButton.Click += SearchButton_Click;

          }

          private void SearchButton_Click(object sender, EventArgs e)
          {
               
          }

          private void UpdateButton_Click(object sender, EventArgs e)
          {
               var intent = new Intent(this, typeof(UpdateActivity));
               StartActivity(intent);
          }

          private void RemoveButton_Click(object sender, EventArgs e)
          {
               var intent = new Intent(this, typeof(RemoveActivity));
               StartActivity(intent);
          }

          private void AddButton_Click(object sender, EventArgs e)
          {
               var intent = new Intent(this, typeof(AddActivity));
               StartActivity(intent);
          }

     }
}

