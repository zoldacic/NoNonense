namespace NowWhat.Application.Requests.Catalog
{
    public class GetAllPagedNotesRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}