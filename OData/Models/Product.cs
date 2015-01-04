using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Spatial;
using System.Web;
using System.Data.Entity.Spatial;

namespace OData.Models
{
    [Table("Products")]
    public class Product
    {
        // 参考：http://msdn.microsoft.com/zh-cn/library/ms187942.aspx
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("CurrencyID")]
        public virtual Currency Currency { get; set; }
        public short? CurrencyID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public int? CategoryID { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(1024)]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(2048)]
        public string IntroductionUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        [MaxLength(2048)]
        public string ImageUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }

        //[DataType(DataType.Duration)]
        //public TimeSpan? Duration { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[Column(TypeName = "varchar")]
        //[MaxLength(20)]
        //public string PhoneNumber { get; set; }

        //[DataType(DataType.Html)]
        //public string Html { get; set; }

        //[DataType(DataType.EmailAddress)]
        //[MaxLength(256)]
        //public string EmailAddress { get; set; }

        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[DataType(DataType.CreditCard)]
        //[Column(TypeName = "varchar")]
        //[MaxLength(20)]
        //public string CreditCard { get; set; }

        //[DataType(DataType.PostalCode)]
        //[Column(TypeName = "varchar")]
        //[MaxLength(20)]
        //public string PostalCode { get; set; }

        //[DataType(DataType.Upload)]
        //public byte[] Upload { get; set; }

        // 参考：http://msdn.microsoft.com/zh-cn/library/ms177603.aspx
        public bool? Bit { get; set; }

        // 数字类型参考：http://msdn.microsoft.com/zh-cn/library/ff848794.aspx

        public byte? TinyInt { get; set; }

        public short? SmallInt { get; set; }

        public int? Int { get; set; }

        public long? BigInt { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? SmallMoney { get; set; }

        [Column(TypeName = "money")]
        public decimal? Money { get; set; }

        // 下面的2个类型是一样的，默认是 Decimal(18, 2)

        public decimal? Decimal { get; set; }

        public decimal? Numeric { get; set; }

        // 下面的4个类型生成迁移代码后，需要手动修改 precision 参数

        // precision: 9
        public decimal? Numeric5 { get; set; }

        // precision: 19
        public decimal? Numeric9 { get; set; }

        // precision: 28
        public decimal? Numeric13 { get; set; }

        // precision: 38
        public decimal? Numeric17 { get; set; }

        public float? Real { get; set; }

        public double? Float { get; set; }

        // 日期和时间类型参考：http://msdn.microsoft.com/zh-cn/library/ff848733.aspx

        private static DateTimeOffset? ToDateTimeOffset(DateTime? value)
        {
            return value.HasValue ? new DateTimeOffset(value.Value) : (DateTimeOffset?)null;
        }

        private static DateTime? ToDateTime(DateTimeOffset? value)
        {
            return value.HasValue ? value.Value.DateTime : (DateTime?)null;
        }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [NotMapped]
        public DateTimeOffset? EdmDate
        {
            get { return ToDateTimeOffset(Date); }
            set { Date = ToDateTime(value); }
        }

        [DataType(DataType.Time)]
        [Column(TypeName = "time")]
        public TimeSpan? Time { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "smalldatetime")]
        public DateTime? SmallDateTime { get; set; }
        [NotMapped]
        public DateTimeOffset? EdmSmallDateTime
        {
            get { return ToDateTimeOffset(SmallDateTime); }
            set { SmallDateTime = ToDateTime(value); }
        }

        // 建议改用 datetime2
        [DataType(DataType.DateTime)]
        public DateTime? DateTime { get; set; }
        [NotMapped]
        public DateTimeOffset? EdmDateTime
        {
            get { return ToDateTimeOffset(DateTime); }
            set { DateTime = ToDateTime(value); }
        }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime? DateTime2 { get; set; }
        [NotMapped]
        public DateTimeOffset? EdmDateTime2
        {
            get { return ToDateTimeOffset(DateTime2); }
            set { DateTime2 = ToDateTime(value); }
        }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? DateTimeOffset { get; set; }

        // 字符串和二进制类型参考：http://msdn.microsoft.com/zh-cn/library/ff848814.aspx

        [Column(TypeName = "char")]
        [MaxLength(10)]
        public string Char10 { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string VarChar50 { get; set; }

        // 下面的类型生成迁移代码后，需要手动去掉 maxLength 参数
        [Column(TypeName = "varchar")]
        public string VarCharMax { get; set; }

        // 建议改用 varchar(max)
        [Column(TypeName = "text")]
        public string Text { get; set; }

        [Column(TypeName = "nchar")]
        [MaxLength(10)]
        public string NChar10 { get; set; }

        [MaxLength(50)]
        public string NVarChar50 { get; set; }

        public string NVarCharMax { get; set; }

        // 建议改用 nvarchar(max)
        [Column(TypeName = "ntext")]
        public string NText { get; set; }

        [Column(TypeName = "binary")]
        [MaxLength(50)]
        public byte[] Binary { get; set; }

        [Column(TypeName = "varbinary")]
        [MaxLength(50)]
        public byte[] VarBinary { get; set; }

        public byte[] VarBinaryMax { get; set; }

        // 建议改用 varbinary(max)
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        // 参考：http://msdn.microsoft.com/zh-cn/library/ms182776.aspx
        [Timestamp]
        public byte[] RowVersion { get; set; }

        // 下面的类型暂不支持
        // 参考：http://msdn.microsoft.com/zh-cn/library/ms173829.aspx
        //public string SqlVariant { get; set; }

        // 参考：http://msdn.microsoft.com/zh-cn/library/ms187339.aspx
        [Column(TypeName = "xml")]
        public string Xml { get; set; }

        // 空间类型参考：http://msdn.microsoft.com/zh-cn/library/ff848797.aspx

        public DbGeometry Geometry { get; set; }

        public DbGeography Geography { get; set; }

        // 下面的类型暂不支持
        // 参考：http://msdn.microsoft.com/zh-cn/library/bb677290.aspx
        //public string HierarchyID { get; set; }
    }
}