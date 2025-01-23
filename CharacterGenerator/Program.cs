using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace CharacterGenerator
{
	internal class Program
	{
		private static Random rnd;
		static void Main()
		{
			Console.WriteLine("Hello World!");

			//not final place, just figuring out what I needed
			int[][] rawStats;//size of the array will 
			int selectedSet = -1;//for if there are multiple sets in play.
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

			//1: present methods
			Console.WriteLine(
				"Welcome to Carefulrogue's Character Generator!\n" +
				"To begin, select a method (numpad):\n" +
				"1: Method I:\n" +
				"2: Method II:\n" +
				"3: Method III:\n" +
				"4: Method IV:\n" +
				"5: MANUAL ENTRY\n");
			//2: read input

			/*
			switch (selectedSet) {
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
			}*/

			//4 display results
			Console.WriteLine("test");//a string constructor should be used to make this as easy as possible.
		}
		public int Dice(int die)
		{//executes one cast of the dice.
			die++;//ups the passed value, to be max inclusive
			int x = rnd.Next(1, die);
			return x;
		}//end of Dice
		public static int[][] MethodI()//Creating to segregate out the results
		{

			return new int[0][];//TEMPORARY OUTPUT
		}//end of MethodI

	}
}