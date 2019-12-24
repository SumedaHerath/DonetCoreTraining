namespace Aventude.Demo.eShop.Core
{
    public class PageOptions
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool IsFirstPage()
        {
            return Page == 1;
        }
    }
}
