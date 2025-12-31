using System.CommandLine;
using System.Linq.Expressions;

namespace SystemCommandLine.Extensions.Builders;

internal class CommandOptionBuilderWithMapping<TCommand, TOptionHolder, TOption>(
    TCommand command, ICommandBuilderWithMapping<TCommand, TOptionHolder> commandHandlerBuilder, Expression<Func<TOptionHolder, TOption>> propertyExpression, SymbolMapperRegistration mapperRegistration) : 
    CommandSymbolBuilderWithMapping<TOptionHolder, TOption>(propertyExpression, mapperRegistration),
    ICommandOptionBuilderWithMapping<TCommand, TOptionHolder, TOption> where TCommand : Command, IUseCommandBuilder<TCommand>
    where TOptionHolder : class
{
    private readonly Option<TOption> option = new(NameFormatExtensions.ToKebabCase("--", propertyExpression.GetPropertyName()));

    public ICommandOptionBuilderWithMapping<TCommand, TOptionHolder, TOption> Configure(Action<Option<TOption>> value)
    {
        value.Invoke(option);
        return this;
    }

    public ICommandBuilderWithMapping<TCommand, TOptionHolder> AddToCommand()
    {
        command.Add(option);

        RegisterSymbolMapper(option);

        return commandHandlerBuilder;
    }
}