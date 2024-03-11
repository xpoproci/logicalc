using Microsoft.AspNetCore.Components;
using UI.Shared;

namespace UI.Components.Helpers
{
    public class SidebarChanger : ComponentBase
    {
        [CascadingParameter]
        public MainLayout? Layout { get; set; }

        [Parameter]
        public RenderFragment Sidebar { get; set; }

        protected override void OnInitialized()
        {
            Layout?.SetSidebarContent(Sidebar);
        }
    }
}
