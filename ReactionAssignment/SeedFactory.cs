
/*
 * SeedFactory Class 
 * Author: Brendan Kelly
 * Date: 25 April 2017
 * Description: Generates different Seed algorithms based on input values
 */

namespace ReactionAssignment
{
    public class SeedFactory
    {
        public SeedFactory()
        {
        }


        public ISeeder GenerateSeedAlgorithm(ESeedingAlgorithmType seedChoice)
        {
            ISeeder chosenSeed = null;

            switch (seedChoice)
            {
                case ESeedingAlgorithmType.FourCorners:
                    chosenSeed = new SeedFourCorners();
                    break;

                case ESeedingAlgorithmType.CentreFour:
                    chosenSeed = new SeedCentreFour();
                    break;

                case ESeedingAlgorithmType.RandomFour:
                    chosenSeed = new SeedRandomFour();
                    break;

                case ESeedingAlgorithmType.RandomSixteen:
                    chosenSeed = new SeedRandomSixteen();
                    break;

                case ESeedingAlgorithmType.CentreSixteen:
                    chosenSeed = new SeedCenterSixteen();
                    break;

                case ESeedingAlgorithmType.CentreSixtyFour:
                    chosenSeed = new SeedCenterSixtyFour();
                    break;
            }

            return chosenSeed;
        }
    }
}
