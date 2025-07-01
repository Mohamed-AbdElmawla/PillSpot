import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../../../app/store";
import { NotificationPreference, updateProductNotificationPreferenceThunk } from "../../../features/Notifications/notificationSlice";
import { MdNotificationsActive } from "react-icons/md";

const NOTIFICATION_TYPE_OPTIONS = [
  "General",
  "PrescriptionExpiry",
  "PaymentConfirmation",
  "DeliveryStatus",
  "PriceChange",
  "Promotion",
  "ProductInfo",
  "GroupedProductInfo",
  "GroupedNotification",
  "StockAlert",
  "PriceDrop",
  "NewReview",
  "SideEffect",
  "Alternative",
  "Recall",
  "Restock",
  "Discount",
  "CartItemAdded",
  "CartItemRemoved",
  "CartItemQuantityUpdated",
  "CartItemApprovalStatusUpdated",
  "CartItemApprovalStatusRejected",
  "CartItemApprovalStatusApproved",
  "CartItemApprovalStatusPending",
  "CartItemApprovalStatusCancelled",
  "CartItemApprovalStatusExpired",
  "OrderCreated",
  "NewOrder",
  "RequestUpdate"
];

interface EditPreferenceModalProps {
  open: boolean;
  onClose: () => void;
  pref: NotificationPreference | null;
}

const EditPreferenceModal: React.FC<EditPreferenceModalProps> = ({ open, onClose, pref }) => {
  const dispatch = useDispatch<AppDispatch>();
  const [isEnabled, setIsEnabled] = useState(true);
  const [notificationTypes, setNotificationTypes] = useState<string[]>([]);
  const [selectedType, setSelectedType] = useState("");
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (pref) {
      setIsEnabled(pref.isEnabled);
      setNotificationTypes(pref.notificationTypes);
    }
  }, [pref]);

  const handleAddType = () => {
    if (selectedType && !notificationTypes.includes(selectedType)) {
      setNotificationTypes([...notificationTypes, selectedType]);
      setSelectedType("");
    }
  };

  const handleRemoveType = (type: string) => {
    setNotificationTypes(notificationTypes.filter(t => t !== type));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!pref) return;
    setLoading(true);
    await dispatch(updateProductNotificationPreferenceThunk({
      productId: pref.productId,
      body: { isEnabled, notificationTypes }
    }));
    setLoading(false);
    onClose();
  };

  if (!open || !pref) return null;

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/30">
      <div className="bg-white rounded-xl shadow-lg p-6 w-full max-w-sm relative">
        <button className="absolute top-2 right-2 text-gray-400 hover:text-gray-700" onClick={onClose}>&times;</button>
        <h3 className="text-lg font-bold mb-1 text-[#02457a]">Edit Preference</h3>
        <div className="text-sm text-[#49708f] font-semibold mb-4 truncate">{pref.productName}</div>
        <form onSubmit={handleSubmit} className="flex flex-col gap-4">
          <div>
            <label className="font-semibold">Enabled:</label>
            <div className="mt-1 flex items-center gap-3">
              <button
                type="button"
                className={`px-3 py-1 rounded-full font-semibold ${isEnabled ? 'bg-green-100 text-green-700' : 'bg-gray-100 text-gray-500'}`}
                onClick={() => setIsEnabled(true)}
              >Yes</button>
              <button
                type="button"
                className={`px-3 py-1 rounded-full font-semibold ${!isEnabled ? 'bg-red-100 text-red-700' : 'bg-gray-100 text-gray-500'}`}
                onClick={() => setIsEnabled(false)}
              >No</button>
            </div>
          </div>
          <div>
            <label className="font-semibold">Notification Types:</label>
            <div className="flex flex-wrap gap-2 mt-1">
              {notificationTypes.map((type, idx) => (
                <span key={idx} className="inline-flex items-center gap-1 bg-blue-100 text-blue-800 px-2 py-0.5 rounded-full text-xs font-semibold">
                  <MdNotificationsActive className="w-4 h-4" /> {type}
                  <button type="button" className="ml-1 text-red-500 hover:text-red-700" onClick={() => handleRemoveType(type)}>&times;</button>
                </span>
              ))}
            </div>
            <div className="flex gap-2 mt-2 items-center">
              <select
                className="border rounded px-2 py-1 flex-1 text-sm"
                value={selectedType}
                onChange={e => setSelectedType(e.target.value)}
              >
                <option value="">Select type...</option>
                {NOTIFICATION_TYPE_OPTIONS.filter(opt => !notificationTypes.includes(opt)).map(opt => (
                  <option key={opt} value={opt}>{opt}</option>
                ))}
              </select>
              <button type="button" className="bg-blue-500 text-white px-3 py-1 rounded" onClick={handleAddType} disabled={!selectedType}>Add</button>
            </div>
          </div>
          <button type="submit" className="bg-[#02457a] text-white px-4 py-2 rounded font-semibold mt-2 disabled:opacity-60" disabled={loading}>
            {loading ? 'Saving...' : 'Save'}
          </button>
        </form>
      </div>
    </div>
  );
};

export default EditPreferenceModal; 