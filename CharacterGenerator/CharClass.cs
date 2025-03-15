using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	internal class CharClass
	{
		private int[] statReqs;
		private int hitDie;
		private List<int> experienceThresholds = new List<int>();
		private int additionalList;
		private int hardCap;
		private List<String> allowedRaces = new List<String>();//might change this to something else.
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