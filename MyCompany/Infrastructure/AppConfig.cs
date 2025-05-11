namespace MyCompany.Infrastructure
{
    public class AppConfig
    {
        public TinyMCE TinyMCE { get; set; } = new TinyMCE();
        public Company Company { get; set; } = new Company();
    }
    public class TinyMCE
    {
        public string? ApiKey { get; set; }
    }

    public class Company
    {
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyPhoneShort { get; set; }
        public string? CompanyEmail { get; set; }
    }
}
