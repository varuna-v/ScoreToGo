using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using STG.Domain.Models;

namespace ScoreToGo.ViewModels
{
    public class GameModel
    {
        public GameModel()
        {
           Teams = new List<TeamModel>() { new TeamModel(), new TeamModel() };
        }

        public int Id { get; set; }

        public string TeamACode { get; set; }
        public string TeamBCode { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartedAt { get; set; }

        public GamePlay GamePlay { get; set; }

        //Validation - must be odd
        public int BestOfNumberOfSets { get; set; }

        public TeamModel[] AvailableTeams { get; set; }

        public IEnumerable<SelectListItem> AvailableTeamAList
        {
            get
            {
                List<TeamModel> teams = new List<TeamModel>() { new TeamModel { Code = string.Empty, Name = "Select" } };
                if (AvailableTeams != null) { teams.AddRange(AvailableTeams); }
                var result = new SelectList(teams, "Code", "Name", new { Code = string.Empty, Name = "Select" });
                return result;
            }
        }

        public IEnumerable<SelectListItem> AvailableTeamBList
        {
            //!!set selected!!
            get
            {
                List<TeamModel> teams = new List<TeamModel>() { new TeamModel { Code = string.Empty, Name = "Select" } };
                if (AvailableTeams != null) { teams.AddRange(AvailableTeams); }
                var result = new SelectList(teams, "Code", "Name", new { Code = string.Empty, Name = "Select" });
                return result;
            }
        }

        private List<TeamModel> _teams;
        public List<TeamModel> Teams
        {
            get
            {
                if (_teams == null) 
                    _teams = new List<TeamModel>() { new TeamModel(), new TeamModel() };
                if (!string.IsNullOrEmpty(TeamACode) && (_teams[0] == null || string.IsNullOrEmpty(_teams[0].Name)))
                {
                    _teams[0] = AvailableTeams.FirstOrDefault(t => t != null && t.Code == TeamACode);
                }

                if (!string.IsNullOrEmpty(TeamBCode) && (_teams[1] == null || string.IsNullOrEmpty(_teams[1].Name)))
                {
                    _teams[1] = AvailableTeams.FirstOrDefault(t => t != null &&  t.Code == TeamBCode);
                }
                return _teams;
            }
            set { _teams = value; }
        }

    }
}