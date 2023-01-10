using System.ComponentModel.DataAnnotations;

namespace Voyager.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        [Display(Name = "Trip")]
        public string? TripName { get; set; }
        [StringLength(100)]
        [Display(Name = "Description")]
        public string? TripDesc { get; set; }
        [Display(Name = "Trip Image")]
        public string? TripUrl { get; set; }
        [Display(Name = "Location")]
        public string? Location { get; set; }
        [Display(Name = "Available Activities")]
        public string? Activity { get; set; }
        [Display(Name = "#Tags")]
        public string? Tag { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Trip Starting From")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Trip Ending From")]
        public DateTime EndTime { get; set; }
        
    }
}
