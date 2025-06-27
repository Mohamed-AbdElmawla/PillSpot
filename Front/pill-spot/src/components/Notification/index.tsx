import { useState, useEffect } from "react";
import { Drawer } from "antd";
import { IoNotificationsOutline } from "react-icons/io5";
import OneNotifiy, { NotificationType } from "./OneNotifiy/OneNotifiy";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import {
  getNotifications,
  markNotificationAsReadThunk,
  deleteNotificationThunk,
  markAllNotificationsAsReadThunk,
  getUnreadNotificationCountThunk,
} from "../../features/Notifications/notificationSlice";

interface Iprops {
  iconStyle?: string;
}

const NotificationDrawer = ({ iconStyle }: Iprops) => {
  const [open, setOpen] = useState(false);
  const [activeTab, setActiveTab] = useState<'unread' | 'read'>('unread');
  const [unreadCount, setUnreadCount] = useState<number>(0);
  const dispatch = useDispatch<AppDispatch>();
  const { notifications, isLoading } = useSelector((state: RootState) => state.notifications);

  // Fetch unread count when drawer opens or after actions
  const fetchUnreadCount = () => {
    dispatch(getUnreadNotificationCountThunk()).then((action: unknown) => {
      if (typeof action === 'object' && action !== null && 'payload' in action) {
        const payload = (action as { payload?: unknown }).payload;
        if (typeof payload === 'number') {
          setUnreadCount(payload);
        }
      }
    });
  };

  useEffect(() => {
    if (open) {
      // Fetch notifications for the current tab when drawer opens
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
      fetchUnreadCount();
    }
  }, [open, activeTab, dispatch]);

  // Mark all as read
  const handleMarkAllAsRead = () => {
    dispatch(markAllNotificationsAsReadThunk()).then(() => {
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
      fetchUnreadCount();
    });
  };

  // Mark one as read
  const handleMarkAsRead = (notificationId: string) => {
    dispatch(markNotificationAsReadThunk(notificationId)).then(() => {
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
      fetchUnreadCount();
    });
  };

  // Delete one
  const handleDelete = (notificationId: string) => {
    dispatch(deleteNotificationThunk(notificationId)).then(() => {
      if (activeTab === 'unread') {
        dispatch(getNotifications(false));
      } else {
        dispatch(getNotifications(true));
      }
      fetchUnreadCount();
    });
  };

  // Tabs logic
  const sortedUnread = notifications
    .filter((n) => !n.isRead)
    .sort((a, b) => new Date(b.createdDate ?? '').getTime() - new Date(a.createdDate ?? '').getTime());
  const sortedRead = notifications
    .filter((n) => n.isRead)
    .sort((a, b) => new Date(b.createdDate ?? '').getTime() - new Date(a.createdDate ?? '').getTime());

  let iconColor = "text-3xl  text-[#ffffff] cursor-pointer hover:scale-105 duration-100";
  if (iconStyle) iconColor = iconStyle;

  return (
    <>
      <button onClick={() => setOpen(true)} className={iconColor} style={{ position: 'relative' }}>
        <IoNotificationsOutline />
        {unreadCount > 0 && (
          <span
            className="absolute -top-1 -right-1 bg-red-500 text-white rounded-full text-xs min-w-[1.25em] h-[1.25em] flex items-center justify-center px-1 font-bold z-10 border-2 border-white shadow"
          >
            {unreadCount}
          </span>
        )}
      </button>
      <Drawer title="Notifications" onClose={() => setOpen(false)} open={open} className="rounded-tl-3xl rounded-bl-3xl">
        {/* Top actions */}
        <div className="flex items-center justify-between mb-2">
          <span className="font-bold text-lg">Notifications</span>
          <button
            className="px-3 py-1 rounded-full bg-blue-100 text-blue-700 text-xs font-semibold hover:bg-blue-200 hover:text-blue-900 transition"
            onClick={handleMarkAllAsRead}
            disabled={sortedUnread.length === 0}
          >
            Mark All as Read
          </button>
        </div>
        {/* Tabs */}
        <div className="flex border-b mb-4">
          <button
            className={`flex-1 py-2 font-semibold text-lg border-b-2 transition-colors duration-200 relative ${activeTab === 'unread' ? 'border-blue-500 text-blue-600 bg-white' : 'border-transparent text-gray-500 bg-transparent'}`}
            onClick={() => setActiveTab('unread')}
          >
            Unread
            {sortedUnread.length > 0 && (
              <span className="ml-2 inline-block min-w-[1.5em] px-2 py-0.5 rounded-full bg-blue-500 text-white text-xs font-bold align-middle">
                {sortedUnread.length}
              </span>
            )}
          </button>
          <button
            className={`flex-1 py-2 font-semibold text-lg border-b-2 transition-colors duration-200 ${activeTab === 'read' ? 'border-blue-500 text-blue-600 bg-white' : 'border-transparent text-gray-500 bg-transparent'}`}
            onClick={() => setActiveTab('read')}
          >
            Read
          </button>
        </div>
        <div>
          {isLoading ? (
            <div className="text-gray-400 text-center py-8">Loading...</div>
          ) : activeTab === 'unread' ? (
            sortedUnread.length === 0 ? (
              <div className="text-gray-400 text-center py-8">No unread notifications</div>
            ) : (
              sortedUnread.map((notif) => (
                <OneNotifiy
                  key={notif.notificationId}
                  title={notif.title}
                  content={notif.message}
                  read={notif.isRead}
                  time={notif.createdDate ? new Date(notif.createdDate).toLocaleString() : ''}
                  type={notif.type as NotificationType}
                  avatarUrl={notif.avatarUrl}
                  onMarkAsRead={notif.isRead ? undefined : () => handleMarkAsRead(notif.notificationId)}
                  onDelete={() => handleDelete(notif.notificationId)}
                />
              ))
            )
          ) : (
            sortedRead.length === 0 ? (
              <div className="text-gray-400 text-center py-8">No read notifications</div>
            ) : (
              sortedRead.map((notif) => (
                <OneNotifiy
                  key={notif.notificationId}
                  title={notif.title}
                  content={notif.message}
                  read={notif.isRead}
                  time={notif.createdDate ? new Date(notif.createdDate).toLocaleString() : ''}
                  type={notif.type as NotificationType}
                  avatarUrl={notif.avatarUrl}
                  onMarkAsRead={undefined}
                  onDelete={() => handleDelete(notif.notificationId)}
                />
              ))
            )
          )}
        </div>
      </Drawer>
    </>
  );
};

export default NotificationDrawer;
