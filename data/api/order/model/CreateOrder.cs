using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomaISPr22_33_PankovEA.data.api.order.model
{
    internal class CreateOrder
    {
        [Required, MaxLength(256)] public string Title { get; set; } = string.Empty;
        [Required, MaxLength(1080)] public string Description { get; set; } = string.Empty;
        [Required] public int ProviderId { get; set; }
    }
}
