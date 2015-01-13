using KendoUI.Views.App_LocalResources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoUI.Models.OData.Models
{
    // 参考：
    // http://msdn.microsoft.com/zh-cn/library/system.componentmodel.dataannotations.aspx
    // http://msdn.microsoft.com/zh-cn/data/jj591583
    [MetadataType(typeof(Metadata))]
    public partial class Product
    {
        private class Metadata
        {
            [Key]
            [Editable(false)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "ID_Name", ShortName = "ID_ShortName", Prompt = "ID_Prompt", Description = "ID_Description")]
            public object ID { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Name_Name", ShortName = "Name_ShortName", Prompt = "Name_Prompt", Description = "Name_Description")]
            public object Name { get; set; }

            [UIHint("DropDownSelectList")]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Currency_Name", ShortName = "Currency_ShortName", Prompt = "Currency_Prompt", Description = "Currency_Description")]
            public object CurrencyID { get; set; }

            [DataType(DataType.Currency)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "UnitPrice_Name", ShortName = "UnitPrice_ShortName", Prompt = "UnitPrice_Prompt", Description = "UnitPrice_Description")]
            public object UnitPrice { get; set; }

            [ForeignKey("CategoryID")]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Category_Name", ShortName = "Category_ShortName", Prompt = "Category_Prompt", Description = "Category_Description")]
            public object Category { get; set; }
            [UIHint("DropDownSelectList")]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Category_Name", ShortName = "Category_ShortName", Prompt = "Category_Prompt", Description = "Category_Description")]
            public object CategoryID { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(1024)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Description_Name", ShortName = "Description_ShortName", Prompt = "Description_Prompt", Description = "Description_Description")]
            public object Description { get; set; }

            [DataType(DataType.Url)]
            [MaxLength(2048)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "IntroductionUrl_Name", ShortName = "IntroductionUrl_ShortName", Prompt = "IntroductionUrl_Prompt", Description = "IntroductionUrl_Description")]
            public object IntroductionUrl { get; set; }

            [DataType(DataType.ImageUrl)]
            [MaxLength(2048)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "ImageUrl_Name", ShortName = "ImageUrl_ShortName", Prompt = "ImageUrl_Prompt", Description = "ImageUrl_Description")]
            public object ImageUrl { get; set; }

            [DataType(DataType.MultilineText)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Memo_Name", ShortName = "Memo_ShortName", Prompt = "Memo_Prompt", Description = "Memo_Description")]
            public object Memo { get; set; }
        }
    }
}