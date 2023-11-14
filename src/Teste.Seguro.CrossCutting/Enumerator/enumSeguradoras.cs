using System.ComponentModel.DataAnnotations;

namespace Teste.Seguro.CrossCutting.Enumerator
{
    public enum enumSeguradoras
    {
        [Display(Name = "Alfa Seguradora")]
        Alfa,
        [Display(Name = "Aliro")]
        Aliro,
        [Display(Name = "Allianz Seguros")]
        Allianz,
        [Display(Name = "Azul Seguros")]
        Azul,
        [Display(Name = "Bradesco Seguros")]
        Bradesco,
        [Display(Name = "HDI Seguros")]
        HDI,
        [Display(Name = "Itaú Seguros")]
        Itau,
        [Display(Name = "Ituran")]
        Ituran,
        [Display(Name = "Liberty Seguros")]
        Liberty,
        [Display(Name = "Mapfre Seguros")]
        Mapfre,
        [Display(Name = "Mitsui Seguros")]
        Mitsui,
        [Display(Name = "Porto Seguro")]
        Porto,
        [Display(Name = "Sompo Seguros")]
        Sompo,
        [Display(Name = "Suhai Seguros")]
        Suhai,
        [Display(Name = "Tokio Marine Seguros")]
        TokioMarine,
        [Display(Name = "Zurich Seguros")]
        Zurich,
        [Display(Name = "Youse")]
        Youse
    }
}
