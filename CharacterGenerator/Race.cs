using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	internal class Race
	{
		String name = "";
		//STR, INT, WIS, DEX, CON, CHA
		private int[] racialMinimums = new int[6];
		//must detect for the sex of a chosen character
		private int[] maleMaximums = new int[6];
		private int[] femaleMaximums = new int[6];
		private int exceptionalStrengthCapMale;
		private int exceptionalStrengthCapFemale;

		private String statModsDesc;//Just a desc text.  
		//these two must be paired together.  
		private List<int> targetScore = new List<int>();
		private List<int> scoreModification = new List<int>();

		private List<CharClass> eligibleClasses = new List<CharClass>();
		//level limits?  May delay.
		public Race() {
			

		}///end of constructor






	}//end of class
}//end of namespace
