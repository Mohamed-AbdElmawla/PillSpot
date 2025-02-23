import Rating from "../../../UI/Rating";
import { GrLocation } from "react-icons/gr";
import { GrMapLocation } from "react-icons/gr";
import { FiPhoneCall } from "react-icons/fi";
import { FaWhatsapp } from "react-icons/fa";
import { CiFacebook } from "react-icons/ci";
import { FaSearch } from "react-icons/fa";

const Details = () => {
  const openModal = () => {
    const modal = document.getElementById("my_modal_3") as HTMLDialogElement;
    modal?.showModal();
  };

  function closeModal() {
    const modal = document.getElementById("my_modal_3") as HTMLDialogElement;
    modal?.close();
  }

  return (
    <>
      <button className="btn" onClick={openModal}>
        open modal
      </button>
      <dialog id="my_modal_3" className="modal">
        <div className="modal-box container px-20">
          <form method="dialog">
            <button
              type="button"
              className="btn btn-sm btn-circle btn-ghost absolute right-2 top-2"
              onClick={closeModal}
            >
              ✕
            </button>
          </form>
          {/* each div will be component */}
          <div className="p-4">
            {/* Pharmacy Info Section */}
            <div className="flex flex-wrap gap-6 items-center bg-base-200 p-5 rounded-xl hover:bg-base-300">
              <img
                className="w-24 md:w-40 lg:w-60 xl:w-70 rounded-xl"
                src="https://img.daisyui.com/images/profile/demo/2@94.webp"
                alt="Avatar Tailwind CSS Component"
              />
              <div className="flex flex-col gap-4">
                <h1 className="text-3xl md:text-4xl lg:text-5xl xl:text-6xl font-semibold">
                  EL Pharmacy Pharmacy
                </h1>
                <Rating value={7} w={"5"} />

                {/* Address Badges */}
                <div className="flex flex-wrap gap-2">
                  {["Address 1", "Address 2", "Address 3"].map(
                    (address, index) => (
                      <span
                        key={index}
                        className="badge badge-lg bg-[#49708f] text-white flex items-center gap-2 px-3 py-2"
                      >
                        <GrLocation />
                        {address}
                      </span>
                    )
                  )}
                </div>

                <div className="flex flex-wrap gap-2">
                  <div className="badge badge-soft badge-neutral">
                    <FiPhoneCall />
                    01001234231
                  </div>
                  <div className="badge badge-soft badge-neutral">
                    <FaWhatsapp />
                    El Pharmacy
                  </div>
                  <div className="badge badge-soft badge-neutral">
                    <CiFacebook />
                    El Pharmacy.com
                  </div>
                  <div className="badge badge-soft badge-neutral">
                    <FiPhoneCall />
                    0100134231
                  </div>
                </div>
              </div>
            </div>

            <div className="flex flex-wrap w-full gap-4 mt-6">
              <div className="card bg-base-200 rounded-box flex flex-col flex-[2] p-5 hover:bg-base-300 min-w-[300px]">
                <div className="flex items-center text-xl md:text-2xl gap-2 m-auto mb-5">
                  <GrMapLocation />
                  <span className="font-semibold">Map Location</span>
                </div>
                <iframe
                  className="w-full h-[300px] md:h-[400px] rounded-xl border"
                  src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d2661.5242743160306!2d31.18542820904337!3d27.16885061272134!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2seg!4v1740093033886!5m2!1sen!2seg"
                  loading="lazy"
                ></iframe>
              </div>

              <div className="hidden md:flex divider divider-horizontal"></div>

              <div className="flex flex-col flex-1 min-w-[250px]">
                <div className="card bg-base-300 rounded-box grid place-items-center p-5 gap-5">
                  <div className="flex items-center text-xl gap-2 m-auto">
                    <FaSearch />
                    <span className="font-semibold">Search in our stock</span>
                  </div>
                  <label className="floating-label">
                    <span>Medicine Name</span>
                    <div className="flex gap-1">

                    <input
                      type="text"
                      placeholder="Your name"
                      className="input input-md focus:outline-none focus:border-[#49708f]"
                    />
                  <button className="btn btn-outline"><FaSearch /></button>
                    </div>
                  </label>
                </div>
                <div className="divider"></div>
                <div className="card rounded-box grid h-20 place-items-center">
                  <div className="flex w-52 flex-col gap-4">
                    <div className="skeleton h-32 w-full"></div>
                    <div className="skeleton h-4 w-28"></div>
                    <div className="skeleton h-4 w-full"></div>
                    <div className="skeleton h-4 w-full"></div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </dialog>
    </>
  );
};

export default Details;
