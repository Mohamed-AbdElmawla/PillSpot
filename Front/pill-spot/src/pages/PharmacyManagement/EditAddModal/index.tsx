import { Dialog, DialogPanel } from "@headlessui/react";
import { ChangeEvent, ReactNode, useState } from "react";
// import ImageUpload from "../../../UI/ImageUpload";

import { FaTablets } from "react-icons/fa";
import { InputNames, InputStaff } from "./data";
import { BiSolidFactory } from "react-icons/bi";
import { BiSolidPackage } from "react-icons/bi";
import { FaPills } from "react-icons/fa";
import { FaRegCalendarTimes } from "react-icons/fa";
import { BiDollarCircle } from "react-icons/bi";
import { MdOutlineEmail } from "react-icons/md";
import { FaRegUser } from "react-icons/fa";
import { FiPhone } from "react-icons/fi";


interface IInputsData {
  name: string;
  type: string;
  title: string;
  options? : string[] ;
}

interface IProps<T extends IInputsData[]> {
  buttonText: string;
  buttonStyle: string;
  children: ReactNode;
  handleChange: (e: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLSelectElement>)=>void ;
  closeButonTitle:string ;
  inputData: T;
  handleSubmitFormData : () => void ;
}

export default function FormModal<T extends IInputsData[]>({
  buttonText,
  buttonStyle,
  inputData,
  children,
  closeButonTitle,

  handleChange ,
  handleSubmitFormData ,
}: IProps<T>) {
  const [isOpen, setIsOpen] = useState(false);

  const styleIcon = "text-4xl text-[#1C8DC9]";
  const mapIcon = new Map<string, JSX.Element>();
  mapIcon.set(InputNames.MedicineName, <FaTablets className={styleIcon} />);
  mapIcon.set(
    InputNames.Manufacturer,
    <BiSolidFactory className={styleIcon} />
  );
  mapIcon.set(InputNames.Quantity, <BiSolidPackage className={styleIcon} />);
  mapIcon.set(InputNames.Category, <FaPills className={styleIcon} />);
  mapIcon.set(InputNames.exp, <FaRegCalendarTimes className={styleIcon} />);
  mapIcon.set(InputNames.price, <BiDollarCircle className={styleIcon} />);
  mapIcon.set(InputStaff.Email, <MdOutlineEmail className={styleIcon}/>);
  mapIcon.set(InputStaff.JobTitle, <FaRegUser className={styleIcon}/>);
  mapIcon.set(InputStaff.PhoneNumber, <FiPhone className={styleIcon}/>);

  function handleSubmitData() {
    handleSubmitFormData() ;
    close();
  }

  function open() {
    setIsOpen(true);
  }

  function close() {
    setIsOpen(false);
  }

  //_________________________Render_______________________________//

  const renderedData = Array.isArray(inputData)
  ? inputData.map((p) =>
      p.type === "list" ? (
        <div key={p.name}>
          <div className="flex items-center justify-center gap-4 my-3">
            {mapIcon.get(p.name)}
            <select
              name={p.name}
              className="text-[#666666D9] w-full border-0 placeholder:text-2xl outline-none text-2xl bg-gray-50"
              onChange={handleChange}
            >
              <option value="">Select {p.title}</option>
              {p.options?.map((option) => (
                <option key={option} value={option}>
                  {option}
                </option>
              ))}
            </select>
          </div>
          <div className="divider divider-info m-0 p-0"></div>
        </div>
      ) : (
        <>
          <div className="flex items-center justify-center gap-4 my-3" key={p.name}>
            {mapIcon.get(p.name)}
            <input
              type={p.type}
              name={p.name}
              className="text-[#666666D9] w-full border-0 placeholder:text-2xl outline-none text-2xl"
              placeholder={p.title}
              onChange={handleChange} 
            />
          </div>
          <div className="divider divider-info m-0 p-0"></div>
        </>
      )
    )
  : null;


  return (
    <>
      <button className={`${buttonStyle} flex items-center`} onClick={open}>
        {children}
        {buttonText}
      </button>

      <Dialog
        open={isOpen}
        as="div"
        className="relative z-10 focus:outline-none"
        onClose={close}
      >
        {isOpen && (
          <div className="fixed inset-0 bg-opacity-50 backdrop-brightness-70 backdrop-blur-xs "></div>
        )}

        <div className="fixed inset-0 z-10 w-lg mx-auto overflow-y-auto">
          <div className="flex min-h-full items-center justify-center p-4">
            <DialogPanel
              transition
              className="w-400 max-w-2xl rounded-[48px] p-6 bg-gray-50 duration-300 ease-out data-[closed]:transform-[scale(95%)] data-[closed]:opacity-0"
            >
                {/* <div className="flex flex-col items-center">
                  <ImageUpload />
                  <div className="text-red-500 font-bold mb-5"></div>
                </div> */}
                <div className="flex flex-col p-5">{renderedData}</div>

                <div className="mt-4 flex items-center justify-center space-x-4">
                    <button className="w-xs bg-[#1C8DC9] h-10 rounded-[14px] text-2xl text-white " onClick={handleSubmitData}>{closeButonTitle}</button>
                </div>
            </DialogPanel>
          </div>
        </div>
      </Dialog>
    </>
  );
}
