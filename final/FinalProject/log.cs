using System;

public class Log
{
    private List<string> _log = new List<string>();

    public Log() { }

    public void UpdateLog(string input)
    {
        _log.Add(input);
    }

    public void ClearLog()
    {
        _log.Clear();
    }

    public void SaveLog()
    {
        // need to build system
    }


}