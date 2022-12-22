using System.ComponentModel.DataAnnotations;

namespace SICCA.Web.Spike.Models;

public class CentralConfigurationModel
{
    [Required]
    [MinLength(5)]
    [RegularExpression(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}", ErrorMessage = "IP Inválido")]
    public string Central1Ip { get; set; } = string.Empty;

    [Required]
    [Range(1, 65533)]
    public int Central1Port { get; set; }

    [Required]
    [RegularExpression(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}", ErrorMessage = "IP Inválido")]
    public string Central2Ip { get; set; } = string.Empty;

    [Required]
    [Range(1, 65533)]
    public int Central2Port { get; set; }
}
