using System.CommandLine;

namespace SystemCommandLine.Extensions.Builders;

internal class CommandArgumentBuilder<TCommand, TOption>(ICommandBuilder<TCommand> commandBuilder, TCommand command, string name) :
    ICommandArgumentBuilder<TCommand, TOption> where TCommand : Command, IUseCommandBuilder<TCommand>
{
    protected readonly Argument<TOption> argument = new(NameFormatExtensions.ToKebabCase(name));

    public virtual ICommandArgumentBuilder<TCommand, TOption> Configure(Action<Argument<TOption>> value)
    {
        value.Invoke(argument);
        return this;
    }

    public virtual ICommandBuilder<TCommand> AddToCommand()
    {
        command.Add(argument);
        return commandBuilder;
    }
}