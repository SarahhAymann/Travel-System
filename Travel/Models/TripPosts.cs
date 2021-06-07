using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class TripPosts
    {
        public int ID { get; set; }

        public string TripTitle { get; set; }
        public string TripDetails { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime TripDate { get; set; }
        public int Post_Like { get; set; }
        public int Post_DisLike { get; set; }

        public string TripDestination { get; set; }
        public string AgencyName { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Destination Pic")]
        public string TripImage { get; set; }

        [NotMapped]

        public HttpPostedFileBase postImageFile { get; set; }
    }
}