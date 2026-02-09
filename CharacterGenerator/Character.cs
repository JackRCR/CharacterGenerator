using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	internal class Character
	{
		private int[] rawStats = new int[6];//raw stats to be held in reserve ALWAYS
		private int[] magicStatAdjs = new int[6];//a plce to track the net permanent stat effects affecting a character.  Does not track source.  May change to some other method.
		private int[] actualStats = new int[6];//modified stat state.  May occassionally require recalcing, checking race, sex, etc.
		
		
		private CharClass charClass;//for reference
		private Race race;//for reference
		
		private int age;
		private bool sex;//true = male, false = female
		
		
		public Character()
		{
			
		}//end of constructor

        public int[] RawStats { get => rawStats; set => rawStats = value; }
        public int[] MagicStatAdjs { get => magicStatAdjs; set => magicStatAdjs = value; }
        public int[] ActualStats { get => actualStats; set => actualStats = value; }
        public int Age { get => age; set => age = value; }
        public  CharClass CharClass { get => charClass; set => charClass = value; }
        public Race Race { get => race; set => race = value; }
        public bool Sex { get => sex; set => sex = value; }

        public void StatReCalc()
		{//recalc actualStats as they change.
			/* 
			 * Rules:
			 * A stat canot exceed a Class or Race minimum or maximum via "mundane" methods.  
			 * 
			 * Procedure:
			 * 1. Apply racial adjustments
			 * 2. Determine age category per race.
			 * 3. Apply age categories sequentially.
			 * 4. Check stat against Class and Race mins and maxs.  If in violation, give notice, and adjust the limit.
			 * 5. Apply magical adjustments.
			 * 
			 */

		}//end of StatRecalc
		public string toString()
		{
			return "Class: " + charClass.Name + " Race: " + race.Name;
		}//end of 
	}//end of class
}//end of namespace
