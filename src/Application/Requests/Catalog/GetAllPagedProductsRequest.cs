﻿namespace NoNonense.Application.Requests.Catalog
{
    public class GetAllPagedProductsRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}