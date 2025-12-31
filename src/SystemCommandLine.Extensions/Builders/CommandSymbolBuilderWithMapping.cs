using System.CommandLine;
using System.Linq.Expressions;

namespace SystemCommandLine.Extensions.Builders;

internal abstract class CommandSymbolBuilderWithMapping<TOptionHolder, TOption>(Expression<Func<TOptionHolder, TOption>> propertyExpression, SymbolMapperRegistration mapperRegistration) where TOptionHolder : class
{
    protected void RegisterSymbolMapper(Symbol symbol)
    {
        Action<TOptionHolder, TOption?> symbolValueMapper = propertyExpression.CreateSymbolValueMapper();

        void symbolMapper(ParseResult parsedResult, object options)
        {
            symbolValueMapper((TOptionHolder)options, parsedResult.GetValue<TOption>(symbol.Name));
        }

        mapperRegistration(symbolMapper);
    }
}