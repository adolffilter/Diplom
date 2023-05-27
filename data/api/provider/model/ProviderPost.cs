using System.ComponentModel.DataAnnotations;

namespace diplomaISPr22_33_PankovEA.data.api.provider.model
{
    public class ProviderPost
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
