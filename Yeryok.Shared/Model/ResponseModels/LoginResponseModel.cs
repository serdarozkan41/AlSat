using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yeryok.Shared.Model.ResponseModels
{
    public class LoginResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool CheckContract { get; set; }
        public bool CheckNotification { get; set; }
        public string Token { get; set; }

    }
}
