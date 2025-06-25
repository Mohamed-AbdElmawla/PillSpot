import { useState } from "react";
import { Drawer } from "antd";
import { IoNotificationsOutline } from "react-icons/io5";
import OneNotifiy, { NotificationType } from "./OneNotifiy/OneNotifiy";

interface Iprops {
  iconStyle?: string;
}

interface Notification {
  id: number;
  title: string;
  content: string;
  read: boolean;
  date: string; // ISO string
  type?: NotificationType;
  avatarUrl?: string;
}

const mockNotifications: Notification[] = [
  { id: 1, title: "Order Shipped", content: "Your order #1234 has been shipped.", read: false, date: "2024-06-10T15:30:00Z", type: "success" },
  { id: 2, title: "New Message", content: "You have a new message from the pharmacy.", read: false, date: "2024-06-11T09:00:00Z", type: "info" },
  { id: 3, title: "Discount Offer", content: "Get 20% off on your next purchase!", read: true, date: "2024-06-09T12:00:00Z", type: "info" },
  { id: 4, title: "Profile Updated", content: "Your profile information was updated.", read: true, date: "2024-06-08T18:45:00Z", type: "success" },
];

const NotificationDrawer = ({ iconStyle }: Iprops) => {
  const [open, setOpen] = useState(false);
  const [notifications, setNotifications] = useState<Notification[]>(mockNotifications);
  const [activeTab, setActiveTab] = useState<'unread' | 'read'>('unread');

  const showDrawer = () => {
    setOpen(true);
  };

  const onClose = () => {
    setOpen(false);
  };

  let iconColor = "text-3xl  text-[#ffffff] cursor-pointer hover:scale-105 duration-100";
  if (iconStyle) iconColor = iconStyle;

  const handleMarkAsRead = (id: number) => {
    setNotifications((prev) =>
      prev.map((notif) =>
        notif.id === id ? { ...notif, read: true } : notif
      )
    );
  };

  const handleDelete = (id: number) => {
    setNotifications((prev) => prev.filter((notif) => notif.id !== id));
  };

  const handleMarkAllAsRead = () => {
    setNotifications((prev) => prev.map((notif) => ({ ...notif, read: true })));
  };

  // Sort notifications by date (newest first)
  const sortedUnread = notifications
    .filter((n) => !n.read)
    .sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());
  const sortedRead = notifications
    .filter((n) => n.read)
    .sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());

  return (
    <>
      <button onClick={showDrawer} className={iconColor}>
        <IoNotificationsOutline />
      </button>
      <Drawer title="Notifications" onClose={onClose} open={open} className="rounded-tl-3xl rounded-bl-3xl">
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
          {activeTab === 'unread' && (
            sortedUnread.length === 0 ? (
              <div className="text-gray-400 text-center py-8">No unread notifications</div>
            ) : (
              sortedUnread.map((notif) => (
                <OneNotifiy
                  key={notif.id}
                  title={notif.title}
                  content={notif.content}
                  read={notif.read}
                  time={new Date(notif.date).toLocaleString()}
                  type={notif.type}
                  avatarUrl={notif.avatarUrl}
                  onMarkAsRead={notif.read ? undefined : () => handleMarkAsRead(notif.id)}
                  onDelete={() => handleDelete(notif.id)}
                />
              ))
            )
          )}
          {activeTab === 'read' && (
            sortedRead.length === 0 ? (
              <div className="text-gray-400 text-center py-8">No read notifications</div>
            ) : (
              sortedRead.map((notif) => (
                <OneNotifiy
                  key={notif.id}
                  title={notif.title}
                  content={notif.content}
                  read={notif.read}
                  time={new Date(notif.date).toLocaleString()}
                  type={notif.type}
                  avatarUrl={notif.avatarUrl}
                  onMarkAsRead={undefined}
                  onDelete={() => handleDelete(notif.id)}
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
