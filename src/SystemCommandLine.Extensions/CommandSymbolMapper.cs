using System.CommandLine;

namespace SystemCommandLine.Extensions;

public delegate void SymbolMapper(ParseResult parseResult, object options);
public delegate void SymbolMapperRegistration(SymbolMapper mapper);

internal class CommandSymbolMapper<TCommand> : List<SymbolMapper> { }
