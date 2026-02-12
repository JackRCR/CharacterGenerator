using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	internal class CharClass
	{
		//A general note: the below attributes and variables should change little during a campaign.  This is instantiated to be referenced to and calc from, not to be changed.
		private string name;
		private int[] statReqs = new int[6];//States required to choose class.
		//HP vars
		private int hitDie;//what size of die
		private int initialdice;//how many do they start with
		private int plusHP;//modification for Monk-type HP.
		
		private int maxHD;//what level does HD cap out
		private int additionalHP;//HP past the HD cap. <levels beyond maxHD>*additionalHP are added to the HP total
		//experience section
		private List<int> experienceThresholds = new List<int>();//thresholds for leveling
		private int additionalXP;//XP require to exceed soft cap
		private int softCap;//the softCap where xp thresholds change.
		private int hardCap;//maximum possible level.  
		private List<string> titles = new List<string>();
		
		private bool npcOnly=false;

		private bool attributeLimited;//if false, discard any requests further down.  If true, add/include results further down
		

		private int[] attributes;//specifying the indexes of StatReqs are to be checked to pull the values.  To my knowledge just 2 are typical.  
								 //just specify 0-5 WHICH of the six stats they are to check the statReq with an index.
		private int[] baseline;//
		private int[] threshold;//For however many 'attributes' there are, define the floor threshold.
		//The simple variant of calcing levellimits is "Stat-threshold=additional_levels+baseline==ActualLimit/BookLimit"
		//Wishes or GM fiat can overrule.  
		//I'm CERTAIN there will be a few flaws in this logic.  This may be shelved and checked elsewhere at some other point in time.

		//general notes, level limits ARE NOT IMPLEMENTED!!!
		//See Man-at-arms, Summoner, Religious brother, to compare/contrast.
		//Man-at-arms and RB are handled in a similar fashion.
		//Summoner may require it's own class inheriting the values and overriding the attribute calculation.
		
		public CharClass(string name, int[] statReqs, int hitDie, int initialDice, int plusHP, List<int>experienceThresholds, int additionalXP, int softCap, int hardCap) {
			this.Name = name;
			this.StatReqs = statReqs;
			this.HitDie = hitDie;
			this.Initialdice = initialDice;
			this.PlusHP = plusHP;
			this.ExperienceThresholds = experienceThresholds;
			this.AdditionalXP = additionalXP;
			this.SoftCap = softCap;
			this.HardCap = hardCap;
		}//end of constructor

        public string Name { get => name; set => name = value; }
        public int[] StatReqs { get => statReqs; set => statReqs = value; }
        public int HitDie { get => hitDie; set => hitDie = value; }
        public int Initialdice { get => initialdice; set => initialdice = value; }
        public int PlusHP { get => plusHP; set => plusHP = value; }
        public int MaxHD { get => maxHD; set => maxHD = value; }
        public int AdditionalHP { get => additionalHP; set => additionalHP = value; }
        public List<int> ExperienceThresholds { get => experienceThresholds; set => experienceThresholds = value; }
        public int AdditionalXP { get => additionalXP; set => additionalXP = value; }
        public int SoftCap { get => softCap; set => softCap = value; }
        public int HardCap { get => hardCap; set => hardCap = value; }
        public List<string> Titles { get => titles; set => titles = value; }
        public bool NpcOnly { get => npcOnly; set => npcOnly = value; }
        public bool AttributeLimited { get => attributeLimited; set => attributeLimited = value; }
        public int[] Attributes { get => attributes; set => attributes = value; }
        public int[] Baseline { get => baseline; set => baseline = value; }
        public int[] Threshold { get => threshold; set => threshold = value; }

        public bool IsAllowed(int[] inputStats)
		{
			//NOTE, USED TO HAVE A RACE ASPECT TO THIS.  Removing as I think it needs to be decoupled.
			//where this gets called has some implications now.  Probably via a Race class call
			return inputStats[0] >= StatReqs[0] &&
				inputStats[1] >= StatReqs[1] &&
				inputStats[2] >= StatReqs[2] &&
				inputStats[3] >= StatReqs[3] &&
				inputStats[4] >= StatReqs[4] &&
				inputStats[5] >= StatReqs[5];
		}


	}//end of class
}//end of namespace