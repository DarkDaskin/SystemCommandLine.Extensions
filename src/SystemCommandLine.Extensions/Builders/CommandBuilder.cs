using System.CommandLine;

namespace SystemCommandLine.Extensions.Builders;

internal class CommandBuilder<TCommand>(TCommand command) : ICommandBuilder<TCommand> where TCommand : Command, IUseCommandBuilder<TCommand>
{
    public ICommandArgumentBuilder<TCommand, TOption> NewArgument<TOption>(string name)
    {
        return new CommandArgumentBuilder<TCommand, TOption>(this, command, name);
    }

    public ICommandOptionBuilder<TCommand, TOption> NewOption<TOption>(string name)
    {
        return new CommandOptionBuilder<TCommand, TOption>(this, command, name);
    }

    public ICommandBuilderWithMapping<TCommand, TOptionHolder> WithMapping<TOptionHolder>(SymbolMapperRegistration mapperRegistration)
        where TOptionHolder : class
    {
        return new CommandBuilderWithMapping<TCommand, TOptionHolder>(this, command, mapperRegistration);
    }
}
