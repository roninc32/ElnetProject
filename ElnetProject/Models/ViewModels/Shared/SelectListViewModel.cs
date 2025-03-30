namespace ElnetProject.Models.ViewModels.Shared
{
    /// <summary>
    /// Enhanced SelectList for standardized dropdown menus across the application
    /// </summary>
    public class SelectListViewModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
        public bool Disabled { get; set; }
        public string Group { get; set; }
        public string IconClass { get; set; }
        public Dictionary<string, string> AdditionalAttributes { get; set; } = new Dictionary<string, string>();

        // Helper method for creating a basic select item
        public static SelectListViewModel Create(string value, string text, bool selected = false)
        {
            return new SelectListViewModel
            {
                Value = value,
                Text = text,
                Selected = selected
            };
        }
    }
}