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
            teamRotations[0] = new TeamRotation() { ShirtNumbers = GetRandomShirtNumbers() };
            teamRotations[1] = new TeamRotation() { ShirtNumbers = GetRandomShirtNumbers() };
            return teamRotations;
        }

        private static int[] GetRandomShirtNumbers()
        {
            var shirtNumbers = new int[6];
            for (int i = 0; i < 6; i++)
            {
                shirtNumbers[i] = _randomGenerator.Next(1, 50);
            }
            return shirtNumbers;
        }

        public static int GetRandom(int min, int max)
        {
            return _randomGenerator.Next(min, max + 1);
        }
    }
}