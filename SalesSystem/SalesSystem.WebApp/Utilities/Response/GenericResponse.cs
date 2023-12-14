namespace SalesSystem.WebApp.Utilities.Response
{
    public class GenericResponse<TObject>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public TObject? Object { get; set; }

        public TObject? ObjectList { get; set; }
    }
}
