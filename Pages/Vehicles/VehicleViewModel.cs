using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using trans_track.Models;

namespace trans_track.Pages.Vehicles
{
    public class VehicleViewModel : PageModel
    {
        public int ID { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        [StringLength(4)]
        [RegularExpression(@"^[0-9]+$")]
        public string Year { get; set; }

        [Display(Name = "Capacity")]
        [RegularExpression(@"^[0-9]+$")]
        public string Capacity { get; set; }

        [StringLength(7, MinimumLength = 7)]
        public string License { get; set; }

        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        [Display(Name = "Date Purchased")]
        public DateTime DatePurchased { get; set; }

        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePaid { get; set; }

        [Display(Name = "Purchased From")]
        public string PurchasedFrom { get; set; }

        public string ImagePath { get; set; }
        public string VehicleName
        {
            get { return Year + " " + Make + " " + Model + " - " + License; }
        }

        public bool Warning { get; set; }
        public string WarningMessage { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
