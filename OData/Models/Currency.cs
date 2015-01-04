using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OData.Models
{
    // 参考：
    // country code (ISO 3166 Alpha-2)
    // http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
    // currency code (ISO 4217 Alpha-3)
    // http://zh.wikipedia.org/wiki/ISO_4217
    // National Language Support (NLS) API Reference
    // http://msdn.microsoft.com/zh-cn/goglobal/bb896001.aspx
    [Table("Currencies")]
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ID { get; set; }

        [Required]
        [Column(TypeName = "char")]
        [MaxLength(3)]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(5)]
        public string Culture { get; set; }
    }
}