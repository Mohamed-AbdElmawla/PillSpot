// think in way to tell user hwo to get the location of the pharmacy from the google maps and send it in the src
import { LuMapPin } from "react-icons/lu";
import ImgIcon from "../../UI/ImgIcon";

interface Iprops{
    modalName : string ;
    name:string ;
    distance : string ;
    lng : number ; 
    lat : number ; 
}

const MapLocation = ({modalName,name,distance,lng,lat}:Iprops) => {
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
              src={`https://maps.google.com/maps?q=${lat},${lng}&z=15&output=embed`}
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
