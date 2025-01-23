using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace CharacterGenerator
{
	internal class Program
	{
		private static Random rnd = new Random();
		static void Main()
		{
			Console.WriteLine("Hello World!");

			//not final place, just figuring out what I needed
			int[][] rawStats = new int[12][];//size of the array may need to be altered
			//At present this is a MD 2D array.  Jagged arrays use the [][] format, and are a little harder to use.
			int selectedSet = 0;//for if there are multiple sets in play, it indicates what set it will use going forward.  Default 0
			int[] finalStats = new int[6];

			//Steps: generally a rough outline.  exact order to be decided upon later.
			//1. Present methods (I, II, III, IV and MANUAL ENTRY )
			//2. Prompt for input (Numeric)
			//3a Call corresponding function dedicated to a method and await output.
			//3b Roll for outcomes.
			//3c Order and display.
			//3a prompt for selections where applicable. (numeric)
			//3b prompt for ordering, where applicable. (numeric)
			//4. Filter for applicable race/classes, stow and then display. (race is technically first.)
			//5. Race Selection: show and prompt for selection. (numeric)
			//6. Class selection:
			//6a Multi-class combinations need to be dealt with in some fashion.
			//7. Roll hitpoints
			//8. Rolls for height, weight, age, background (all are things I'm inclined to use to a degree.)
			//9. initial money
			//10 Weapons proficiency guidelines

			//investigate "jump statements" as a means of handling requests to back up a step.
			//1: present methods -- Some error checking needed that the language is correct
			while (true)
			{
				Console.WriteLine(
					"Welcome to Carefulrogue's Character Generator!\n" +
					"To begin, select a method (numpad):\n" +
					"1: Method I: Roll 4d6 six times, discarding the lowest, then arrange the stats to suit.  Attributes can be modified by the Race chosen later.\n" +
					"2: Method II: All scores are recorded and arranged as in Method I.  3d6 are rolled 12 times asnd the highest 6 scores are retained.\n" +
					"3: Method III: Scores rolled are according to each ability category, in order, STR, INT, WIS, DEX, CON, CHA.  3d6 are rolled 6 times for each ability, and the highest score in each category is retained for that category.\n" +
					"4: Method IV: 3d6 are rolled sufficient times to generate the 6 ability scores, in order, for 12 characters.  The player then selects the single set of scores which he or she finds most desirable and these scores are noted on the character record sheet.\n" +
					"5: L&T M.0: The default is to roll 3d6 for each attribute in order, resulting in a base score between 3 and 18 and an average of 11.\n" +
					"6: L&T M.I: Roll 3d6 in order then swap two scores for each other.\n" +
					"9: MANUAL ENTRY\n");
				//2: read input -- Complete.
				int selection = -1;
				int.TryParse(Console.ReadLine(), out selection);
				Console.WriteLine("====================");


				switch (selection)
				{
					case 1:
						rawStats = MethodI();
						break;
					case 2:

						break;
					case 3:

						break;
					case 4:

						break;
					case 5:

						break;
					default://been a while, how does one Switch?
						Console.WriteLine("Invalid entry.  Please enter a numeric character");
						break;
				}

				//4 display results
				Console.WriteLine("====================");//a string constructor should be used to make this as easy as possible.
			}
		}
		public static int Dice(int die)
		{//executes one cast of the dice.
			die++;//ups the passed value, to be max inclusive
			int x = rnd.Next(1, die);
			return x;
		}//end of Dice
		public static bool ValidateLegalSet(int[] die)
		{
			if (die.Length!=6)//
				return false;
			//int resultsUnder5 = 0, resultsUnder6 = 0;//I DON'T RECALL THE ACTUAL VALUES


			return true;
		}
		public static int[][] MethodI()//Creating to segregate out the results
		{
			//1: Method I: Roll 4d6 six times, discarding the lowest, then arrange the stats to suit.  Attributes can be modified by the Race chosen later.
			int[][] results = new int[1][];//jagged array.  Probably the solution to my problemw ith passing 1D arrays
			results[0] = new int[6];
			bool validate = false;
			while (validate == false)
			{
				for (int x = 0; x < results[0].Length; x++)
				{
					int[] temp = new int[4];
					for (int y = 0; y < 4; y++)
					{
						temp[y] = Dice(6);//generates the 4 rolls
					}//end of dice rolling
					int lowestVal = temp.Min();//now must eval for lowest value

					results[0][x] = temp.Sum() - lowestVal;//sum all dice, subtracting the lowest
					Console.WriteLine(string.Concat(temp.Order()) + " = " + results[0][x]);
				}//rolls for stats
				//finally, validate if the set is legal:
				validate = ValidateLegalSet(results[0]);
				Console.WriteLine(validate);
			}
			return results;
			//CONCERN: this would overwrite the value in rawStats.  Might be undesireable.  Or maybe negates the declarations in MAIN

		}//end of MethodI
		

	}//end of class
}//end of namespace