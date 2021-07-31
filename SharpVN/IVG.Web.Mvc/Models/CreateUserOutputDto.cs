using IVG.Web.Mvc.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class CreateUserOutputDto
    {
        public List<DropdownItemDto> ASCCombobox { get; set; }
        public List<DropdownItemDto> ActiveCombobox { get; set; }
        public AdminUsersView AdminUserView { get; set; }
        public List<string> RoleNames { get; set; }
        public CreateUserOutputDto()
        {
            ASCCombobox = new List<DropdownItemDto>();
            AdminUserView = new AdminUsersView();
            RoleNames = new List<string>();
            ActiveCombobox = new List<DropdownItemDto>
            {
                new DropdownItemDto{Id="true",DisplayName="Hoạt động",Selected=true},
                new DropdownItemDto{Id="false",DisplayName="Không hoạt động"},
            };
        }
    }
}