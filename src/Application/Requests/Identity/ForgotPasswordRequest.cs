﻿using System.ComponentModel.DataAnnotations;

namespace NoNonense.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}