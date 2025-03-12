
import { CiHospital1 } from "react-icons/ci";
import { IoMdTime } from "react-icons/io";
import { MdOutlineEmail } from "react-icons/md";
import { CiPhone } from "react-icons/ci";
import { TbLicense } from "react-icons/tb";
import { FaRegFileAlt } from "react-icons/fa";
import { IoLocationOutline } from "react-icons/io5";
import { TbCurrentLocation } from "react-icons/tb";
import { PiCityLight } from "react-icons/pi";
import { FaBarcode } from "react-icons/fa";
import { WiTime10 } from "react-icons/wi";


interface Iprops {
  name: string;
  placeHolder: string;
  type: string;
  title? : string ;
}

export const iconMap = new Map();


const styleTal = "absolute left-5 text-4xl font-bold text-gray-400";
const iconMapping: { [key: string]: JSX.Element } = {
  Name: <CiHospital1 className={styleTal} />,
    PharmacyEmail: <MdOutlineEmail className={styleTal} />,
    ContactNumber: <CiPhone className={styleTal} />,
    LicenseId: <TbLicense className={styleTal} />,
    PharmacistLicense: <FaRegFileAlt className={styleTal} />,
    AdditionalInfo: <IoLocationOutline className={styleTal} />,
    MapLocation: <TbCurrentLocation className={styleTal} />,
    City: <PiCityLight className={styleTal} />,
    ZipCode: <FaBarcode className={styleTal} />,
    OpeningTime: <IoMdTime className={styleTal} />,
    ClosingTime: <WiTime10 className={styleTal} />,
  };
  
  const populateIconMap = (fields: Iprops[]) => {
    fields.forEach(({ name }) => {
      if (iconMapping[name]) {
        iconMap.set(name, iconMapping[name]);
      }
    });
  };
  
  export const firstPage: Iprops[] = [
    { name: "Name", placeHolder: "Pharmacy Name", type: "text"  , title : 'Pharmacy Name' },
    { name: "ContactNumber", placeHolder: "Pharmacy Phone Number", type: "text"  , title : 'Phone Number'},
    { name: "LicenseId", placeHolder: "License Number", type: "text", title:"License Number"},
    { name: "PharmacistLicense", placeHolder: "License Document", type: "file"  , title : 'License Document'},
  ];
  
  export const secondPage: Iprops[] = [
    { name: "AdditionalInfo", placeHolder: "Full Address", type: "text" },
  ];
  
  export const thirdPage: Iprops[] = [
    { name: "OpeningTime", placeHolder: "", type: "time" , title: "Opening Time" },
    { name: "ClosingTime", placeHolder: "", type: "time" , title: "Closing Time" },
  ];
  
  populateIconMap(firstPage);
  populateIconMap(secondPage);
  populateIconMap(thirdPage);