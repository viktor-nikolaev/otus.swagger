using System;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class EmployeeItemResponseModel
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }

        public string Email { get; set; }
    }
}