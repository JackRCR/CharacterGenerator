using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	internal class CharClass
	{
		private int[] statReqs = new int[6];//States required to choose class.
		private int hitDie;
		//experience section
		private List<int> experienceThresholds = new List<int>();//thresholds for leveling
		private int additionalXP;//XP require to exceed soft cap
		private int softCap;//the softCap where xp thresholds change.
		private int hardCap;//maximum possible level.  If x == 0 should be uncapped.
		
		private bool npcOnly=false;

		private List<String> allowedRaces = new List<String>();//what races can play this class?
		//I fear I may be creating a loop between CharClass and Race
		//level limits need some implementation.  Uncertain at this time how or where to do so.  Maybe in races, maybe classes, maybe in some third place.
		public CharClass() {
			
		}//end of constructor

		public bool IsAllowed(string race,int[] inputStats)
		{
			return allowedRaces.Contains(race) &&
				inputStats[0] >= statReqs[0] &&
				inputStats[1] >= statReqs[1] &&
				inputStats[2] >= statReqs[2] &&
				inputStats[3] >= statReqs[3] &&
				inputStats[4] >= statReqs[4] &&
				inputStats[5] >= statReqs[5];
		}


	}//end of class
}//end of namespace