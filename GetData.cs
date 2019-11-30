using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleServices
{
    public class GetData
    {
        private readonly ISqlHelper _sqlDBHelper;
        public GetData(ISqlHelper sqlDBHelper)
        {
            _sqlDBHelper = sqlDBHelper;
        }
        public List<CategoryModel> GetCategoryDetails()
        {
            var parameters = new DynamicParameters();
            return _sqlDBHelper.GetList<CategoryModel>("PrcGetServiceCategoryDetails", parameters);
        }
        public List<SubcategoryModel> GetSubcategoryDetailsById(int categoryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@categoryid", categoryId);
            return _sqlDBHelper.GetList<SubcategoryModel>("prc_GetSubcategoryDetailsbyCategory", parameters);
        }
        public List<ServiceTimingsModel> GetServiceTimingsBySubcategory(int subcategoryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@subcategoryId", subcategoryId);
            return _sqlDBHelper.GetList<ServiceTimingsModel>("prc_GetServiceTimingBySubcategory", parameters);
        }
    }
}
