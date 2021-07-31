namespace NoNonense.Application.Features.Notes.Queries.GetAllPaged
{
    public class GetAllPagedNotesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public string Tag { get; set; }
        public int TagId { get; set; }
    }
}