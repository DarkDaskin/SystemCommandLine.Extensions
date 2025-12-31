using System.CommandLine;

namespace SystemCommandLine.Extensions;

public interface ICommandBuilder<TCommand> where TCommand : Command, IUseCommandBuilder<TCommand>
{
    ICommandArgumentBuilder<TCommand, TOption> NewArgument<TOption>(string name);
    ICommandOptionBuilder<TCommand, TOption> NewOption<TOption>(string name);
    ICommandBuilderWithMapping<TCommand, TOptionHolder> WithMapping<TOptionHolder>(SymbolMapperRegistration mapperRegistration) where TOptionHolder : class;
}