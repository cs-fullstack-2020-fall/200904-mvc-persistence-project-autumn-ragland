using System;
using System.ComponentModel.DataAnnotations;
// database model with model annotation for data validation
namespace ArtistsInResidency.Models
{
    public class ArtModel 
    {
        [Key]
        public int id{get;set;}
        public string title{get;set;}
        [Required]
        public string medium{get;set;}
        [Required]
        [StringLength(300)]
        public string description{get;set;}
        [Required]
        [Range(1970,2020)]
        public int yearCompleted{get;set;}
    }
}