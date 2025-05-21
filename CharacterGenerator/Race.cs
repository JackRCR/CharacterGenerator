using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	internal class Race
	{
		String name;
		//STR, INT, WIS, DEX, CON, CHA
		private int[] racialMinimums = new int[6];
		//must detect for the sex of a chosen character
		private int[] maleMaximums = new int[6];
		private int[] femaleMaximums = new int[6];
		private int exceptionalStrengthCapMale;
		private int exceptionalStrengthCapFemale;

		private String statModsDesc;//Just a desc text, no funcitons performed.
		
		//these two must be paired together.  
		private List<int> targetScore = new List<int>();//...? what was I thinking of here?
		private List<int> scoreModification = new List<int>();//how stats are modified by choosing this race.

		//class/level considerations
		private List<CharClass> eligibleClasses = new List<CharClass>();//what classes can this race play?
		//I fear I may be creating a loop between CharClass and Race
		//level limits need some implementation.  Uncertain at this time how or where to do so.  Maybe in races, maybe classes, maybe in some third place.

		//level limits?  May delay.
		public Race(String name, int[] racialMinimums, int[]maleMaximums, int[] femaleMaximums, 
			int exceptionalStrengthCapMale, int exceptionalStrengthCapFemale, String statModsDesc,List<int> targetScore, List<int> scoreModification) {
			this.name = name;
			this.racialMinimums = racialMinimums;
			this.maleMaximums = maleMaximums; 
			this.femaleMaximums = femaleMaximums;
			this.exceptionalStrengthCapMale = exceptionalStrengthCapMale;
			this.exceptionalStrengthCapFemale = exceptionalStrengthCapFemale;
			this.statModsDesc = statModsDesc;
			this.targetScore = targetScore;
			this.scoreModification = scoreModification;
			//just the simplest of constructors.  Take and assign value.

		}///end of constructor






	}//end of class
}//end of namespace
