﻿using System.ComponentModel.DataAnnotations;


namespace wiFind.Server.ControlModels
{
    public class FeedbackReg
    {
        //public string? user_id { get; set; } // making feedbacks anonymous for temporary

        [Required, MaxLength(30)]
        public string subject { get; set; }

        [MaxLength(500)]
        public string description { get; set; } = "";

        [Required, System.ComponentModel.DataAnnotations.RangeAttribute(1, 10)]
        public short rating { get; set; }
    }
}
