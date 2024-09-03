namespace AuthNote.Api.Configurations.Options
{
    public class JwtAuthenticationOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string MetadataAddress { get; set; }
        public bool RequireHttpsMetadata { get; set; }
    }
}
