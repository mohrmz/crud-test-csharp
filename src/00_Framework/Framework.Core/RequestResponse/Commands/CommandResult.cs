using Framework.Core.Common;

namespace Framework.Core.RequestResponse.Commands;

public class CommandResult : ApplicationServiceResult
{

}
public class CommandResult<TData> : CommandResult
{
    public TData? _data;
    public TData? Data => _data;
}


