using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.ComponentsLibrary
{
    public partial class TableTemplate<TItem>
    {
        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }
        
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public bool IsSmall { get; set; }
    }
}
