using System;

public class PokemonBuilder: TestDataBuilder<Pokemon>
	{

	Pokemon.Breed BreedToUse;
	int XPToUse;
	int RateToUse;


	public override Pokemon Build ()
	{
		Pokemon ToReturn;
		if (BreedToUse != null) 
		{
			ToReturn = new Pokemon (BreedToUse);
		} 
		else
		{
			ToReturn = new Pokemon ();
		}
		ToReturn.XP = XPToUse;
		ToReturn.Rate = RateToUse;
		return ToReturn;
	}

		public PokemonBuilder ()
		{
		}

	public PokemonBuilder W_XP (int XP)
	{
		XPToUse = XP;
		return this;
	}

	public PokemonBuilder W (Pokemon.Breed Breed) 
	{
		BreedToUse = Breed;
		return this;
	}

	public PokemonBuilder W_Rate (int Rate)
	{
		RateToUse = Rate;
		return this;
	}
}


