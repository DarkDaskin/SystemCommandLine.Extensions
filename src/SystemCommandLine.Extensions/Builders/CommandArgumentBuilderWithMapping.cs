using System.CommandLine;
using System.Linq.Expressions;

namespace SystemCommandLine.Extensions.Builders;

internal class CommandArgumentBuilderWithMapping<TCommand, TOptionHolder, TOption>(
    TCommand command, ICommandBuilderWithMapping<TCommand, TOptionHolder> commandHandlerBuilder, Expression<Func<TOptionHolder, TOption>> propertyExpression, SymbolMapperRegistration mapperRegistration) :
    CommandSymbolBuilderWithMapping<TOptionHolder, TOption>(propertyExpression, mapperRegistration),
    ICommandArgumentBuilderWithMapping<TCommand, TOptionHolder, TOption> where TCommand : Command, IUseCommandBuilder<TCommand>
    where TOptionHolder : class
{
    private readonly Argument<TOption> argument = new(NameFormatExtensions.ToKebabCase(propertyExpression.GetPropertyName()));

    public ICommandArgumentBuilderWithMapping<TCommand, TOptionHolder, TOption> Configure(Action<Argument<TOption>> value)
    {
        value.Invoke(argument);
        return this;
    }

    public ICommandBuilderWithMapping<TCommand, TOptionHolder> AddToCommand()
    {
        command.Add(argument);

        RegisterSymbolMapper(argument);

        return commandHandlerBuilder;
    }
}