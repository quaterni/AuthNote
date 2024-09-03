namespace AuthNote.LocalIdentity.Services.Abstractions
{
    public interface IJwtService
    {
        string GetToken(Identity identity);
    }
}