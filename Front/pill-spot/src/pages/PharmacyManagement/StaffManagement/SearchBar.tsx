import { Dispatch, SetStateAction, useState } from "react";
import { BiSearchAlt } from "react-icons/bi";
import { IoMdAdd } from "react-icons/io";
import axios from "axios";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";
import { toast } from "sonner";
import axiosInstance from "../../../features/axiosInstance";

interface Iprops {
  setSearchStaff: Dispatch<SetStateAction<string>>;
}

const PERMISSIONS = [
  "View Inventory",
  "Edit Inventory",
  "View Orders",
  "Edit Orders",
  "Manage Staff",
  "View Reports",
];

const ROLES = [
  { label: "Pharmacy Manager", value: "pharmacy manager" },
  { label: "Pharmacy Employee", value: "pharmacy employee" },
];

const SearchBar = ({ setSearchStaff }: Iprops) => {
  const curPharId = useSelector((state: RootState) => state.currentPharmacy.pharmacy?.pharmacyId);
  const [modalOpen, setModalOpen] = useState(false);
  const [userName, setUserName] = useState("");
  const [roleName, setRoleName] = useState(ROLES[0].value);
  const [permissions, setPermissions] = useState<string[]>([]);
  const [loading, setLoading] = useState(false);

  function handlePermissionChange(permission: string) {
    setPermissions((prev) =>
      prev.includes(permission)
        ? prev.filter((p) => p !== permission)
        : [...prev, permission]
    );
  }

  async function handleSubmit() {
    if (!userName.trim()) {
      toast.error("User name is required");
      return;
    }
    if (!curPharId) {
      toast.error("Pharmacy ID not found");
      return;
    }
    if (roleName === "pharmacy employee" && permissions.length === 0) {
      toast.error("Please select at least one permission");
      return;
    }
    setLoading(true);
    const data = {
      pharmacyId: curPharId,
      userName,
      roleName,
      permissions: roleName === "pharmacy employee" ? permissions : [],
    };
    try {
      await axiosInstance.post(
        "api/pharmacy-employees/SendRequest",
        data,
        { withCredentials: true }
      );
      toast.success("Request sent successfully");
      setModalOpen(false);
      setUserName("");
      setRoleName(ROLES[0].value);
      setPermissions([]);
    } catch (error) {
      toast.error("Failed to send request");
      if (axios.isAxiosError(error)) {
        console.error("Error sending request:", error.response || error.message);
      } else {
        console.error("Unexpected error:", error);
      }
    } finally {
      setLoading(false);
    }
  }

  return (
    <div className="flex justify-between">
      <div className="flex items-center gap-2">
        <BiSearchAlt className="text-2xl text-[#666666D9] " />
        <input
          type="text"
          className="outline-none border-gray-200 rounded-2xl h-7 indent-3"
          placeholder="Search..."
          onChange={(e) => {
            setSearchStaff(e.target.value);
          }}
        />
      </div>
      <div className="flex items-center bg-[#ACD9FD] rounded-2xl p-[5px] px-3 gap-2 cursor-pointer hover:scale-102 duration-200 text-[#026BBE]">
        <button
          className="flex items-center gap-2 font-semibold"
          onClick={() => setModalOpen(true)}
        >
          <IoMdAdd /> Add Employee
        </button>
      </div>
      {/* Modal */}
      {modalOpen && (
        <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/30">
          <div className="bg-white rounded-2xl shadow-lg p-8 w-full max-w-md relative">
            <button
              className="absolute top-2 right-3 text-2xl text-gray-400 hover:text-gray-700"
              onClick={() => setModalOpen(false)}
              aria-label="Close"
            >
              &times;
            </button>
            <h2 className="text-xl font-bold mb-4 text-blue-700">Add Employee</h2>
            <div className="mb-4">
              <label className="block text-gray-600 font-semibold mb-1">User Name</label>
              <input
                type="text"
                className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:border-blue-400"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                placeholder="Enter user name"
              />
            </div>
            <div className="mb-4">
              <label className="block text-gray-600 font-semibold mb-1">Role</label>
              <select
                className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:border-blue-400"
                value={roleName}
                onChange={(e) => setRoleName(e.target.value)}
              >
                {ROLES.map((role) => (
                  <option key={role.value} value={role.value}>
                    {role.label}
                  </option>
                ))}
              </select>
            </div>
            {roleName === "pharmacy employee" && (
              <div className="mb-4">
                <label className="block text-gray-600 font-semibold mb-1">Permissions</label>
                <div className="flex flex-wrap gap-2">
                  {PERMISSIONS.map((perm) => (
                    <label key={perm} className="flex items-center gap-1 bg-gray-100 px-2 py-1 rounded-lg cursor-pointer">
                      <input
                        type="checkbox"
                        checked={permissions.includes(perm)}
                        onChange={() => handlePermissionChange(perm)}
                        className="accent-blue-500"
                      />
                      <span className="text-sm">{perm}</span>
                    </label>
                  ))}
                </div>
              </div>
            )}
            <button
              className="w-full py-2 mt-2 rounded-lg bg-blue-600 text-white font-bold hover:bg-blue-700 transition disabled:opacity-60"
              onClick={handleSubmit}
              disabled={loading}
            >
              {loading ? "Sending..." : "Send Request"}
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default SearchBar;
