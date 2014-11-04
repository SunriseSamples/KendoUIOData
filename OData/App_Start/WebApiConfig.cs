using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
// OData v3
//using Microsoft.Data.Edm;
//using System.Web.Http.OData.Builder;
//using System.Web.Http.OData.Extensions;
// OData v4
using Microsoft.OData.Edm;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 取消注释下面的代码行可对具有 IQueryable 或 IQueryable<T> 返回类型的操作启用查询支持。
            // 若要避免处理意外查询或恶意查询，请使用 QueryableAttribute 上的验证设置来验证传入查询。
            // 有关详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=279712。
            //config.EnableQuerySupport();

            // 若要在应用程序中禁用跟踪，请注释掉或删除以下代码行
            // 有关详细信息，请参阅: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            // OData v3:
            // Microsoft.AspNet.WebApi.OData
            //     Microsoft.AspNet.WebApi.Client
            //     Microsoft.AspNet.WebApi.Core
            //     Microsoft.Data.OData
            //         System.Spatial
            //         Microsoft.Data.Edm
            // 参考：http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v3/creating-an-odata-endpoint
            //config.Routes.MapODataServiceRoute("ODataRoute", "odata", GetModel());
            //config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;

            // OData v4:
            // Microsoft.AspNet.OData
            //     Microsoft.AspNet.WebApi.Client
            //     Microsoft.AspNet.WebApi.Core
            //     Microsoft.OData.Core
            //         Microsoft.Spatial
            //         Microsoft.OData.Edm
            // 参考：http://damienbod.wordpress.com/2014/06/10/getting-started-with-web-api-and-odata-v4/
            // 基础教程：http://www.odata.org/getting-started/basic-tutorial/
            // 高级教程：http://www.odata.org/getting-started/advanced-tutorial/
            config.MapODataServiceRoute("ODataRoute", "odata", GetModel());

            //config.EnsureInitialized();
        }

        public static IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();

            //var brands = builder.EntitySet<BrandDataObject>("Brands");
            //var commodities = builder.EntitySet<CommodityDataObject>("Commodities");
            //var banks = builder.EntitySet<BankDataObject>("Banks");
            //var warehouses = builder.EntitySet<WarehouseDataObject>("Warehouses");
            //var tradingCompanies = builder.EntitySet<TradingCompanyDataObject>("TradingCompanies");

            //var batches = builder.EntitySet<BatchDataObject>("Batches");
            //var contracts = builder.EntitySet<ContractDataObject>("Contracts");
            //var batchContracts = builder.EntitySet<BatchContractDataObject>("BatchContracts");
            //var contractDetails = builder.EntitySet<ContractDetailDataObject>("ContractDetails");
            //var pricings = builder.EntitySet<PricingDataObject>("Pricings");
            //var certificates = builder.EntitySet<CertificateDataObject>("Certificates");
            //var inventories = builder.EntitySet<InventoryDataObject>("Inventories");
            //var funds = builder.EntitySet<FundDataObject>("Funds");
            //var invoices = builder.EntitySet<InvoiceDataObject>("Invoices");

            return builder.GetEdmModel();
        }
    }
}
