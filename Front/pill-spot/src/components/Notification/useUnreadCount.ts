import { useState, useEffect, useCallback } from "react";
import { useDispatch } from "react-redux";
import { getUnreadNotificationCountThunk } from "../../features/Notifications/notificationSlice";
import { subscribeToNotificationEvents, unsubscribeFromNotificationEvents, startConnection } from "../../features/NotificationHubService";
import { AppDispatch } from "../../app/store";

const useUnreadCount = () => {
  const [unreadCount, setUnreadCount] = useState(0);
  const dispatch = useDispatch<AppDispatch>();

  const fetchUnreadCount = useCallback(() => {
    dispatch(getUnreadNotificationCountThunk()).then((action) => {
      if (action && typeof action.payload === 'number') {
        setUnreadCount(action.payload);
      }
    });
  }, [dispatch]);

  useEffect(() => {
    let isMounted = true;
    // Fetch once on mount as fallback
    fetchUnreadCount();
    // Setup SignalR for real-time unread count
    startConnection().then((conn) => {
      if (!isMounted || !conn) return;
      subscribeToNotificationEvents(
        () => {
          // When a notification is received, fetch the unread count
          fetchUnreadCount();
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
  }, [fetchUnreadCount]);

  // Expose fetchUnreadCount for use in other hooks/components
  return { unreadCount, setUnreadCount, fetchUnreadCount };
};

export default useUnreadCount; 