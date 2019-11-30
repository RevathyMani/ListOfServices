using System;
using System.Collections.Generic;

namespace SampleServices
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetData _get = new GetData(new SqlHelper());
            Console.WriteLine("Service Details\n");
            Console.WriteLine("---------------");
            List<CategoryModel> _category = _get.GetCategoryDetails();
            foreach (CategoryModel _categoryModel in _category)
            {
                Console.WriteLine("Category : " + _categoryModel.Category + " \t Category ID: " + _categoryModel.CategoryId);
            }
            Console.Write("\n\nEnter category id : ");

            var _categoryId = Console.ReadLine();
            var _SubcategoryList = _get.GetSubcategoryDetailsById(Int32.Parse(_categoryId));
            foreach (SubcategoryModel _subcategoryModel in _SubcategoryList)
            {
                Console.WriteLine("SubCategory : " + _subcategoryModel.Subcategory + " \t SubCategory ID: " + _subcategoryModel.SubcategoryId);
            }
            Console.Write("\n\nEnter Subcategory id : ");
            var subCategoryId = Console.ReadLine();
            var _serviceTimings = _get.GetServiceTimingsBySubcategory(Int32.Parse(subCategoryId));
            foreach (ServiceTimingsModel _serviceTimingsdetails in _serviceTimings)
            {
                Console.WriteLine("Service Timings : " + _serviceTimingsdetails.Timings);
            }

            Console.ReadLine();
        }

    }
}
