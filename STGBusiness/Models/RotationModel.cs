using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGBusiness.Models
{
    public class RotationModel
    {
        public int[] ShirtNumbers {get; set;}

        public RotationModel()
        {
            ShirtNumbers = new int[6];
        }

        public void Rotate()
        {
            int temporaryPosition = ShirtNumbers[0];
            ShirtNumbers[0] = ShirtNumbers[1];
            ShirtNumbers[1] = ShirtNumbers[2];
            ShirtNumbers[2] = ShirtNumbers[3];
            ShirtNumbers[3] = ShirtNumbers[4];
            ShirtNumbers[4] = ShirtNumbers[5];
            ShirtNumbers[5] = temporaryPosition;
        }
    }
}
