﻿namespace STG.Business.DomainModels
{
    public class Set
    {
        public int[] Score { get; set; }

        public TeamRotation[] TeamRotations { get; set; }

        public int FirstServer { get; set; }

        public int Winner { get; set; }
    }
}
