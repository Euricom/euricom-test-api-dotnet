

namespace ShopSchema.Exceptions
{
    public class PageOutOfRangeException : BusinessException
    {
        public PageOutOfRangeException(int page) : base($"The page number {page} is out of range.", "page_out_of_range") { }
    }
}
