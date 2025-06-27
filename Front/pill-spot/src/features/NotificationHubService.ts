import { HubConnectionBuilder, HubConnection, LogLevel } from "@microsoft/signalr";

const hubUrl = "https://localhost:7298/hubs/notifications";

let connection: HubConnection | null = null;

export const startConnection = async () => {
  if (!connection) {
    connection = new HubConnectionBuilder()
      .withUrl(hubUrl, {
        // If you need to send access tokens, add an accessTokenFactory here
        // accessTokenFactory: () => "your-jwt-token"
      })
      .withAutomaticReconnect()
      .configureLogging(LogLevel.Information)
      .build();

    connection.onclose(error => {
      console.error("SignalR connection closed:", error);
    });

    try {
      await connection.start();
      console.log("[SignalR] Connected to hub at", hubUrl);
    } catch (err) {
      console.error("SignalR Connection Error: ", err);
    }
  }
  return connection;
};

export const getConnection = () => connection;

export const subscribeToNotificationEvents = (
  onNewNotification: (notification: unknown) => void,
  onUnreadCount: (count: number) => void
) => {
  const conn = getConnection();
  if (conn) {
    conn.on("ReceiveNotification", onNewNotification);
    conn.on("UnreadCountUpdated", onUnreadCount);
    conn.on("receiveunreadcount", onUnreadCount);
    conn.on("allnotificationsread", () => {
      console.log("[SignalR] Received allnotificationsread event.");
    });
    console.log("[SignalR] Subscribed to ReceiveNotification, UnreadCountUpdated, receiveunreadcount, and allnotificationsread events.");
  }
};

export const unsubscribeFromNotificationEvents = () => {
  const conn = getConnection();
  if (conn) {
    conn.off("ReceiveNotification");
    conn.off("UnreadCountUpdated");
    conn.off("receiveunreadcount");
    conn.off("allnotificationsread");
    console.log("[SignalR] Unsubscribed from ReceiveNotification, UnreadCountUpdated, receiveunreadcount, and allnotificationsread events.");
  }
};
