namespace NetStructre;

public static class ActionConfig
{
    private static Dictionary<string, ActionDescriptor> _routingTable;

    static ActionConfig()
    {
        _routingTable = new Dictionary<string, ActionDescriptor>()
        {
            #region User

            {"SignIn", new ActionDescriptor(false, false, typeof(void), null)}        

            #endregion
        };
    }
    
    public static ActionDescriptor? GetActionConfig(string action)
    {
        return _routingTable.GetValueOrDefault(action);
    }
}