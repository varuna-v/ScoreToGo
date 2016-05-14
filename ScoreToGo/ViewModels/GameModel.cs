using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace ScoreToGo.ViewModels
{
    public class GameModel
    {
        public GameModel()
        {
            Teams = new List<TeamModel>() { new TeamModel(), new TeamModel() };
        }

        public int Id { get; set; }

        private List<TeamModel> _teams;
        public List<TeamModel> Teams
        {
            get
            {
                List<TeamModel> _teams = new List<TeamModel>() { new TeamModel(), new TeamModel() };
                if (!string.IsNullOrEmpty(TeamACode))
                {
                    _teams[0] = AvailableTeams.FirstOrDefault(t => t.Code == TeamACode);
                }

                if (!string.IsNullOrEmpty(TeamBCode))
                {
                    _teams[1] = AvailableTeams.FirstOrDefault(t => t.Code == TeamBCode);
                }
                return _teams;
            }
            set { _teams = value; }
        }

        public string TeamACode { get; set; }
        public string TeamBCode { get; set; }

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
                List<TeamModel> teams = new List<TeamModel>() { new TeamModel { Code = string.Empty, Name = "Select" } };
                if (AvailableTeams != null) { teams.AddRange(AvailableTeams); }
                return new SelectList(teams, "Code", "Name", new { Code = string.Empty, Name = "Select" });
            }
        }
    }
}