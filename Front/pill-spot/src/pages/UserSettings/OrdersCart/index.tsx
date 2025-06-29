// import CheckOutComp from "./CheckOut";
// import OrdersRows from "./OrdersTable";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../../app/store";
import { getAllNotificationPreferencesThunk, NotificationPreference, deleteProductNotificationPreferenceThunk } from "../../../features/Notifications/notificationSlice";
import { HiCheckCircle, HiXCircle } from 'react-icons/hi';
import { MdNotificationsActive, MdEdit, MdDelete } from 'react-icons/md';
import EditPreferenceModal from './EditPreferenceModal';
// import img from "../MainPage/images/image copy 5.png"

const NotificationPreferencesTable = () => {
  const dispatch = useDispatch<AppDispatch>();
  const preferences = useSelector((state: RootState) => state.notifications.preferences);
  const isLoading = useSelector((state: RootState) => state.notifications.isLoading);
  const isError = useSelector((state: RootState) => state.notifications.isError);
  const errorMessage = useSelector((state: RootState) => state.notifications.errorMessage);

  const [editPref, setEditPref] = useState<NotificationPreference | null>(null);
  const [modalOpen, setModalOpen] = useState(false);
  const [deletingId, setDeletingId] = useState<string | null>(null);

  useEffect(() => {
    dispatch(getAllNotificationPreferencesThunk());
  }, [dispatch]);

  const handleEdit = (pref: NotificationPreference) => {
    setEditPref(pref);
    setModalOpen(true);
  };
  const handleCloseModal = () => {
    setModalOpen(false);
    setEditPref(null);
    dispatch(getAllNotificationPreferencesThunk());
  };
  const handleDelete = async (productId: string) => {
    setDeletingId(productId);
    await dispatch(deleteProductNotificationPreferenceThunk(productId));
    setDeletingId(null);
    dispatch(getAllNotificationPreferencesThunk());
  };

  return (
    <div className="mb-8 w-full overflow-x-auto">
      <h2 className="text-2xl font-bold mb-6 text-[#02457a]">Notification Preferences</h2>
      <EditPreferenceModal open={modalOpen} onClose={handleCloseModal} pref={editPref} />
      {isLoading && <div>Loading...</div>}
      {isError && <div className="text-red-600">{errorMessage}</div>}
      {!isLoading && !isError && (
        <div className="rounded-2xl shadow-lg bg-white overflow-hidden">
          <div className="overflow-x-auto">
            <table className="min-w-full">
              <thead>
                <tr className="bg-gradient-to-r from-[#e3eaf6] to-[#f7f9fb] text-[#02457a] sticky top-0 z-10">
                  <th className="py-3 px-4 text-left font-semibold text-base">Product</th>
                  <th className="py-3 px-4 text-left font-semibold text-base">Enabled</th>
                  <th className="py-3 px-4 text-left font-semibold text-base">Types</th>
                  <th className="py-3 px-4 text-left font-semibold text-base">Created</th>
                  <th className="py-3 px-4 text-left font-semibold text-base">Last Notified</th>
                  <th className="py-3 px-4 text-left font-semibold text-base">Edit</th>
                  <th className="py-3 px-4 text-left font-semibold text-base">Delete</th>
                </tr>
              </thead>
              <tbody>
                {preferences.length === 0 ? (
                  <tr><td colSpan={7} className="text-center py-6 text-gray-500">No preferences found.</td></tr>
                ) : (
                  preferences.map((pref: NotificationPreference) => (
                    <tr
                      key={pref.preferenceId}
                      className="transition hover:bg-blue-50/60 group"
                    >
                      <td className="py-3 px-4 flex items-center gap-2 font-medium">
                        <span className="truncate max-w-[160px]">{pref.productName}</span>
                        {pref.pharmacyName && (
                          <span className="ml-2 text-xs bg-blue-100 text-blue-800 px-2 py-0.5 rounded-full">{pref.pharmacyName}</span>
                        )}
                      </td>
                      <td className="py-3 px-4">
                        {pref.isEnabled ? (
                          <span className="inline-flex items-center gap-1 text-green-600 font-semibold"><HiCheckCircle className="inline w-5 h-5" /> Yes</span>
                        ) : (
                          <span className="inline-flex items-center gap-1 text-red-500 font-semibold"><HiXCircle className="inline w-5 h-5" /> No</span>
                        )}
                      </td>
                      <td className="py-3 px-4">
                        <div className="flex flex-wrap gap-1">
                          {pref.notificationTypes.map((type, idx) => (
                            <span key={idx} className="inline-flex items-center gap-1 bg-blue-100 text-blue-800 px-2 py-0.5 rounded-full text-xs font-semibold">
                              <MdNotificationsActive className="w-4 h-4" /> {type}
                            </span>
                          ))}
                        </div>
                      </td>
                      <td className="py-3 px-4 text-sm text-gray-700 whitespace-nowrap">{new Date(pref.createdAt).toLocaleString()}</td>
                      <td className="py-3 px-4 text-sm text-gray-700 whitespace-nowrap">{pref.lastNotifiedAt ? new Date(pref.lastNotifiedAt).toLocaleString() : <span className="text-gray-400">-</span>}</td>
                      <td className="py-3 px-4">
                        <button className="bg-blue-100 hover:bg-blue-200 text-blue-800 rounded-full p-2 transition" onClick={() => handleEdit(pref)} title="Edit">
                          <MdEdit className="w-5 h-5" />
                        </button>
                      </td>
                      <td className="py-3 px-4">
                        <button
                          className="bg-red-100 hover:bg-red-200 text-red-700 rounded-full p-2 transition disabled:opacity-50"
                          onClick={() => handleDelete(pref.productId)}
                          disabled={deletingId === pref.productId}
                          title="Delete"
                        >
                          {deletingId === pref.productId ? (
                            <svg className="animate-spin w-5 h-5" fill="none" viewBox="0 0 24 24"><circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle><path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v8z"></path></svg>
                          ) : (
                            <MdDelete className="w-5 h-5" />
                          )}
                        </button>
                      </td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        </div>
      )}
    </div>
  );
};

const ProducPreference = () => {
  return (
    <div className="mt-0 flex flex-col gap-6 w-full px-4 lg:px-8 h-[89vh] rounded-2xl">
      <div className="w-full">
        <NotificationPreferencesTable />
      </div>
    </div>
  );
};

export default ProducPreference;
