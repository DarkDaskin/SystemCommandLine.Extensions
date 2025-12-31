using System.CommandLine;

namespace SystemCommandLine.Extensions;

public interface ICommandOptionBuilderWithMapping<TCommand, TOptionHolder, TOption>
    where TCommand : Command, IUseCommandBuilder<TCommand>
    where TOptionHolder : class
{
    ICommandBuilderWithMapping<TCommand, TOptionHolder> AddToCommand();
    ICommandOptionBuilderWithMapping<TCommand, TOptionHolder, TOption> Configure(Action<Option<TOption>> value);
}