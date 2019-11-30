using System;
using System.Collections.Generic;
using System.Text;

namespace SampleServices
{
  public class CategoryModel
    {
        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
    
    public class SubcategoryModel
    {
        public string Subcategory { get; set; }
        public int SubcategoryId { get; set; }
    }

    public class ServiceTimingsModel
    {
        public string Timings { get; set; }
    }
}
