using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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





        //make this a strut
        int statFloor = 6;//hard coded, doesn't matter what stat it applies to.
        
       private AdvancedClassStatDefinitions requirements;


        //int[] bonus XP thresholds//no idea how to detect elegately.
        //probably belongs in the baseCharClass



        public AdvancedWarrior(string name, int[] statReqs, int hitDie, int initialDice, int plusHP, List<int> experienceThresholds, int additionalXP, int softCap, int hardCap,
            AdvancedClassStatDefinitions requirements) :
            base(name, statReqs, hitDie, initialDice, plusHP, experienceThresholds, additionalXP, softCap, hardCap)
        {
            this.requirements = requirements;

        }//end of constructor
        public new bool IsAllowed(int[] inputStats)
        {
            //overrides CharClass method.
            if (base.IsAllowed(inputStats))//Check the parent class, for an explicit set, if there's a static threshold that is established, a la the barbarian
            {
                return true;
            }//but, if there isn't ...
            else
            {
                int count = 0;
                for (int x = 0; x < requirements.statIDs.Length; x++)
                {
                    if (inputStats[requirements.statIDs[x]] >= requirements.threshold)
                            count++;
                }//
                if (count>=requirements.numOfConditionals)
                    return true;//pass
                else
                    return false;//fail
            }
        }
    }//end of class
}//end of namespace
