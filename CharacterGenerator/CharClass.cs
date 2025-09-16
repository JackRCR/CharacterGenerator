using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	internal class CharClass
	{
		//A general note: the below attributes and variables should change little during a campaign.  This is instantiated to be referenced to, not to be changed.

		private int[] statReqs = new int[6];//States required to choose class.
		private int hitDie;
		//experience section
		private List<int> experienceThresholds = new List<int>();//thresholds for leveling
		private int additionalXP;//XP require to exceed soft cap
		private int softCap;//the softCap where xp thresholds change.
		private int hardCap;//maximum possible level.  If x == 0 should be uncapped.
		
		private bool npcOnly=false;

		
		public CharClass(int[] statReqs, int hitDie, List<int>experienceThresholds, int additionalXP, int softCap, int hardCap) {
			this.statReqs = statReqs;
			this.hitDie = hitDie;
			this.experienceThresholds = experienceThresholds;
			this.additionalXP = additionalXP;
			this.softCap = softCap;
			this.hardCap = hardCap;
		}//end of constructor

		public bool IsAllowed(int[] inputStats)
		{
			//NOTE, USED TO HAVE A RACE ASPECT TO THIS.  Removing as I think it needs to be decoupled.
			//where this gets called has some implications now.  Probably via a Race class call
			return inputStats[0] >= statReqs[0] &&
				inputStats[1] >= statReqs[1] &&
				inputStats[2] >= statReqs[2] &&
				inputStats[3] >= statReqs[3] &&
				inputStats[4] >= statReqs[4] &&
				inputStats[5] >= statReqs[5];
		}


	}//end of class
}//end of namespace