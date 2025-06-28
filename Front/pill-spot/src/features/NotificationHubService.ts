import { HubConnectionBuilder, HubConnection, LogLevel } from "@microsoft/signalr";
import type { Notification } from "./Notifications/notificationSlice";

declare global {
  interface Window {
    signalRConnection?: HubConnection;
  }
}

const hubUrl = "https://localhost:7298/hubs/notifications";

let connection: HubConnection | null = null;

export const startConnection = async () => {
  console.log("[SignalR] Starting connection...");
  if (!connection) {
    console.log("[SignalR] Creating new connection...");
    connection = new HubConnectionBuilder()
      .withUrl(hubUrl, {
        // If you need to send access tokens, add an accessTokenFactory here
        // accessTokenFactory: () => "your-jwt-token"
      })
      .withAutomaticReconnect()
      .configureLogging(LogLevel.Information)
      .build();

    connection.onclose(error => {
      console.error("[SignalR] Connection closed:", error);
    });

    try {
      console.log("[SignalR] Attempting to start connection...");
      await connection.start();
      console.log("[SignalR] Connected to hub at", hubUrl);
      // Make connection available globally for debugging
      (window).signalRConnection = connection;
    } catch (err) {
      console.error("[SignalR] Connection Error: ", err);
      connection = null;
    }
  } else {
    console.log("[SignalR] Connection already exists");
  }
  return connection;
};

export const getConnection = () => connection;

export const subscribeToNotificationEvents = (
  onNewNotification: (notification: Notification) => void,
  onUnreadCount: (count: number) => void
) => {
  const conn = getConnection();
  if (conn) {
    conn.on("ReceiveNotification", (notification: Notification) => {
      console.log("[SignalR] Received notification:", notification);
      onNewNotification(notification);
    });
    conn.on("UnreadCountUpdated", (count) => {
      console.log("[SignalR] Unread count updated:", count);
      onUnreadCount(count);
    });
    conn.on("receiveunreadcount", (count) => {
      console.log("[SignalR] receiveunreadcount event:", count);
      onUnreadCount(count);
    });
    conn.on("allnotificationsread", () => {
      console.log("[SignalR] Received allnotificationsread event.");
    });
    console.log("[SignalR] Subscribed to events.");
  } else {
    console.error("[SignalR] Connection not established when subscribing.");
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
