//Enum to list all current Branches
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Domain.Enum
{
    public enum BranchCategory
    {
        [Display(Name = "Catanduanes Branch")]
        Catanduanes,
        [Display(Name = "Agusan Del Norte")]
        AgusanDelNorte,
        [Display(Name = "Agusan Del Sur")]
        AgusanDelSur,
        Aklan,
        Albay,
        Bataan,
        Batangas,
        Bohol,
        Bulacan,
        [Display(Name = "Camarines Norte")]
        CamarinesNorte,
        [Display(Name = "Camarines Sur")]
        CamarinesSur,
        Capiz,
        Cavite,
        Guimaras,
        Iloilo,
        Laguna,
        Leyte,
        Marinduque,
        Masbate,
        [Display(Name = "Negros Occidental")]
        NegrosOccidental,
        [Display(Name = "Negros Oriental")]
        NegrosOriental,
        [Display(Name = "Nueva Ecija")]
        NuevaEcija,
        [Display(Name = "Occidental Mindoro")]
        OccidentalMindoro,
        [Display(Name = "Oriental Mindoro")]
        OrientalMindoro,
        Palawan,
        Pampanga,
        Panay,
        Pangasinan,
        [Display(Name = "Quezon Province")]
        QuezonProvince,
        Samar,
        Sorsogon,
        [Display(Name = "Surigao Del Norte")]
        SurigaoDelNorte,
        Tarlac,
        Zambales
    }
}
