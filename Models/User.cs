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
        
        public List<Repository> MyRepositories {get;set;}
    }

    public class Login
    {
        [Required]
        public string UNEInput {get;set;}  //UNEInput stands for UserName/Email Input
        [Required]
        public string Password {get;set;}
    }
}