import { useEffect } from "react";
import { startConnection, subscribeToNotificationEvents, unsubscribeFromNotificationEvents } from "../../features/NotificationHubService";
import { useDispatch } from "react-redux";
import { addNotification, getUnreadNotificationCountThunk } from "../../features/Notifications/notificationSlice";
import { AppDispatch } from "../../app/store";

const useNotificationSignalR = (setUnreadCount: (count: number) => void) => {
  const dispatch = useDispatch<AppDispatch>();
  useEffect(() => {
    let isMounted = true;
    startConnection().then((conn) => {
      if (!isMounted) return;
      if (!conn) return;
      subscribeToNotificationEvents(
        (notification) => {
          dispatch(addNotification(notification));
          dispatch(getUnreadNotificationCountThunk());
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