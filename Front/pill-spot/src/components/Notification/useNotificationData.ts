import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import {
  getNotifications,
  markNotificationAsReadThunk,
  deleteNotificationThunk,
  getUnreadNotificationCountThunk,
} from "../../features/Notifications/notificationSlice";

const useNotificationData = (fetchUnreadCount?: () => void) => {
  const [open, setOpen] = useState(false);
  const [activeTab, setActiveTab] = useState<'unread' | 'read'>('unread');
  const dispatch = useDispatch<AppDispatch>();
  const { notifications, isLoading } = useSelector((state: RootState) => state.notifications);

  useEffect(() => {
    if (open) {
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
    }
  }, [open, activeTab, dispatch]);

  const handleMarkAllAsRead = () => {
    const unreadNotifications = notifications.filter(n => !n.isRead);
    Promise.all(unreadNotifications.map(n => dispatch(markNotificationAsReadThunk(n.notificationId)))).then(() => {
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
      if (fetchUnreadCount) fetchUnreadCount();
      dispatch(getUnreadNotificationCountThunk());
    });
  };

  const handleMarkAsRead = (notificationId: string) => {
    dispatch(markNotificationAsReadThunk(notificationId)).then(() => {
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
      if (fetchUnreadCount) fetchUnreadCount();
      dispatch(getUnreadNotificationCountThunk());
    });
  };

  const handleDelete = (notificationId: string) => {
    dispatch(deleteNotificationThunk(notificationId)).then(() => {
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
      if (fetchUnreadCount) fetchUnreadCount();
      dispatch(getUnreadNotificationCountThunk());
    });
  };

  const sortedUnread = notifications
    .filter((n) => !n.isRead)
    .sort((a, b) => new Date(b.createdDate ?? '').getTime() - new Date(a.createdDate ?? '').getTime());
  const sortedRead = notifications
    .filter((n) => n.isRead)
    .sort((a, b) => new Date(b.createdDate ?? '').getTime() - new Date(a.createdDate ?? '').getTime());

  return {
    open,
    setOpen,
    activeTab,
    setActiveTab,
    isLoading,
    handleMarkAllAsRead,
    handleMarkAsRead,
    handleDelete,
    sortedUnread,
    sortedRead,
  };
};

export default useNotificationData; 