import { Drawer } from "antd";
import { IoNotificationsOutline } from "react-icons/io5";
import OneNotifiy, { NotificationType } from "./OneNotifiy/OneNotifiy";
import useNotificationSignalR from "./useNotificationSignalR";
import useNotificationData from "./useNotificationData";
import type { Notification } from "../../features/Notifications/notificationSlice";
import { useSelector, useDispatch } from "react-redux";
import { RootState } from "../../app/store";
import { getUnreadNotificationCountThunk } from "../../features/Notifications/notificationSlice";
import { useEffect } from "react";
import type { AppDispatch } from "../../app/store";

interface Iprops {
  iconStyle?: string;
}

const NotificationDrawer = ({ iconStyle }: Iprops) => {
  const unreadCount = useSelector((state: RootState) => state.notifications.unreadCount);
  const dispatch = useDispatch<AppDispatch>();
  const { open, setOpen, activeTab, setActiveTab, isLoading, handleMarkAllAsRead, handleMarkAsRead, handleDelete, sortedUnread, sortedRead } = useNotificationData(() => {});
  useNotificationSignalR(() => {});

  useEffect(() => {
    dispatch(getUnreadNotificationCountThunk());
  }, [dispatch]);

  let iconColor = "text-3xl  text-[#ffffff] cursor-pointer hover:scale-105 duration-100";
  if (iconStyle) iconColor = iconStyle;

  return (
    <>
      <button onClick={() => setOpen(true)} className={iconColor} style={{ position: 'relative' }}>
        <IoNotificationsOutline />
        <span
          className="absolute -top-1 -right-1 bg-red-500 text-white rounded-full text-xs min-w-[1.25em] h-[1.25em] flex items-center justify-center px-1 font-bold z-10 border-2 border-white shadow"
        >
          {unreadCount}
        </span>
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
            <span className="ml-2 inline-block min-w-[1.5em] px-2 py-0.5 rounded-full bg-blue-500 text-white text-xs font-bold align-middle">
              {unreadCount}
            </span>
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
              sortedUnread.map((notif: Notification) => (
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
              sortedRead.map((notif: Notification) => (
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
