namespace SimpleLogging;

public class Log : ILog
{
    private static readonly LogLevels[] LogLevels = (LogLevels[])Enum.GetValues(typeof(LogLevels));
    private readonly Type _sourceType;
    private readonly Dictionary<LogLevels, bool> _logLevelMap;
    private readonly Action<string> _logFunction;


    public Log(Type sourceType, LogLevels logLevel, Action<string> logFunction)
    {
        _sourceType = sourceType;
        _logFunction = logFunction;
        _logLevelMap = new Dictionary<LogLevels, bool>();

        PopulateMap(logLevel);
    }

    private void PopulateMap(LogLevels logLevel)
    {
        for (int index = 0; index < LogLevels.Length; index++)
        {
            if (index >= (int)logLevel)
            {
                _logLevelMap[LogLevels[index]] = true;
            }
            else
            {
                _logLevelMap[LogLevels[index]] = false;
            }
        }
    }

    private string GetOutputMessage(string message)
    {
        string msg = $"[{_sourceType}]: {message}";
        return msg;
    }

    public void Debug(string message)
    {
        if (_logLevelMap[SimpleLogging.LogLevels.Debug])
        {
            _logFunction(GetOutputMessage(message));
        }
    }

    public void LogInformation(string message)
    {
        if (_logLevelMap[SimpleLogging.LogLevels.Information])
        {
            _logFunction(GetOutputMessage(message));
        }
    }

    public void LogWarning(string message)
    {
        if (_logLevelMap[SimpleLogging.LogLevels.Warning])
        {
            _logFunction(GetOutputMessage(message));
        }
    }

    public void LogError(string message)
    {
        if (_logLevelMap[SimpleLogging.LogLevels.Error])
        {
            _logFunction(GetOutputMessage(message));
        }
    }
}