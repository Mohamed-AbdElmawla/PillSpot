import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '../../../app/store';
import {
  getNotifications,
  markNotificationAsReadThunk,
  deleteNotificationThunk,
  getUnreadNotificationCountThunk,
} from '../../../features/Notifications/notificationSlice';
import { IoNotificationsOutline } from 'react-icons/io5';
import { FaCheckCircle, FaTrash } from 'react-icons/fa';

const UserNotifications = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { notifications, isLoading, unreadCount } = useSelector((state: RootState) => state.notifications);

  // Only get unread notifications
  useEffect(() => {
    dispatch(getNotifications(false));
    dispatch(getUnreadNotificationCountThunk());
  }, [dispatch]);

  const handleMarkAsRead = (id: string) => {
    dispatch(markNotificationAsReadThunk(id)).then(() => {
      dispatch(getNotifications(false));
      dispatch(getUnreadNotificationCountThunk());
    });
  };

  // const handleMarkAllAsRead = () => {
  //   dispatch(markAllNotificationsAsReadThunk()).then(() => {
  //     dispatch(getNotifications(false));
  //     dispatch(getUnreadNotificationCountThunk());
  //   });
  // };

  const handleDelete = (id: string) => {
    dispatch(deleteNotificationThunk(id)).then(() => {
      dispatch(getNotifications(false));
      dispatch(getUnreadNotificationCountThunk());
    });
  };

  return (
    <div className="p-6 w-full">
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between mb-6 gap-4">
        <div className="flex items-center gap-3">
          <IoNotificationsOutline className="text-3xl text-blue-600" />
          <h2 className="text-2xl font-bold">Unread Notifications</h2>
          <span className="ml-2 px-3 py-1 rounded-full bg-blue-100 text-blue-700 text-sm font-semibold">
            {unreadCount} Unread
          </span>
        </div>
       
      </div>
      {isLoading ? (
        <div className="text-center text-gray-400 py-12">Loading...</div>
      ) : notifications.length === 0 ? (
        <div className="text-center text-gray-400 py-12">No unread notifications</div>
      ) : (
        <div className="grid gap-4 max-h-[calc(95vh-10rem)] overflow-y-auto">
          {notifications.map((notif) => (
            <div
              key={notif.notificationId}
              className="flex flex-col sm:flex-row items-start sm:items-center justify-between bg-white rounded-xl shadow border border-gray-100 p-5 hover:shadow-lg transition group"
            >
              <div className="flex items-center gap-4 flex-1 min-w-0">
                <IoNotificationsOutline className="text-2xl text-blue-500 shrink-0" />
                <div className="min-w-0">
                  <div className="font-semibold text-lg text-blue-900 truncate">{notif.title}</div>
                  <div className="text-gray-700 mt-1 break-words text-sm">{notif.message}</div>
                  <div className="text-xs text-gray-400 mt-1">{notif.createdDate ? new Date(notif.createdDate).toLocaleString() : ''}</div>
                </div>
              </div>
              <div className="flex gap-2 mt-4 sm:mt-0">
                <button
                  className="flex items-center gap-1 px-4 py-2 rounded-lg bg-green-100 text-green-700 font-semibold hover:bg-green-200 transition text-xs"
                  onClick={() => handleMarkAsRead(notif.notificationId)}
                >
                  <FaCheckCircle /> Mark as Read
                </button>
                <button
                  className="flex items-center gap-1 px-4 py-2 rounded-lg bg-red-100 text-red-700 font-semibold hover:bg-red-200 transition text-xs"
                  onClick={() => handleDelete(notif.notificationId)}
                >
                  <FaTrash /> Delete
                </button>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default UserNotifications;
