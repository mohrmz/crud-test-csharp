using System.Data;
using System.Data.Common;

namespace Framework.Infrastructures.Data.Commands.Extensions;

public static class DbCommandExtension
{
    public static void ApplyCorrect(this DbCommand command)
    {
        command.CommandText = command.CommandText;

        foreach (DbParameter parameter in command.Parameters)
        {
            switch (parameter.DbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.Xml:
                    parameter.Value = parameter.Value is DBNull ? parameter.Value : parameter.Value;
                    break;
            }
        }
    }
}
