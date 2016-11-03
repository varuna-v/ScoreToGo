using System;
using STG.Domain.Models;

namespace ScoreToGo
{
    public static class TestDataProvider
    {
        private static Random _randomGenerator = new Random();

        //!! remove all refrences to use input data
        public static TeamRotation[] GetRandomTeamRotationModels()
        {
            var teamRotations = new TeamRotation[2];
            teamRotations[0] = new TeamRotation() { ShirtNumbers = GetRandomShirtNumbers(true) };
            teamRotations[1] = new TeamRotation() { ShirtNumbers = GetRandomShirtNumbers(false) };
            return teamRotations;
        }

        private static int[] GetRandomShirtNumbers(bool even)
        {
            var shirtNumbers = new int[6];
            for (int i = 0; i < 6; i++)
            {
                shirtNumbers[i] = GetRandom(1, 50, even);
            }
            return shirtNumbers;
        }

        public static int GetRandom(int min, int max, bool even)
        {
            int random = (_randomGenerator.Next(min, max + 1)) * 2;
            if (even)
                return random;
            else
                return random - 1;
        }

        public static int GetRandom(int min, int max)
        {
            return _randomGenerator.Next(min, max + 1);
        }
    }
}