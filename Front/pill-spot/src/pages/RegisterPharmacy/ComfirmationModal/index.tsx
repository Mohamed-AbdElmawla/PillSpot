import { Dialog, DialogPanel, DialogTitle } from "@headlessui/react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../../app/store";
import { Button } from "../../../UI/Button";
import { useEffect, useState } from "react";
import { toast } from "sonner";
import {
  resetPharmacyRequest,
  SendPharmacyRegisterRequest,
} from "../../../features/Pharmacy/Register/PharmacyRequestToBack";
import { useNavigate } from "react-router-dom";
import { setColor } from "../../../features/Toasts/toastSlice";
import { resetPharmacyForm } from "../../../features/Pharmacy/Register/PharmacyRegisterSlice";

interface Iprops {
  canOpen: boolean;
}

function PharmacyDetailsModal({ canOpen }: Iprops) {
  const [isOpen, setIsOpen] = useState(canOpen);
  const pharmacyData = useSelector((state: RootState) => state.pharRegister);
  const dispatch = useDispatch<AppDispatch>();
  const RequestStatus = useSelector(
    (state: RootState) => state.requestPharmacyAdd
  );

  const navigate = useNavigate();

  const [logoPreview, setLogoPreview] = useState<string | null>(null);

  useEffect(() => {
    if (RequestStatus.isError) {
      dispatch(setColor());
      toast.error("There is an error");
      console.log("there is an error : ", RequestStatus.message);
      setIsOpen(false) ;
    }

    if (RequestStatus.isSuccess) {
      dispatch(setColor());
      toast.success("The request sent successfully");
      setIsOpen(false) ;
      navigate("/usersettingpage");
    }

    dispatch(resetPharmacyRequest());
  }, [
    RequestStatus.isError,
    RequestStatus.isSuccess,
    RequestStatus.user,
    RequestStatus.message,
    navigate,
    dispatch,
  ]);

  useEffect(() => {
    if (pharmacyData.logo instanceof File) {
      const objectUrl = URL.createObjectURL(pharmacyData.logo);
      setLogoPreview(objectUrl);

      return () => URL.revokeObjectURL(objectUrl);
    } else {
      setLogoPreview(null);
    }
  }, [pharmacyData.logo]);

  function open() {
    if (canOpen) setIsOpen(true);
  }

  function close() {
    dispatch(SendPharmacyRegisterRequest(pharmacyData));
    dispatch(resetPharmacyForm());
    dispatch(resetPharmacyRequest());
  }

  return (
    <>
      <button
        className="btn rounded-2xl text-xl text-gray-600 fong-bold"
        onClick={open}
      >
        Submit
      </button>
      <Dialog
        open={isOpen}
        as="div"
        className="relative z-10 focus:outline-none"
        onClose={close}
      >
        {isOpen && (
          <div className="fixed inset-0 bg-opacity-50 backdrop-blur-md"></div>
        )}

        <div className="fixed inset-0 z-10 w-screen overflow-y-auto">
          <div className="flex min-h-full items-center justify-center p-4">
            <DialogPanel
              transition
              className="w-400 max-w-2xl rounded-xl p-6 bg-gray-50 duration-300 ease-out data-[closed]:transform-[scale(95%)] data-[closed]:opacity-0"
            >
              {RequestStatus.isLoading ? (
                <span className="loading loading-ring w-100 block m-auto"></span>
              ) : (
                <>
                  <DialogTitle
                    as="h3"
                    className="text-base/7 font-medium text-gray-900 flex items-center justify-center"
                  >
                    <span className="block mb-5">Pharmacy Details</span>
                  </DialogTitle>

                  {logoPreview ? (
                    <div className="flex justify-center mb-5">
                      <img
                        src={logoPreview}
                        alt="Pharmacy Logo"
                        className="w-24 h-24 object-cover rounded-full border-2 border-gray-300"
                      />
                    </div>
                  ) : (
                    <p className="text-center text-gray-500">
                      No Logo Available
                    </p>
                  )}

                  <div className="text-left space-y-3">
                    <p>
                      <strong>Name:</strong> {pharmacyData.Name || "N/A"}
                    </p>
                    <p>
                      <strong>Contact Number:</strong>{" "}
                      {pharmacyData.ContactNumber || "N/A"}
                    </p>
                    <p>
                      <strong>License ID:</strong>{" "}
                      {pharmacyData.LicenseId || "N/A"}
                    </p>
                    <p>
                      <strong>Pharmacist License:</strong>{" "}
                      {pharmacyData.PharmacistLicense
                        ? "Uploaded"
                        : "Not Provided"}
                    </p>
                    <p>
                      <strong>Additional Info:</strong>{" "}
                      {pharmacyData.AdditionalInfo || "N/A"}
                    </p>
                    <p>
                      <strong>Opening Time:</strong>{" "}
                      {pharmacyData.OpeningTime || "N/A"}
                    </p>
                    <p>
                      <strong>Closing Time:</strong>{" "}
                      {pharmacyData.ClosingTime || "N/A"}
                    </p>
                    <p>
                      <strong>Open 24 Hours:</strong>{" "}
                      {pharmacyData.IsOpen24 ? "Yes" : "No"}
                    </p>
                    <p>
                      <strong>Days Open:</strong>{" "}
                      {pharmacyData.DaysOpen || "N/A"}
                    </p>
                    <p>
                      <strong>City:</strong> {pharmacyData.CityName || "N/A"}
                    </p>
                    <p>
                      <strong>Location:</strong>{" "}
                      {pharmacyData.Longitude && pharmacyData.Latitude
                        ? `${pharmacyData.Latitude}, ${pharmacyData.Longitude}`
                        : "Not Provided"}
                    </p>
                  </div>
                </>
              )}

              <div className="mt-4 flex items-center justify-center space-x-4">
                <Button color="white" onClick={close}>
                  Submit
                </Button>
              </div>
            </DialogPanel>
          </div>
        </div>
      </Dialog>
    </>
  );
}

export default PharmacyDetailsModal;
