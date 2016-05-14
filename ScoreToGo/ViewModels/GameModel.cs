using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ScoreToGo.ViewModels
{
    public class GameModel
    {
        public GameModel()
        {
            Teams = new TeamModel[2];
        }

        public int Id { get; set; }

        public TeamModel[] Teams { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartedAt { get; set; }

        public GamePlayModel GamePlay { get; set; }

        //Validation - must be odd
        public int BestOfNumberOfSets { get; set; }

        public List<TeamModel> AvailableTeams { get; set; }

        public IEnumerable<SelectListItem> AvailableTeamList
        {
            get
            {
                return new SelectList(AvailableTeams, "Code", "Name");
            }
        }
    }
}