using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IVG.Web.Mvc.EF;
namespace IVG.Web.Mvc.Models
{
    public class FilterServiceLogItemDto
    {
        public List<tbl_EscalationDicision> tbl_EscalationDicision { get; set; }
        public List<tbl_TransactionChannel> tbl_TransactionChannel { get; set; }
        public List<tbl_Provinces> tbl_Provinces { get; set; }
        public List<tbl_EscalateTo> tbl_EscalateTo { get; set; }
        public List<tbl_QualityAssuranceChecking> tbl_QualityAssuranceChecking { get; set; }
        public List<tbl_TypeOfInquiry> tbl_TypeOfInquiry { get; set; }
        public List<tbl_ProductType> tbl_ProductType { get; set; }
        public List<tbl_TransactionStatus> tbl_TransactionStatus { get; set; }
        public List<SortBy> SortBy { get; set; }
        public FilterServiceLogItemDto()
        {
            tbl_EscalationDicision = new List<tbl_EscalationDicision>();
            tbl_TransactionChannel = new List<tbl_TransactionChannel>();
            tbl_Provinces = new List<tbl_Provinces>();
            tbl_EscalateTo = new List<tbl_EscalateTo>();
            tbl_QualityAssuranceChecking = new List<tbl_QualityAssuranceChecking>();
            tbl_TypeOfInquiry = new List<tbl_TypeOfInquiry>();
            tbl_ProductType = new List<tbl_ProductType>();
            tbl_TransactionStatus = new List<tbl_TransactionStatus>();
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