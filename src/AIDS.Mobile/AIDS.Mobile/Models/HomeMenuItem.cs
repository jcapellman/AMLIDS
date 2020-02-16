namespace AIDS.Mobile.Models
{
    public enum MenuItemType
    {
        Traffic,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
