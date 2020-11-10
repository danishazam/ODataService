using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using ODataService.Models;
using Microsoft.Data.OData;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace ODataService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ODataService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Setting>("Settings");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [EnableQuery]
    public class SettingsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Settings
        public IHttpActionResult GetSettings(ODataQueryOptions<Setting> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<IEnumerable<Setting>>(DataSource.DataSource.Instance.Settings); 
        }

        // GET: odata/Settings(5)
        public IHttpActionResult GetSetting([FromODataUri] int key, ODataQueryOptions<Setting> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var setting = DataSource.DataSource.Instance.Settings.Where(x => x.Id == key).FirstOrDefault();
            return Ok<Setting>(setting);                 
        }        
    }
}
