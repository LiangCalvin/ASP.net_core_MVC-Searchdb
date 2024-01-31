using System.ComponentModel.DataAnnotations;

namespace CheckComDetail.Models
{
   public class ComputerInfo
{
        [Key]
        public string ComputerID { get; set; }
        public string SerialNumber { get; set; }
        public string ComputerModel { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserBuilding { get; set; }
        public string UserFloor { get; set; }
        public string UserZone { get; set; }
    }

}
