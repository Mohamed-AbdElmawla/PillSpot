import React from "react";
import { FaCheckCircle, FaTrash, FaRegBell, FaRegCheckCircle, FaRegTimesCircle, FaExclamationCircle, FaInfoCircle } from "react-icons/fa";
import dayjs from "dayjs";
import relativeTime from "dayjs/plugin/relativeTime";
import utc from "dayjs/plugin/utc";

dayjs.extend(relativeTime);
dayjs.extend(utc);


export type NotificationType = "info" | "success" | "warning" | "error";

interface OneNotifiyProps {
  title: string;
  content: string;
  read: boolean;
  time?: string;
  type?: NotificationType;
  avatarUrl?: string;
  onMarkAsRead?: () => void;
  onDelete?: () => void;
}

const typeIconMap = {
  info: FaInfoCircle,
  success: FaRegCheckCircle,
  warning: FaExclamationCircle,
  error: FaRegTimesCircle,
};

const typeColorMap = {
  info: "text-blue-500",
  success: "text-green-500",
  warning: "text-yellow-500",
  error: "text-red-500",
};

const OneNotifiy: React.FC<OneNotifiyProps> = ({
  title,
  content,
  read,
  time,
  type = "info",
  avatarUrl,
  onMarkAsRead,
  onDelete,
}) => {
  const Icon = typeIconMap[type] || FaRegBell;
  const iconColor = typeColorMap[type] || "text-blue-500";

  
  return (
    <div
      className={`
        group relative mb-4 p-4 bg-white rounded-2xl shadow-md border border-gray-100
        transition-all duration-200 hover:shadow-lg hover:-translate-y-1 hover:bg-blue-50
        flex flex-col gap-2 focus-within:ring-2 focus-within:ring-blue-200
      `}
      tabIndex={0}
      role="region"
      aria-label={title}
    >
      {/* Header */}
      <div className="flex items-center justify-between gap-2">
        <div className="flex items-center gap-2 min-w-0">
          {avatarUrl ? (
            <img
              src={avatarUrl}
              alt="avatar"
              className="w-8 h-8 rounded-full object-cover border border-gray-200 shadow-sm"
            />
          ) : (
            <Icon className={`text-lg shrink-0 ${iconColor} ${read ? "opacity-60" : ""}`} />
          )}
          <span className={`font-semibold text-base truncate ${read ? "text-gray-600" : "text-blue-800"}`}>
            {title}
          </span>
        </div>

        {time && (
          <span className="text-xs text-gray-400 ml-2 shrink-0">
            {dayjs.utc(time).add(3, 'hour').isValid() ? dayjs.utc(time).add(3, 'hour').fromNow(true) + " ago" : "erro calc time"}
          </span>
        )}
      </div>
      {/* Content */}
      <div className="text-sm text-gray-700 mt-1 break-words">{content}</div>
      {/* Actions */}
      <div className="flex justify-end gap-2 mt-2 opacity-0 group-hover:opacity-100 focus-within:opacity-100 transition-opacity duration-200">
        {!read && onMarkAsRead && (
          <button
            className="flex items-center gap-1 px-3 py-1 rounded-full bg-blue-100 text-blue-700 text-xs font-semibold hover:bg-blue-200 hover:text-blue-900 transition focus:outline-none focus:ring-2 focus:ring-blue-300"
            onClick={e => { e.stopPropagation(); onMarkAsRead(); }}
            tabIndex={0}
            aria-label="Mark as Read"
          >
            <FaCheckCircle className="text-blue-500" /> Mark as Read
          </button>
        )}
        {onDelete && (
          <button
            className="flex items-center gap-1 px-3 py-1 rounded-full bg-red-100 text-red-600 text-xs font-semibold hover:bg-red-200 hover:text-red-800 transition focus:outline-none focus:ring-2 focus:ring-red-300"
            onClick={e => { e.stopPropagation(); onDelete(); }}
            tabIndex={0}
            aria-label="Delete notification"
          >
            <FaTrash className="text-red-500" /> Delete
          </button>
        )}
      </div>
    </div>
  );
};

export default OneNotifiy;
