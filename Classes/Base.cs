using System;

namespace ButtonClicker
{
	public static class Base
	{
		public static int clicks_Total;
		public static int clicks_Current;
		public static int cat_Amount;
		public static int cat_Cost;
		public static int banana_Amount;
		public static int banana_Cost;

		private static int cat_CostMultiplier = 2; 
		private static double banana_CostMultiplier = Math.E;

		private static Random randomCatEffectChanse = new Random();
		private static Random effectType = new Random();

		/*	public Base ()
		{

		} */

		public static void LoadValues (int CC, int CT, int CatA, int CatC, int BananaA, int BananaC)
		{
			clicks_Current = CC;
			clicks_Total = CT;
			cat_Amount = CatA;
			cat_Cost = CatC;
			banana_Amount = BananaA;
			banana_Cost = BananaC;
		}

		/*	public int CatPrice
		{
			get { return cat_Cost; }
		}

		public int BananaPrice
		{
			get { return banana_Cost; }
		} */

		public static void Debug ()
		{
			clicks_Current += 100000;
		}

		public static void Click ()
		{
			int clickstack = (banana_Amount + 1);

			//Randomizes a number between 1 and 100, and if the number is less then the cat amount a effect can take place
			if (randomCatEffectChanse.Next (0, 100) < cat_Amount) {

				//Choise of effect
				switch (effectType.Next (1, 4)) { //Min: Lowest possible, Max: One above highest
				case 1:
					//DubbleCoin effect
					clickstack *= 2;
					break;
				case 2:
					// + 200 clicks
					clicks_Total += 200;     
					clicks_Current += 200;
					break;
				case 3:
					// + 500 total clicks
					clicks_Total += 500;
					break;
				}
			}

			clicks_Total += clickstack;     
			clicks_Current += clickstack;

		}

		public static int BuyCat () //Return order: 0 = ok, 1 = full, 2 = insufficient funds
		{
			if (clicks_Current >= cat_Cost && cat_Amount < 100) { //Can not buy more than 100 cats
				cat_Amount++;
				clicks_Current -= cat_Cost;
				// cat_CostMultiplier++;                          - static atm
				cat_Cost = (int)(cat_Cost * cat_CostMultiplier);
				return 0;
			} else if (cat_Amount >= 100) {
				return 1;
			} else {
				return 2;
			}
		
		}

		public static int BuyBanana () //Return order: 0 = ok, 1 = full, 2 = insufficient funds
		{
			if (clicks_Current >= banana_Cost && banana_Amount < 9) { //Can not buy more than 9 bananas
				banana_Amount++;
				clicks_Current -= banana_Cost;
				banana_Cost = (int)(banana_Cost * banana_CostMultiplier);
				return 0;
			} else if (banana_Amount >= 100) {
				return 1;

			} else {
				return 2;
			}

		}

	}
}

