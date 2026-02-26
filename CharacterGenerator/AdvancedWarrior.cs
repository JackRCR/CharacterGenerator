using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CharacterGenerator
{
    internal class AdvancedWarrior:CharClass
    {
        //For classes with more complex requirements or combinations.  
        //not quite sure how to implement.  Not sure if possible to implement in one swift action.  
        

        
        struct Sets
        {
            int[] statIDs;//which stats can be IDed?
            int threshold;//stat to meet or exceed
            int numOfConditionals;//number of stats that need to meet/exceed threshold to pass.
        }
        //make this a strut
        int statFloor = 6;//hard coded, doesn't matter what stat it applies to.
        //List<int[]> sets;//As in the barbarian case there is an explicit set that passes.
       private Sets sets;


        //int[] bonus XP thresholds//no idea how to detect elegately.
        //probably belongs in the baseCharClass



        public AdvancedWarrior(string name, int[] statReqs, int hitDie, int initialDice, int plusHP, List<int> experienceThresholds, int additionalXP, int softCap, int hardCap, 
            Sets sets):
            base(name, statReqs, hitDie, initialDice, plusHP, experienceThresholds, additionalXP, softCap, hardCap)
        {
            this.sets = sets;

        }//end of constructor
        public bool IsAllowed(int[] inputStats)
        {
            //overrides CharClass method.
            return false;
        }
    }//end of class
}//end of namespace
