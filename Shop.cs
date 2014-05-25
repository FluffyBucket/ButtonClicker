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

		private Button btnBuyCat;
		private Button btnBuyBanana;
		private Button btnBack;

		private TextView TVCurrent;
		private TextView TVCatPrice;
		private TextView TVBananaPrice;

		private ImageView IVCat;
		private ImageView IVBanana;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Shop);

			btnBuyCat = FindViewById<Button> (Resource.Id.btnCat);
			btnBuyCat.Click += new EventHandler (BuyCat_click);

			btnBuyBanana = FindViewById<Button> (Resource.Id.btnBanana);
			btnBuyBanana.Click += new EventHandler (BuyBanana_click);

			btnBack = FindViewById<Button> (Resource.Id.btnBack);
			btnBack.Click += new EventHandler (Back_click);

			TVCatPrice = FindViewById<TextView> (Resource.Id.tvCat);
			TVBananaPrice = FindViewById<TextView> (Resource.Id.tvBanana);
			TVCurrent = FindViewById<TextView> (Resource.Id.tvCurrent);

			IVCat = FindViewById<ImageView> (Resource.Id.ivCat);
			IVCat.SetImageResource (Resource.Drawable.Cat);

			IVBanana = FindViewById<ImageView> (Resource.Id.ivBanana);
			IVBanana.SetImageResource (Resource.Drawable.Banana);
			// Create your application here
			Update ();
		}

		private void Update()
		{
			TVCurrent.Text = "Current clicks: " + Base.clicks_Current;
			TVCatPrice.Text = "Price: " + Base.cat_Cost+ " ";
			TVBananaPrice.Text = "Price: " + Base.banana_Cost + " ";
		}

		private void BuyCat_click (object sender, EventArgs e)
		{
			switch (Base.BuyCat ()) {
			case 0:
				break;
			case 1:
				Toast.MakeText (this, "To many cats...", ToastLength.Short).Show ();
				break;
			case 2: 
				Toast.MakeText (this, "Insufficient funds...", ToastLength.Short).Show ();
				break;
			}
			Update ();
		}

		private void BuyBanana_click (object sender, EventArgs e)
		{
			switch (Base.BuyBanana ()) {
			case 0:
				break;
			case 1:
				Toast.MakeText (this, "To many bananas...", ToastLength.Short).Show ();
				break;
			case 2: 
				Toast.MakeText (this, "Insufficient funds...", ToastLength.Short).Show ();
				break;
			}
			Update ();
		}

		private void Back_click (object sender, EventArgs e)
		{
			this.Finish ();
		} 
	}
}

