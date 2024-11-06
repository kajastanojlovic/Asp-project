using Nutrition.Application;
using Nutrition.Application.UseCases;
using System.Diagnostics;
using System.Windows.Input;

namespace Nutrition.Implementation
{
    public class UseCaseHandler
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;

        public UseCaseHandler(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TData>(ICommand<TData> command, TData data)
        {
            HandleCCC(command, data);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            command.Execute(data);

            stopwatch.Stop();

            Console.WriteLine($"UseCase: {command.Name}, {stopwatch.ElapsedMilliseconds} ms");
        }
        public TResult HandleQuery<TResult, TSearch>(IQuery<TResult, TSearch> query, TSearch search)
         where TResult : class

        {
            HandleCCC(query, search);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = query.Execute(search);

            stopwatch.Stop();

            Console.WriteLine($"UseCase: {query.Name}, {stopwatch.ElapsedMilliseconds} ms");

            return result;
        }

        private void HandleCCC(IUseCase useCase, object data)
        {
            if (!_actor.AllowedUseCases.Contains(useCase.Id))
            {
                throw new UnauthorizedAccessException();
            }

            var log = new UseCaseLog
            {
                UseCaseData = data,
                UseCaseName = useCase.Name,
                Username = _actor.Username
            };

            _logger.Log(log);
        }
    }
}
