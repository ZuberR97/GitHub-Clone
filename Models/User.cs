using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GithubClone.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        public string UserName {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [MinLength(8)]
        public string Password {get;set;}

        [MaxLength(255)]
        public string Bio {get;set;}
        public Boolean IsTrue {get;set;} //should be removed
    }

    public class Login
    {
        public string UNEInput {get;set;}
        public string Password {get;set;}
    }
}