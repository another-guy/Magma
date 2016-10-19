namespace Magma.AspNetCore.Rest
{
    public interface IRandom
    {
        string GenerateRandomString(uint length = 32, uint preferedBufferLength = 1024);
    }
}
