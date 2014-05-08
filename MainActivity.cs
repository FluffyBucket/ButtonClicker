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
		/*
			NOTES- and IDEAS-LIST:
			- How about later on making a "shop-window" with a list-layout? //Erik


		*/


		//Global vars
		double clicks_Total = 0;
		double clicks_Current = 0;
		int cat_Amount = 0;
		int cat_Cost = 10;
		double cat_CostMultiplier = 3; //Not the final solution, but just to somehow change the cost after buying a cat.
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
				cat_Amount++;
				clicks_Current -= cat_Cost;
				cat_Cost = (int)(cat_Cost * cat_CostMultiplier);
			}

			mult += (cat_Amount); //This might be the plan, but are mult goint to increase exponentially?
			//						How about, instead of multiplying, increasing the "chanse" of getting an extra click?
			TVCatAmount.Text = "Cats: " + cat_Amount;
			TVCurrent.Text = "Current: " + clicks_Current;
		}
	}
}


