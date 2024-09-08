namespace UserRegistryApi.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public DateTime registered_at { get; set; }
    }
}
