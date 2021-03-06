﻿using System.ComponentModel.DataAnnotations;

namespace ScoreToGo.ViewModels
{
    public class PlayerModel
    {
        public bool Selected { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RegistrationNumber { get; set; }
        //Validate - required if Selected == true
        public int ShirtNumber { get; set; }
    }
}
