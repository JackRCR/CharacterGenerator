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
		private int[] actualStats = new int[6];//modified stat state.  May occassionally require recalcing, checking race, sex, etc.
		
		private Race race;
		private bool sex;//true = male, false = female
		private CharClass charClass;
		public Character()
		{
			
		}//end of constructor
	}//end of class
}//end of namespace
