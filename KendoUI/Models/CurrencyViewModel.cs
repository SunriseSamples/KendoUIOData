using KendoUI.Views.App_LocalResources;
using System.ComponentModel.DataAnnotations;

namespace KendoUI.Models.OData.Models
{
    [MetadataType(typeof(Metadata))]
    public partial class Currency
    {
        //public short ID { get; set; }
        //public string Code { get; set; }
        //public string Culture { get; set; }

        private class Metadata
        {
            [Key]
            [Display(ResourceType = typeof(ViewModelResource), Name = "ID_Name", ShortName = "ID_ShortName", Prompt = "ID_Prompt", Description = "ID_Description")]
            public object ID { get; set; }

            [Required]
            [MaxLength(3)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Code_Name", ShortName = "Code_ShortName", Prompt = "Code_Prompt", Description = "Code_Description")]
            public object Code { get; set; }

            [MaxLength(5)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Culture_Name", ShortName = "Culture_ShortName", Prompt = "Culture_Prompt", Description = "Culture_Description")]
            public object Culture { get; set; }
        }
    }
}