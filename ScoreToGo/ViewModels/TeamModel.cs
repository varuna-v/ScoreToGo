using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScoreToGo.ViewModels
{
    public class TeamModel
    {
        public TeamModel()
        {
            Players = new List<PlayerModel>();
        }
        
        public string Name { get; set; }
        public string Colour { get; set; }
        public Color TeamColour { get { return Color.FromName(Colour); } }
        public string Code { get; set; }
        public List<PlayerModel> Players { get; set; }
        public string GameLetter { get; set; }
    }
}
