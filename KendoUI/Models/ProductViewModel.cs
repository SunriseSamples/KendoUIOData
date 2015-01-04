using KendoUI.Views.App_LocalResources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoUI.Models
{
    // 参考：
    // http://msdn.microsoft.com/zh-cn/library/system.componentmodel.dataannotations.aspx
    // http://msdn.microsoft.com/zh-cn/data/jj591583
    [MetadataType(typeof(Metadata))]
    public class ProductViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public short? CurrencyID { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public string Description { get; set; }
        public string IntroductionUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Memo { get; set; }

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

            [ForeignKey("Currency")]
            [StringLength(3)]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Currency_Name", ShortName = "Currency_ShortName", Prompt = "Currency_Prompt", Description = "Currency_Description")]
            public object CurrencyID { get; set; }

            [Display(ResourceType = typeof(ViewModelResource), Name = "UnitPrice_Name", ShortName = "UnitPrice_ShortName", Prompt = "UnitPrice_Prompt", Description = "UnitPrice_Description")]
            [DataType(DataType.Currency)]
            public object UnitPrice { get; set; }

            [ForeignKey("Category")]
            [Display(ResourceType = typeof(ViewModelResource), Name = "Category_Name", ShortName = "Category_ShortName", Prompt = "Category_Prompt", Description = "Category_Description")]
            public object CategoryID { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(1024)]
            public object Description { get; set; }

            [DataType(DataType.Url)]
            [MaxLength(2048)]
            public object IntroductionUrl { get; set; }

            [DataType(DataType.ImageUrl)]
            [MaxLength(2048)]
            public object ImageUrl { get; set; }

            [Display(ResourceType = typeof(ViewModelResource), Name = "Memo_Name", ShortName = "Memo_ShortName", Prompt = "Memo_Prompt", Description = "Memo_Description")]
            [DataType(DataType.MultilineText)]
            public object Memo { get; set; }
        }
    }
}