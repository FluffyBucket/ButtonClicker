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
		double currentCount = 0;
		int catCount = 0;
		int catCost = 10;
		double mult = 1;

		private Button clickMe;
		private Button buyCat;
		private TextView clicks;
		private TextView current;
		private TextView catTxtCount;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Find the buttons
			clickMe = FindViewById<Button> (Resource.Id.click);
			clickMe.Click += new EventHandler (click_Click);

			buyCat = FindViewById<Button> (Resource.Id.buyCat);
			buyCat.Click += new EventHandler (buyCat_Click);

			clicks = FindViewById<TextView> (Resource.Id.clickCount);
			catTxtCount = FindViewById<TextView> (Resource.Id.catCount);
			current = FindViewById<TextView> (Resource.Id.currentCount);


		}

		private void click_Click (object sender, EventArgs e)
		{
			count += 1 * mult;
			currentCount += 1 * mult;
			clicks.Text = "Total: " + count;
			current.Text = "Current: " + currentCount;
		}

		private void buyCat_Click (object sender, EventArgs e)
		{
			if (currentCount >= catCost) {
				catCount += 1;
				currentCount -= catCost;
			}

			mult += (catCount);
			catTxtCount.Text = "Cats: " + catCount;
			current.Text = "Current: " + currentCount;
		}
	}
}


