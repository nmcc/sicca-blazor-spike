using System.ComponentModel.DataAnnotations;

namespace SICCA.Web.Spike.Models;

public class CentralConfigurationModel
{
    [Display(Name = "IP do Central")]
    [Required(ErrorMessage = "Campo obrigatório")]
    [RegularExpression(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}", ErrorMessage = "IP Inválido")]
    public string Central1Ip { get; set; } = string.Empty;

    [Display(Name = "Porto do Central", Description = "Numero entre 1 e 65532")]
    [Required(ErrorMessage = "Campo obrigatório")]
    [Range(1, 65532, ErrorMessage = "Introduzir numero entre 1 e 65532")]
    public int Central1Port { get; set; }

}
