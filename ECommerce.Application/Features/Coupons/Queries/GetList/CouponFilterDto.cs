using ECommerce.Application.Contracts.Common;
using ECommerce.Application.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Coupons.Queries.GetList
{
    public class CouponFilterDto : IFilter
    {
        public string? Code { get; set; }
        public DatePeriod? ValidFromUtc { get; set; }
        public DatePeriod? ValidToUtc { get; set; }
        public int? PercentageFrom { get; set; }
        public int? PercentageTo { get; set; }
    }
}
