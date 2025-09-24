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
		//A general note: the below attributes and variables should change little during a campaign.  This is instantiated to be referenced to, not to be changed.
		//think of this as more of a reference sheet for the given race.  
		//... Racial specifics are making me think this needs to become an interface that's extended and allows polymorphism to handle the catastrophe to come.
		String name;
		//STR, INT, WIS, DEX, CON, CHA
		private int[] racialMinimums = new int[6];
		//must detect for the sex of a chosen character
		private int[] maleMaximums = new int[6];
		private int[] femaleMaximums = new int[6];
		private int exceptionalStrengthCapMale;
		private int exceptionalStrengthCapFemale;

		private String statModsDesc;//Just a desc text, no funcitons performed.

		
		private int[] scoreModification = new int[6];//how stats are modified by choosing this race.
													 //For example a dwarf would be [4]=1 && [5]=-1, reflecting Con+1 && Cha-1 respectively.  All other scores would be zeros.  Dwarf: [0,0,0,0,1,-1]

		//class/level considerations
		//any add/remove operations require syncronization. Am not segregating into a seperate class here
		private List<CharClass> eligibleClasses = new List<CharClass>();//what classes can this race play?
		private List<char> classRestrictions = new List<char>();//unused presently.  Has... issues.
		/*this will be code based.
		 * U==unlimited 
		 * A==attribute limited is specified elsewhere.  Still need to flag.
		 * <number>==specific limit
		 * '*'==variable limits, depending on attribute and the specific class
		 * '**'==priest specific limits
		 * That last is going to be awful to encode.  I just know it!
		 * Well... it'll be annoying.  
		 * With the grouping of "super" classes into the categories of Warrior, MU, Priest, Rogue, and Monk (which may or may not be it's own thing) providing broad rules, it'll be ok.
		 * 
		 * OUTSTANDING QUESTION: where should this check be made?
		 * OUTSTANDING QUESTION: are there other simplifications that can be performed?  As is, this is complicated.  Could restrictions be moved to CharClass, or otherwise checked?
		 * 
		 */




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
