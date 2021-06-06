using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class PostsRequests
    {
        public int ID { get; set; }

        public string TripTitle { get; set; }
        public string TripDetails { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime TripDate { get; set; }
        public string RequestStatus { get; set; } = "Pending";

        public string TripDestination { get; set; }
        public string AgencyName { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Destination Pic")]
        public string TripImage { get; set; }



        [NotMapped]

        public HttpPostedFileBase requestImageFile { get; set; }
    }
}