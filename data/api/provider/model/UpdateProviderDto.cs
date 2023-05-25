using System.ComponentModel.DataAnnotations;

namespace diplomaISPr22_33_PankovEA.data.api.provider.model
{
    internal class UpdateProviderDto
    {
        [Required, MaxLength(128)] public string Login { get; set; } = string.Empty;
        [Required, MaxLength(128)] public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(128)] public string LastName { get; set; } = string.Empty;
        [Required, MaxLength(128)] public string MidleName { get; set; } = string.Empty;
    }
}
