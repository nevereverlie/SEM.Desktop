namespace SEM.Desktop.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int WorkedHours { get; set; }
        public int WastedHours { get; set; }
        public int WorkedMinutes { get; set; }
        public int WastedMinutes { get; set; }
        public string[] AllowedApps { get; set; }
    }
}