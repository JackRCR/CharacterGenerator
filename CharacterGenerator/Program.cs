﻿using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace CharacterGenerator
{
	internal class Program
	{
		private static Random rnd = new Random();
		private static String[] statNames = new String[] {"STR","INT","WIS","DEX","CON","CHA"};
		static void Main()
		{
			Console.WriteLine("Hello World!");

			//not final place, just figuring out what I needed
			int[][] rawStats = new int[12][];//size of the array may need to be altered
			List<int[]> ints = new List<int[]>();//what I probably SHOULD do instead of [][]
			



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

			/* ORDER OF OPERATIONS
			 * 1. Present methods
			 * 2. prompt for numeric input
			 * 3. parse and store input, call indicated function
			 * 4a. Indicated function rolls up stats
			 * 4b. Functions call seperate function checking stats are "legal'
			 * 4c. Functions MAY ask user for input on ordering ---> THIS MAY NEED/CAN-BE MOVED ELSEWHERE.
			 * 4d. Return valid results to the user, and present stats
			 * 
			 */

			while (true)
			{
				Console.WriteLine("Press any key to continue...");
				Console.ReadLine();
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
				
				int selection = -1;
				int.TryParse(Console.ReadLine(), out selection);//I do not understand what TryParse is doing necessarily.
				Console.WriteLine("====================");


				switch (selection)
				{
					case 1:
						rawStats = MethodI();
						break;
					case 2:
						Console.WriteLine("Oops, Method II has not been written!  Report to Carefulrogue");
						break;
					case 3:
						Console.WriteLine("Oops, Method III has not been written!  Report to Carefulrogue");
						break;
					case 4:
						Console.WriteLine("Oops, Method IV has not been written!  Report to Carefulrogue");
						break;
					case 5:
						Console.WriteLine("Oops, L&T M.0 has not been written!  Report to Carefulrogue");
						break;
					case 6:
						Console.WriteLine("Oops, L&T M.1 has not been written!  Report to Carefulrogue");
						break;
					default://been a while, how does one Switch?
						Console.WriteLine("Invalid entry.  Please enter a valid numeric character");
						break;
				}//end of switch block

				//Eval and present valid races, and attempt to highlight stat lossess
				//male/female minimums are identical.  Breaking M/F maximums into different stat
				List<int[]> racialMinimums = new List<int[]>();
				String[] playerRaces = new String[] {"Dwarf","Elf","Gnome","Halfling","Half-Elf","Half-Orc"};
				String[] NPCRaces = new String[] {""};//Will flesh out later.  Has different considerations
				//Eval valid classes


				Console.WriteLine("====================");//a string constructor should be used to make this as easy as possible.
			}
		}
		public static int Dice(int die)
		{//executes one cast of the dice.
			die++;//ups the passed value, to be max inclusive
			int x = rnd.Next(1, die);
			return x;
		}//end of Dice
		public static bool ValidateLegalSet(int[] inputs)
		{
			//This checks for "impossible" sets, and return a false value invalid.  It will return true if valid
			//THE CALLING FUNCTION IS RESPONSIBLE FOR ACTING ON THE RESULT

			//NOTE: Source of illegal definitions are taken from Old School by Rick: Crusaders & Catacombs aka "it_ain't_done.pdf"/"Lance and Tome.pdf"
			// Impossible Attributes:
			// Any set of stats with either 2 or more scores of 5 or less
			// 3+ scores of 6 or less is ‘impossible’ and may be discarded and re-rolled.



			if (inputs.Length!=6)//check the set provided is valid
				return false;
			
			//various variables
			int resultsUnder6 = 0;
			int resultsUnder7 = 0;
			int highestMark=-1;
			for (int x = 0;x<inputs.Length;x++)
			{
				//if (die[x] == 3)//if a value of 3 shows up, discard
					//return false;
				if (inputs[x]<6)//check to tally first
					resultsUnder6++;
				if (resultsUnder6 > 1)//if there are TWO results below 6, discard
				{
					Console.WriteLine("WARNING: Illegal set, x2 values <= 5");
					return false;
				}
					
				if (inputs[x] < 7)//check to tally first
					resultsUnder7++;
				if (resultsUnder7 > 2)//if there are THREE results below 7, discard
				{
					Console.WriteLine("WARNING: Illegal set, x3 values <= 6");
					return false;
				}
			}//end of loop
			

			return true;
		}//ValidateLegalSet
		
		public static int[] ArrangeSet(int[] input)
		{
			//purpose: for sets that will prompt for order considerations, this runs through the process
			//Concern, prevent reuse of the same chars.  
			int[] output = new int[6];
			int[] usedNums = new int [6];//anti-cheating validation.  Prevent duplication.  Exeact implementation to be figured...

			/* 
			 * Order of Operations:
			 * 1. Present the stats rolled, adjacent to a selector number 1-6
			 * Note: each selector can only be used ONCE
			 * 2. Stow the selected number into an output array
			 */

			Console.WriteLine("Stat Options:");
			for (int x = 0;x<statNames.Length;x++)
				Console.WriteLine((x+1) + ": " +input[x]);//+1 to make the suggestion 1-6 not 0-5.
			Console.WriteLine("Select the corresponding number ONCE:");
			for (int x = 0;x<statNames.Length;x++)
			{//Stepping through the prompts for entry
				Restart:
				Console.Write(statNames[x]+": ");
				int.TryParse(Console.ReadLine(), out usedNums[x]);//parse and stow the selected val.
				for (int y = 0; y < x + 1; y++)//VERIFY NO ENTERED NUM IS USED TWICE
				{
					if (usedNums[y] == usedNums[x] && y != x)// compared the stored value, NOT the the indexes
					{
						Console.WriteLine("WARNING: DO NOT REUSE SELECTIONS");
						goto Restart;
					}//end of if
					 //else, no action, proceed
				}//end of loop

				output[x] = input[usedNums[x] - 1];

			}//end of loop

			//Between here and return is just test code.  Can discard
			Console.WriteLine("====================");
			for (int x = 0; x < statNames.Length; x++)
			{				
				Console.WriteLine(statNames[x] + ": " + output[x]);
			}
			//test output may be necessary.
			return output;
		}//end of ArrangeSet		
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
				Console.WriteLine("Validate: "+validate);
				
			}//end of validation failure reroll loop
			int[][] output = new int[1][];
			output[0] = ArrangeSet(results[0]);
			return output;
			//CONCERN: this would overwrite the value in rawStats.  Might be undesireable.  Or maybe negates the declarations in MAIN

		}//end of MethodI
		public static int[][] MethodII()
		{
			//"2: Method II: All scores are recorded and arranged as in Method I.  3d6 are rolled 12 times asnd the highest 6 scores are retained.\n" +
			int[][] results = new int[1][];
			results[0] = new int[12];//size of 12, or size of 6 and just discard the stats below the lowest value, or store all and filter after?
			for (int x = 0;x<12;x++)
			{
				int temp = 0;
				for (int y = 0; y<3;y++)
				{
					temp+=Dice(6);
				}//end of rolling for 1 set
				
				Console.WriteLine(temp);//test output
				
				//need a means to eval the outcome against the current stored set(s) or no sets, as the case may be.
				//PSEUDO CODE 
				/*
				if (results[0].lowest <= temp)//compare lowest stored value against the generated temp var.  If the stored value is lower, replace it.
					results[0].lowest = temp;
     				//else... loop around
	 			*/
			}//end of generation loop


			return results;
		}//end of methodII

		public static List<int[]> MethodIII()
		{
			return null;
		}
	}//end of class
}//end of namespace
