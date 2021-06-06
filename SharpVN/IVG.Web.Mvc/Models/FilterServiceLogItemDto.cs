using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IVG.Web.Mvc.EF;
namespace IVG.Web.Mvc.Models
{
    public class FilterServiceLogItemDto
    {
        public List<DropdownItemDto> tbl_EscalationDicision { get; set; }
        public List<DropdownItemDto> tbl_TransactionChannel { get; set; }
        public List<DropdownItemDto> tbl_Provinces { get; set; }
        public List<DropdownItemDto> tbl_EscalateTo { get; set; }
        public List<DropdownItemDto> tbl_QualityAssuranceChecking { get; set; }
        public List<DropdownItemDto> tbl_TypeOfInquiry { get; set; }
        public List<DropdownItemDto> tbl_ProductType { get; set; }
        public List<DropdownItemDto> tbl_TransactionStatus { get; set; }
        public List<SortBy> SortBy { get; set; }
        public FilterServiceLogItemDto()
        {
            tbl_EscalationDicision = new List<DropdownItemDto>();
            tbl_TransactionChannel = new List<DropdownItemDto>();
            tbl_Provinces = new List<DropdownItemDto>();
            tbl_EscalateTo = new List<DropdownItemDto>();
            tbl_QualityAssuranceChecking = new List<DropdownItemDto>();
            tbl_TypeOfInquiry = new List<DropdownItemDto>();
            tbl_ProductType = new List<DropdownItemDto>();
            tbl_TransactionStatus = new List<DropdownItemDto>();
            SortBy = new List<SortBy>();
            //SortBy.Add(
            //    new SortBy { Value = 1, Text = "Reference No. (A-Z)" },
            //    new SortBy { Value = 2, Text = "Reference No. (Z-A)" }
            //    );
        }
    }
    public class SortBy
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}