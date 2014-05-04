using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ButtonClicker
{
	[Activity (Label = "ButtonClicker", MainLauncher = true)]
	public class MainActivity : Activity
	{
		double count = 0;
		int catCount = 0;
		double mult = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get view from the layout resource
			Button clickMe = FindViewById<Button> (Resource.Id.myButton);
			Button buyCat = FindViewById<Button> (Resource.Id.buyCat);
			TextView clicks = FindViewById<TextView> (Resource.Id.clickCount);
			TextView catTxtCount = FindViewById<TextView> (Resource.Id.catCount);
			if (catCount > 0) {
				mult = 2 * catCount;
			}

			clickMe.Click += delegate {
				count += 1*mult;
				clicks.Text = string.Format ("Total: {0}", count);
			};
			buyCat.Click += delegate {
				catCount += 1;
				catTxtCount.Text = string.Format ("Cats: {0}", catCount);
			};
		}
	}
}


