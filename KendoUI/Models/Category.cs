using KendoUI.Views.App_LocalResources;
using System.ComponentModel.DataAnnotations;

namespace KendoUI.Models.OData.Models
{
    [MetadataType(typeof(Metadata))]
    public partial class Category
    {
        private class Metadata
        {
            [Key]
            [Editable(false)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "ID_Name", ShortName = "ID_ShortName", Prompt = "ID_Prompt", Description = "ID_Description")]
            public object ID { get; set; }

            [Required]
            [MaxLength(50)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Name_Name", ShortName = "Name_ShortName", Prompt = "Name_Prompt", Description = "Name_Description")]
            public object Name { get; set; }
        }
    }
}