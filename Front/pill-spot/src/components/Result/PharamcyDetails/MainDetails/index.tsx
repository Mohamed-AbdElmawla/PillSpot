import { GrLocation } from "react-icons/gr";
import { FiPhoneCall } from "react-icons/fi";
import { FaWhatsapp } from "react-icons/fa";
import { CiFacebook } from "react-icons/ci";
import Rating from "../../../../UI/Rating";
import Padge from "./padge";

interface Iprops {
  name: string;
  address1: string;
  address2?: string;
  address3?: string;
  phoneNumber: string;
  faceBookPage: string;
  whatsAppNumber: string;
  imgLink:string ;
}

const MainDetails = (props: Iprops) => {
  return (
    <div className="flex flex-wrap gap-6 items-center bg-base-200 p-5 rounded-xl hover:bg-base-300">
      <img
        className="w-24 md:w-40 lg:w-60 xl:w-70 rounded-xl"
        src={props.imgLink}
        alt="Pharmacy Picture"
      />
      <div className="flex flex-col gap-4">
        <h1 className="text-3xl md:text-4xl lg:text-5xl xl:text-6xl font-semibold">
          {props.name}
        </h1>
        <Rating value={7} w={"5"} />

        <div className="flex flex-wrap gap-2">
          <span className="badge badge-lg bg-[#49708f] text-white flex items-center gap-2 px-3 py-2">
            <GrLocation />
            {props.address1}
          </span>
          <span className="badge badge-lg bg-[#49708f] text-white flex items-center gap-2 px-3 py-2">
            <GrLocation />
            {props.address2}
          </span>
          <span className="badge badge-lg bg-[#49708f] text-white flex items-center gap-2 px-3 py-2">
            <GrLocation />
            {props.address3}
          </span>
        </div>

        <div className="flex flex-wrap gap-2">
          <Padge details={props.phoneNumber}>
            <FiPhoneCall />
          </Padge>
          <Padge details={props.whatsAppNumber}>
            <FaWhatsapp />
          </Padge>
          <Padge details={props.faceBookPage}>
            <CiFacebook />
          </Padge>
        </div>
      </div>
    </div>
  );
};

export default MainDetails;
