using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Components
{
    public class ProfilePictureBase : ComponentBase
    {
        protected string CssClass { set; get; } = "circle";

        protected void PictureClick()
        {
            CssClass = CssClass == "circle" ? null : "circle";
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
