// think in way to tell user hwo to get the location of the pharmacy from the google maps and send it in the src
import { LuMapPin } from "react-icons/lu";
import ImgIcon from "../../UI/ImgIcon";

interface Iprops{
    modalName : string ;
    name:string ;
    distance : string ;
}

const MapLocation = ({modalName,name,distance}:Iprops) => {
  const openModal = () => {
    const modal = document.getElementById(modalName) as HTMLDialogElement;
    modal?.showModal();
  };
  return (
    <div>
      <button className="btn" onClick={openModal}>
        <LuMapPin className="text-xl text-[#02457a]" />
      </button>
      <dialog id={modalName} className="modal">
        <div className="modal-box">
          <div className="mb-5 flex gap-2">
            <ImgIcon src="https://img.daisyui.com/images/profile/demo/2@94.webp" />
            <div>
              <div className="font-bold">{name}</div>

              <span className="badge badge-ghost badge-sm">{distance} Km Away</span>
            </div>
          </div>
          <div>
            <iframe
              className="w-full h-[400px] rounded-xl"
              src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d2661.5242743160306!2d31.18542820904337!3d27.16885061272134!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2seg!4v1740093033886!5m2!1sen!2seg"
              loading="lazy"
            ></iframe>
          </div>
        </div>
        <form method="dialog" className="modal-backdrop">
          <button type="submit">close</button>
        </form>
      </dialog>
    </div>
  );
};

export default MapLocation;
