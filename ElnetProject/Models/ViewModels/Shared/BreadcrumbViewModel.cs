namespace ElnetProject.Models.ViewModels.Shared
{
    /// <summary>
    /// Provides consistent navigation breadcrumbs across the application
    /// </summary>
    public class BreadcrumbViewModel
    {
        public List<BreadcrumbItem> Items { get; set; } = new List<BreadcrumbItem>();

        public class BreadcrumbItem
        {
            public string Text { get; set; }
            public string Url { get; set; }
            public bool IsActive { get; set; }
            public string Icon { get; set; }
        }

        // Helper method to build breadcrumb trail
        public void AddItem(string text, string url = null, string icon = null)
        {
            // Mark previous active item as inactive if it exists
            if (Items.Any(i => i.IsActive))
            {
                Items.First(i => i.IsActive).IsActive = false;
            }

            Items.Add(new BreadcrumbItem
            {
                Text = text,
                Url = url,
                Icon = icon,
                IsActive = true
            });
        }

        // Helper method to generate home breadcrumb
        public static BreadcrumbViewModel CreateDefault()
        {
            var model = new BreadcrumbViewModel();
            model.AddItem("Home", "/", "fas fa-home");
            return model;
        }
    }
}