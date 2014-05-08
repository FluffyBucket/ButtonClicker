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
		double clicks_Total = 0;
		double clicks_Current = 0;
		int cat_Amount = 0;
		int cat_Cost = 10;
		double mult = 1;

		private Button BtnClickMe;
		private Button BtnBuyCat;
		private TextView TVClicks;
		private TextView TVCurrent;
		private TextView TVCatAmount;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Find the buttons
			BtnClickMe = FindViewById<Button> (Resource.Id.click);
			BtnClickMe.Click += new EventHandler (click_Click);

			BtnBuyCat = FindViewById<Button> (Resource.Id.buyCat);
			BtnBuyCat.Click += new EventHandler (buyCat_Click);

			TVClicks = FindViewById<TextView> (Resource.Id.clickCount);
			TVCatAmount = FindViewById<TextView> (Resource.Id.catCount);
			TVCurrent = FindViewById<TextView> (Resource.Id.currentCount);


		}

		private void click_Click (object sender, EventArgs e)
		{
			clicks_Total += 1 * mult;
			clicks_Current += 1 * mult;
			TVClicks.Text = "Total: " + clicks_Total;
			TVCurrent.Text = "Current: " + clicks_Current;
		}

		private void buyCat_Click (object sender, EventArgs e)
		{
			if (clicks_Current >= cat_Cost) {
				cat_Amount += 1;
				clicks_Current -= cat_Cost;
			}

			mult += (cat_Amount);
			TVCatAmount.Text = "Cats: " + cat_Amount;
			TVCurrent.Text = "Current: " + clicks_Current;
		}
	}
}


