using System;
using System.Collections.Generic;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.Administration
{
    public class Employee
        : BaseEntity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public List<Role> Roles { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}