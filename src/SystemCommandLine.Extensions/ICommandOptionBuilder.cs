using System.CommandLine;

namespace SystemCommandLine.Extensions;

public interface ICommandOptionBuilder<TCommand, TOption> where TCommand : Command, IUseCommandBuilder<TCommand>
{
    ICommandBuilder<TCommand> AddToCommand();
    ICommandOptionBuilder<TCommand, TOption> Configure(Action<Option<TOption>> value);
}