using KendoUI.Views.App_LocalResources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoUI.Models
{
    // 参考：http://msdn.microsoft.com/zh-cn/library/system.componentmodel.dataannotations.aspx
    [MetadataType(typeof(Metadata))]
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; }

        private class Metadata
        {
            [Key]
            [Editable(false)]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "ID_Name", ShortName = "ID_ShortName", Prompt = "ID_Prompt", Description = "ID_Description")]
            public object ID { get; set; }

            [Required]
            [StringLength(10, MinimumLength = 3)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Name_Name", ShortName = "Name_ShortName", Prompt = "Name_Prompt", Description = "Name_Description")]
            public object Name { get; set; }

            [Display(ResourceType = typeof(ViewModelResource), Name = "Price_Name", ShortName = "Price_ShortName", Prompt = "Price_Prompt", Description = "Price_Description")]
            [DataType(DataType.Currency)]
            public object Price { get; set; }

            [StringLength(150)]
            [ForeignKey("Category")]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Category_Name", ShortName = "Category_ShortName", Prompt = "Category_Prompt", Description = "Category_Description")]
            public object Category { get; set; }
        }
    }
}