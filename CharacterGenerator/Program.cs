using System;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Text.Json;

namespace CharacterGenerator
{
	internal class Program
	{
		private static Random rnd = new Random();
		private static String[] statNames = new String[] {"STR","INT","WIS","DEX","CON","CHA"};
		private static List<int[]> rawStats = new List<int[]>();
        //the below too must closely tie their index with the above's index.  If an index is removed, the following need the corresponding done
        private static List<Race> validRaces = new List<Race>();
        private static List<CharClass> validClasses = new List<CharClass>();
		//Beginning of Racedeterminations V2.  
		private static List<Race> settingRaces = new List<Race>();
		private static List<CharClass> settingClasses = new List<CharClass>();//this is created to load into races
		static void Main()
		{
			Console.WriteLine("Hello World!");

			//not final place, just figuring out what I needed

			//for now, we're just going to brute force load.  Some other stuff would need to be configured into the race section if used later... but it's time to make the cutover.
			//simple classes, EG those that don't require wonky requirement programming
			
			
			
			settingClasses.Add(new CharClass("Fighter", new int[] { 9, 3, 6, 6, 7, 6 }, 10, 1, 0, new List<int> {2000, 4000, 8000, 18000, 35000, 70000, 125000, 250000, 500000, 750000},250000,10,99));
			settingClasses.Add(new CharClass("Paladin", new int[] { 12, 9, 13, 6, 9, 17 }, 10,1, 0, new List<int> { 2250, 4500, 10000, 20000, 40000, 90000, 150000, 225000, 325000, 650000, 975000, 1300000 }, 325000, 12, 99));
			settingClasses.Add(new CharClass("Ranger", new int[] { 13, 13, 14, 6, 14, 6 }, 8, 2, 0, new List<int> { 2250, 4500, 10000, 20000, 40000, 90000, 150000, 225000, 325000, 650000 }, 325000, 10, 99));//Ranger is edge case for HP
			settingClasses.Add(new CharClass("Illusionist", new int[] { 3, 15, 6, 16, 3, 6 }, 4, 1, 0, new List<int> { 2250, 4500, 9000, 18000, 35000, 60000, 95000, 145000, 220000, 440000 },220000,10, 99));
			settingClasses.Add(new CharClass("Mage", new int[] { 3, 9, 6, 6, 3, 6 }, 4, 1, 0, new List<int> { 2500, 5000, 10000, 22500, 40000, 60000, 90000, 135000, 250000, 375000, 750000 }, 375000, 11, 99));
			settingClasses.Add(new CharClass("Scholar", new int[] { 3, 12, 10, 6, 3, 6 },4, 1, 0, new List<int> { 2250, 4500, 9000, 18000, 35000, 60000, 95000, 145000, 220000, 440000 }, 220000, 10, 99));
			settingClasses.Add(new CharClass("Cleric", new int[] { 6, 6, 9, 3, 6, 6 }, 8, 1, 0, new List<int> { 1500, 3000, 6000, 13000, 27500, 55000, 110000, 225000, 450000, 675000 }, 225000, 10, 99));
			settingClasses.Add(new CharClass("Druid", new int[] { 6, 6, 12, 3, 6, 15 }, 8, 1, 0, new List<int> { 2000, 4000, 7500, 12500, 20000, 35000, 60000, 90000, 125000, 200000, 300000, 750000, 1500000, 3000000 }, 0,14, 15));
            settingClasses.Add(new CharClass("Bard", new int[] { 8, 12, 12, 15, 8, 14 }, 6, 1, 0, new List<int>{ 2000, 4000, 8000, 16000, 33000, 67000, 135000, 270000, 500000, 750000, 1000000, 1300000, 1600000, 1900000, 2250000, 2600000, 2950000, 3300000, 3700000, 4150000, 4650000, 5400000 },0,22,23));
			settingClasses.Add(new CharClass("Assassin", new int[] { 12, 11, 3, 12, 6, 3 }, 6, 1, 0, new List<int> { 1500, 3000, 6000, 12000, 25000, 50000, 100000, 200000, 300000, 425000, 575000, 750000, 1000000, 1500000 }, 0, 14, 15));
			settingClasses.Add(new CharClass("Scout", new int[] { 8, 11, 3, 11, 6, 3 }, 6, 1, 0, new List<int> { 1250, 2500, 5000, 10000, 20000, 42000, 70000, 110000, 160000, 220000, 440000 }, 220000, 11, 99));
			settingClasses.Add(new CharClass("Spy", new int[] { 6, 13, 9, 11, 6, 14 }, 6, 1, 0, new List<int> { 1250, 2500, 5000, 10000, 20000, 42000, 70000, 110000, 160000, 220000, 440000 }, 220000, 11, 99));
			settingClasses.Add(new CharClass("Thief", new int[] { 6, 6, 3, 9, 6, 3 }, 6, 1, 0, new List<int> { 1250, 2500, 5000, 10000, 20000, 42000, 70000, 110000, 160000, 220000, 440000 }, 220000, 11, 99));
			settingClasses.Add(new CharClass("Monk", new int[] { 15, 6, 15, 15, 11, 6 }, 4, 1, 1, new List<int> { 2250, 4750, 10000, 22500, 47500, 98000, 200000, 350000, 500000, 700000, 950000, 1250000, 1750000, 2250000, 2750000, 3250000 }, 0, 16, 17));//monk is edge case for HP

            //the monk is another edge case, this time for HP
            //Beginning of Racedeterminations V2.  
            settingRaces.Add(new Race("Human", new int[] { 3, 3, 3, 3, 3, 3 }, new int[] { 18, 18, 18, 18, 18, 18 }, new int[] { 18, 18, 18, 18, 18, 18 }, 100, 50, "", new int[] { 0, 0, 0, 0, 0, 0 },settingClasses));
            settingRaces.Add(new Race("Dwarf", new int[] { 8, 3, 3, 3, 12, 3 }, new int[] { 18, 18, 18, 17, 19, 16 }, new int[] { 17, 18, 18, 17, 19, 16 }, 99, 99, "Constitution +1 Charismas -1", new int[] { 0, 0, 0, 0, 1, -1 }, new List<CharClass> { settingClasses[0], settingClasses[6], settingClasses[9], settingClasses[11], settingClasses[12] }));
			settingRaces.Add(new Race("Elf", new int[] { 3, 8, 3, 7, 6, 8 }, new int[] { 18, 18, 18, 19, 17, 18 }, new int[] { 16, 18, 18, 19, 17, 18 }, 75, 75, "Dexterity +1 Constitution -1", new int[] { 0, 0, 0, 1, -1, 0 },new List<CharClass> { settingClasses[0], settingClasses[4], settingClasses[6], settingClasses[9], settingClasses[8], settingClasses[11], settingClasses[12] }));
            settingRaces.Add(new Race("Gnomes", new int[] { 6, 7, 3, 3, 8, 3 }, new int[] { 18, 18, 18, 18, 18, 18 }, new int[] { 15, 18, 18, 18, 18, 18 }, 50, 50, "", new int[] { 0, 0, 0, 0, 0, 0 }, new List<CharClass> { settingClasses[0], settingClasses[3], settingClasses[6], settingClasses[9], settingClasses[11], settingClasses[12] }));
            settingRaces.Add(new Race("Halfling", new int[] { 6, 6, 3, 8, 10, 3 }, new int[] { 17, 18, 17, 19, 19, 18 }, new int[] { 14, 18, 17, 19, 19, 18 }, 0, 0, "Strength -1 Dexterity +1", new int[] { 1, 0, 0, 1, 0, 0 }, new List<CharClass> { settingClasses[0], settingClasses[6], settingClasses[7], settingClasses[10], settingClasses[11], settingClasses[12] }));
            settingRaces.Add(new Race("Half-elf", new int[] { 3, 4, 3, 6, 6, 3 }, new int[] { 18, 18, 18, 18, 18, 18 }, new int[] { 17, 18, 18, 18, 18, 18 }, 90, 90, "", new int[] { 0, 0, 0, 0, 0, 0 }, new List<CharClass> { settingClasses[0], settingClasses[2], settingClasses[4], settingClasses[5], settingClasses[6], settingClasses[9], settingClasses[8], settingClasses[11], settingClasses[12]}));
            settingRaces.Add(new Race("Half-orc", new int[] { 6, 3, 3, 3, 13, 3 }, new int[] { 18, 17, 14, 17, 19, 12 }, new int[] { 18, 17, 14, 17, 19, 12 }, 99, 75, "", new int[] { 1, 0, 0, 1, 0, 0 }, new List<CharClass> { settingClasses[0], settingClasses[6], settingClasses[8], settingClasses[9], settingClasses[11], settingClasses[12] }));

			//how to reference in the class relations dynamically?
			//Would JUST the name of the class work?  Use that as the hook to reference the settingClasses available?
			settingRaces[0].EligibleClasses[0].IsAllowed( new int[] { 18,18,18,18,18,18});




            int selectedSet = 0;//for if there are multiple sets in play, it indicates what set it will use going forward.  Default 0
			int[] finalStats = new int[6];

			//Steps: generally a rough outline.  exact order to be decided upon later.
			//1. Present methods (I, II, III, IV and MANUAL ENTRY )
			//2. Prompt for input (Numeric)
			//3a Call corresponding function dedicated to a method and await output.
			//3b Roll for outcomes.
			//3c Order and display.
			//3d prompt for selections where applicable. (numeric)
			//3e prompt for ordering, where applicable. (numeric)
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
					"Based on Lance and Tome version acquired April 2025.  Thanks Rick!\n" +
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
				//Console.WriteLine(selection);//non number will print out '0'
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
					case 9:
						rawStats = MethodManual();
						break;
					default://been a while, how does one Switch?
						Console.WriteLine("Invalid entry.  Please enter a valid numeric character");
						break;
				}//end of switch block

