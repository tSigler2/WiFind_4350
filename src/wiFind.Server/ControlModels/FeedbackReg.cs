﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace wiFind.Server.ControlModels
{
    public class FeedbackReg
    {
        public string? user_id { get; set; }

        [Required, MaxLength(30)]
        public string subject { get; set; }

        [MaxLength(500)]
        public string description { get; set; } = "";

        [Required, Range(1, 10)]
        public short rating { get; set; }
    }
}
