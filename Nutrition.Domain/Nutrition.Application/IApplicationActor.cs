namespace Nutrition.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Username { get; }
        string Email { get; }
        IEnumerable<int> AllowedUseCases { get; }

    }
}
