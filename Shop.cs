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

namespace ButtonClicker
{
	[Activity (Label = "Shop")]			
	public class Shop : Activity
	{
		MainActivity main;
		private Button btnBuyCat;
		private Button btnBuyBanana;
		private Button btnBack;

		private TextView TVCatPrice;
		private TextView TVBananaPrice;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Shop);

			main = new MainActivity();

			btnBuyCat = FindViewById<Button> (Resource.Id.btnCat);
			btnBuyCat.Click += new EventHandler (main.buyCat_Click);

			btnBuyBanana = FindViewById<Button> (Resource.Id.btnBanana);
			btnBuyBanana.Click += new EventHandler (BuyBanana_click);

			btnBack = FindViewById<Button> (Resource.Id.btnBack);
			btnBack.Click += new EventHandler (Back_click);

			TVCatPrice = FindViewById<TextView> (Resource.Id.tvCat);
			TVCatPrice.Text = "Cat price: " + main.CatPrice.ToString () + " ";

			TVBananaPrice = FindViewById<TextView> (Resource.Id.tvBanana);
			TVBananaPrice.Text = "Banana price: " + main.BananaPrice.ToString () + " ";
			// Create your application here
		}

		private void BuyCat_click (object sender, EventArgs e)
		{
			main.buyCat_Click(null, null) ;
			TVCatPrice.Text = "Cat price: " + main.CatPrice.ToString () + " ";
		}

		private void BuyBanana_click (object sender, EventArgs e)
		{
			main.buyBanana_Click(null, null);
			TVBananaPrice.Text = "Banana price: " + main.BananaPrice.ToString () + " ";
		}

		private void Back_click (object sender, EventArgs e)
		{
			this.Finish ();
		}
	}
}

