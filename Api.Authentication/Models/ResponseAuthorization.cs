namespace Api.Authentication.Models
{
    public class ResponseAuthorization<T> where T : class
    {
        public T viewModel { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
