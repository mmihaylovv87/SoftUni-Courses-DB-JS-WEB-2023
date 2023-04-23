using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions
{
    public class CreatePositionInputModel
    {
        [StringLength(30, MinimumLength = 3)]
        public string PositionName { get; set; } = null!;
    }
}