namespace SimpleLogging;

public static class LogFactory
{
    private const LogLevels DEFAULT_LOG_LEVEL = LogLevels.Debug;
    
    public static ILog GetLogger(Type sourceType, LogLevels logLevels = DEFAULT_LOG_LEVEL)
    {
        return new Log(sourceType, logLevels, Console.WriteLine);
    }
}