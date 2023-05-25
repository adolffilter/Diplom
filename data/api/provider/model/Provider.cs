using DiplomaOborotovIS.data.api.model.user;
using System.ComponentModel.DataAnnotations;

namespace diplomaISPr22_33_PankovEA.data.api.provider.model
{
    internal class Provider : User
    {
        [Required] public ProviderPost Post { get; set; } = new();
    }
}
