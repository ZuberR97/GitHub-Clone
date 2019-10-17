using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GithubClone.Models
{
    public class Repository
    {
        [Key]
        public int RepositoryId {get;set;}

        [Required]
        public string Name {get;set;}

        public string Description {get;set;}

        [Required]
        public Boolean IsPublic {get;set;}

        public int UserId {get;set;}
    }
}