namespace CellManagerAPI.Application.DTO.DTO.Auth;

public class TokenDto
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
