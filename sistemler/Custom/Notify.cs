using GTANetworkAPI;
using System.Web;

public enum NotifyType
{
    success,
    error,
    info
}
public enum NotifyPosition
{
    Top,
    TopLeft,
    TopCenter,
    TopRight,
    Center,
    CenterLeft,
    CenterRight,
    Bottom,
    BottomLeft,
    BottomCenter,
    BottomRight
}
public static class Notify
{
    public static void Send(Player client, string type, string msg, int time)
    {
        string encodedMessage = HttpUtility.HtmlEncode(msg);
        NAPI.ClientEvent.TriggerClientEvent(client, "notify", type, encodedMessage, time);
    }
}

