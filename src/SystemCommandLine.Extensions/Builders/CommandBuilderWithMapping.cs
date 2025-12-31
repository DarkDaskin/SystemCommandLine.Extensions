using System.CommandLine;
using System.Linq.Expressions;

namespace SystemCommandLine.Extensions.Builders;

internal class CommandBuilderWithMapping<TCommand, TOptionHolder>(ICommandBuilder<TCommand> commandBuilder, TCommand command, SymbolMapperRegistration mapperRegistration) : 
    ICommandBuilderWithMapping<TCommand, TOptionHolder> where TCommand : Command, IUseCommandBuilder<TCommand>
    where TOptionHolder : class
{
    public ICommandArgumentBuilderWithMapping<TCommand, TOptionHolder, TOption> NewArgument<TOption>(Expression<Func<TOptionHolder, TOption>> propertyExpression)
    {
        return new CommandArgumentBuilderWithMapping<TCommand, TOptionHolder, TOption>(command, this, propertyExpression, mapperRegistration);
    }

    public ICommandOptionBuilderWithMapping<TCommand, TOptionHolder, TOption> NewOption<TOption>(Expression<Func<TOptionHolder, TOption>> propertyExpression)
    {
        return new CommandOptionBuilderWithMapping<TCommand, TOptionHolder, TOption>(command, this, propertyExpression, mapperRegistration);
    }

    public ICommandBuilder<TCommand> CommandBuilder() => commandBuilder;
}