				//Deactivating
				//DetermineRaceV1();//decoupling and decluttering main method.  This IS configured to give a return, but doesn't at present.
				for(int x=0;x<rawStats.Count;x++)//forcing to step through ALL stored rawStat sets.  This is not stepping through individual stats
					DetermineRacesV2(rawStats[x]);







				//Eval valid classes
				for (int rawIndex = 0;rawIndex < rawStats.Count; rawIndex++)
				{
					//UNIMPLMENETED
				}//end of rawSTatIndex loop



				Console.WriteLine("====================");//a string constructor should be used to make this as easy as possible.
			}//end of while(true)
		}//end of main

		public static string DetermineRaceV1()
		{

            //Eval and present valid races, and attempt to highlight stat lossess
            //male/female minimums are identical.  Breaking M/F maximums into different stat
            List<int[]> racialMinimums = new List<int[]>();
            racialMinimums.Add(new int[] { 8, 3, 3, 3, 12, 3 });//dwarf
            racialMinimums.Add(new int[] { 3, 8, 3, 7, 6, 8 });//elf
            racialMinimums.Add(new int[] { 6, 7, 3, 3, 8, 3 });//Gnome
            racialMinimums.Add(new int[] { 6, 6, 3, 8, 10, 3 });//Halfling
            racialMinimums.Add(new int[] { 3, 4, 3, 6, 6, 3 });//Half-elf
            racialMinimums.Add(new int[] { 6, 3, 3, 3, 13, 3 });//half-orc

            List<String> playerRaces = new List<String> { "Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc" };
            List<String> NPCRaces = new List<String> { "WARNING NOT SETUP" };//Will flesh out later.  Has different considerations



            for (int rawIndex = 0; rawIndex < rawStats.Count; rawIndex++)
            {
                List<String> possibleRaces = new List<String>();

                for (int racialIndex = 0; racialIndex < racialMinimums.Count; racialIndex++)
                {
                    bool test = true;//if this gets set to false, the race isn't possible.
                                     //step through each set and evaluate weather a stat set can be any of them.

                    for (int index = 0; index < 6; index++)
                    {
                        if (rawStats[rawIndex][index] < racialMinimums[racialIndex][index])
                        {
                            test = false;
                            //if the rawStat value is below the corresponding racial value... set test to false.
                            goto Next;
                        }//end of eval if stat is less than the minimum (and disqualifying)

                    }//end of stat eval loop
                Next:
                    if (test)//if true, make an index
                        possibleRaces.Add(playerRaces[racialIndex]);
                }//end of racialIndex loop
                String possibleRacesString = "Version1:\n";//temporary construct
                for (int x = 0; x < possibleRaces.Count; x++)
                {
                    possibleRacesString += possibleRaces[x] + "\n";
                }//end of 
                Console.WriteLine(possibleRacesString);//Display races available to this set.
                validRaces.Add(possibleRaces);
            }//end of rawStat Index loop

			return "";
		}//DetermineRaceV1
		public static void DetermineRacesV2(int[] inputStats)
		{
			List<string> validRaces = new List<string>();
			for (int index = 0; index < settingRaces.Count; index++)
			{
				if (settingRaces[index].IsAllowed(inputStats))
					validRaces.Add(settingRaces[index].getName());
			}//end of for loop

			Console.WriteLine("DetermineRaceV2:");
			for (int x = 0; x < validRaces.Count; x++)
				Console.WriteLine(validRaces[x]);



		}//end of DetermineRacesV2
		public static void DetermineClasses()
		{

		}//end of DetermineClasses
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
		public static List<int[]> MethodI()//Creating to segregate out the results
		{
			//1: Method I: Roll 4d6 six times, discarding the lowest, then arrange the stats to suit.  Attributes can be modified by the Race chosen later.
			List<int[]> results = new List<int[]>();//jagged array.  Probably the solution to my problemw ith passing 1D arrays
			results.Add(new int[6]);//just a single enement needed in THIS CASE.  This IS a conversion, and there may be errors.
			
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
			results[0] = ArrangeSet(results[0]);
			return results;
			//CONCERN: this would overwrite the value in rawStats.  Might be undesireable.  Or maybe negates the declarations in MAIN

		}//end of MethodI
		public static List<int[]> MethodII()
		{
			//"2: Method II: All scores are recorded and arranged as in Method I.  3d6 are rolled 12 times asnd the highest 6 scores are retained.\n" +
			List<int[]> results = new List<int[]>();
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
		public static List<int[]> MethodManual()
		{
			List<int[]> results = new List<int[]>();
			results.Add(new int[6]);
			for (int x = 0; x < statNames.Length; x++)
			{//Stepping through the prompts for entry
				Console.Write(statNames[x] + ": ");
				int.TryParse(Console.ReadLine(), out results[0][x]);//parse and stow the selected val.
				

			}//end of loop
			return results;
		}//end of MethodManual
	}//end of class
}//end of namespace
