using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CharacterGenerator
{
    struct AdvancedClassStatDefinitions
    {
        //placement here to allow instantiation and use across relevant classes
        public int[] statIDs;//ID the stats that have a threshold.
                             //stat IDs are dogmatically ["STR","INT","WIS","DEX","CON","CHA"].  Can't figure out any other way to do this.
        public int threshold;//What the IDed stats must meet or exceed to be "counted"
        public int numOfConditionals;//number of stats that need to meet/exceed threshold to pass.
        public int[][] fixedStatIDsAndThresholds = new int[2][];//int[0][] = stat position; int[1][]=thresholds
        /* ORDER FUCKING MATTERS
        * EG: 
        * [0][0]=cha
        * [1][0]=13
        * [0][1]=con
        * [1][1]=6
        * 
        * Etc.
        * May rewrite to be less confusing, but FOR NOW, is good.
        */
        public AdvancedClassStatDefinitions(int[] statIDs, int threshold, int numOfConditionals, int[] statPositions, int[] statValues)
        {
            this.statIDs = statIDs;
            this.threshold = threshold;
            this.numOfConditionals = numOfConditionals;
            this.fixedStatIDsAndThresholds[0] = statPositions;
            this.fixedStatIDsAndThresholds[1] = statValues;
        }//end of constructor

        

    }//end of struct
    internal class AdvancedWarrior:CharClass
    {
        //For classes with more complex requirements or combinations.  
        //not quite sure how to implement.  Not sure if possible to implement in one swift action.  

        //make this a strut
        
        private AdvancedClassStatDefinitions requirements;
        int statFloor = 6;



        public AdvancedWarrior(string name, int[] statReqs, int hitDie, int initialDice, int plusHP, List<int> experienceThresholds, int additionalXP, int softCap, int hardCap,
            AdvancedClassStatDefinitions requirements) :
            base(name, statReqs, hitDie, initialDice, plusHP, experienceThresholds, additionalXP, softCap, hardCap)
        {
            this.requirements = requirements;
            
        }//end of constructor
        public new bool IsAllowed(int[] inputStats)
        {
            //overrides CharClass method.
            if (base.IsAllowed(inputStats))
            //Check the parent class, for an explicit set, if there's a static threshold that is established, a la the barbarian
            {
                return true;
            }//but, if there isn't ...
            else
            {
                
                //OVERHAUL IN PROGRESS
                //TODO:
                /* 
                * test
                * add notes to make it abundantly clear to myself what the heck I'm thinking here.
                * test again.  Check against the three classes that are most likely to cause issues.
                */ 
                
                //First, count the threshold stats.
                int count = 0;
                for (int x = 0; x < requirements.statIDs.Length; x++)
                {
                    //locate the stats, retrieve the first value, 
                    // check against the inputStat entry corresponding with that index, against the threshold.
                    if (inputStats[requirements.statIDs[x]]>=requirements.threshold)
                        count++;//count if pass
                    else if (inputStats[requirements.statIDs[x]]<statFloor)
                        return false;//stat is not just below threshold, but below the stat floor, and is ineligible
                    Console.WriteLine("Count: "+count);//debugging

                }
                //Second, check the static requirements are achived
                for (int x = 0; x < requirements.fixedStatIDsAndThresholds.Length; x++)
                {
                    
                    if (inputStats[requirements.fixedStatIDsAndThresholds[0][x]<requirements.fixedStatIDsAndThresholds[1][x]])
                        return false;//and if you don't reach, fail out.
                        //THIS WILL REQUIRE A FAIR BIT OF TESTING
                }

                if (count>=requirements.numOfConditionals)
                    return true;//pass
                else
                    return false;//fail
            }
        }
    }//end of class
}//end of namespace
