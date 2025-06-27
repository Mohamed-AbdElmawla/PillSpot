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
      console.log("SignalR Connected.");
    } catch (err) {
      console.error("SignalR Connection Error: ", err);
    }
  }
  return connection;
};

export const getConnection = () => connection;
