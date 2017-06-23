using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        /// <summary>
        /// 客戶編號
        /// </summary>
        public int CustomerID { get; set; }

        ///<summary>
        ///客戶名稱
        ///<summary>
        public string CompanyName { get; set; }
        ///<summary>
        ///聯絡人姓名
        ///<summary>
        public string ContactName { get; set; }
        ///<summary>
        ///聯絡人職稱
        ///<summary>
        public string ContactTitle{ get; set; }
        ///<summary>
        ///建立日期
        ///<summary>
        public DateTime CreationDate{ get; set; }
        ///<summary>
        ///地址
        ///<summary>
        public string Address { get; set; }
        ///<summary>
        ///城市
        ///<summary>
        public string City { get; set; }
        ///<summary>
        ///區域
        ///<summary>
        public string Region { get; set; }
        ///<summary>
        ///郵遞區號
        ///<summary>
        public string PostalCode { get; set; }
        ///<summary>
        ///國家
        ///<summary>
        public string Country { get; set; }
        ///<summary>
        ///電話
        ///<summary>
        public string Phone { get; set; }
        ///<summary>
        ///傳真
        ///<summary>
        public string Fax { get; set; }
    }
}