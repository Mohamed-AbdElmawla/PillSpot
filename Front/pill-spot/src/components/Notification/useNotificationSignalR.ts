import { useEffect } from "react";
import { startConnection, subscribeToNotificationEvents, unsubscribeFromNotificationEvents } from "../../features/NotificationHubService";
import { useDispatch } from "react-redux";
import { addNotification } from "../../features/Notifications/notificationSlice";

const useNotificationSignalR = (setUnreadCount: (count: number) => void) => {
  const dispatch = useDispatch();
  useEffect(() => {
    let isMounted = true;
    startConnection().then((conn) => {
      if (!isMounted) return;
      if (!conn) return;
      subscribeToNotificationEvents(
        (notification) => {
          dispatch(addNotification(notification));
        },
        (count) => {
          setUnreadCount(count);
        }
      );
    });
    return () => {
      isMounted = false;
      unsubscribeFromNotificationEvents();
    };
  }, [dispatch, setUnreadCount]);
};

export default useNotificationSignalR; 