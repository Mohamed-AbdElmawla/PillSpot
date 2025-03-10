import { useState } from "react";
import { MdModeEdit } from "react-icons/md";
import {v4 as uuid} from "uuid" ;

interface IInput {
  name: string;
  type: string;
  title: string;
  value: string;
  id? : string ;
}

const inptData: IInput[] = [
  { name: "Name", type: "text", title: "Name", value: "pharmacy" },
  {
    name: "LicenseDocument",
    type: "file",
    title: "License Document",
    value: "",
  },
  {
    name: "LicenseNumber",
    type: "text",
    title: "License Number",
    value: "234sdg345",
  },
  {
    name: "Email",
    type: "email",
    title: "Pharmacy Email",
    value: "pharmacy@pharmacy.com",
  },
  {
    name: "PhoneNumber",
    type: "text",
    title: "Pharmacy Phone Number",
    value: "123445234",
  },
  {
    name: "Location",
    type: "text",
    title: "Google Maps Location",
    value:
      '<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d14196.543698748299!2d31.182491950000003!3d27.183464400000002!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2seg!4v1740687595429!5m2!1sen!2seg" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>',
  },
  {
    name: "FullAddress",
    type: "text",
    title: "Full Address",
    value: "asdf asdf asfas",
  },
  {
    name: "State",
    type: "text",
    title: "State",
    value: "pharmacy@pharmacy.com",
  },
  { name: "City", type: "text", title: "City", value: "pharmacy@pharmacy.com" },
];

const DataEditForm = () => {
  const [fields, setFields] = useState<Record<string, string>>(
    Object.fromEntries(inptData.map((p) => [p.name, p.value]))
  );
  const [readOnly, setReadOnly] = useState<Record<string, boolean>>(
    Object.fromEntries(inptData.map((p) => [p.name, true]))
  );

  const handleOnEdit = (e: React.MouseEvent<HTMLButtonElement>) => {
    const inputName = e.currentTarget.name;
    setReadOnly((prev) => ({ ...prev, [inputName]: !prev[inputName] }));
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFields((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  console.log(fields);

  const uniqueElements = inptData.map((p)=>({...p,id:uuid()})) ; 

  const renderedInputs = uniqueElements.map((p) => (
    <div key={p.name} className="flex gap-1 items-center">
      <span className="bg-blue-200 h-10 flex items-center justify-start px-4 rounded-l-2xl min-w-[300px]">
        {p.title}
      </span>
      <div className="relative flex-1">
        <input
          name={p.name}
          type={p.type}
          value={fields[p.name]}
          onChange={handleInputChange}
          className={`min-w-[600px] w-full bg-gray-200 h-10 pl-5 pr-10 rounded-r-2xl outline-none ${
            !readOnly[p.name] ? "border-red-400" : "border-none"
          }`}
          readOnly={readOnly[p.name]}
        />
        <button name={p.name} onClick={handleOnEdit} type="button">
          <MdModeEdit className="absolute right-3 top-1/2 transform -translate-y-1/2 text-2xl text-blue-400 cursor-pointer" />
        </button>
      </div>
    </div>
  ));

  return (
    <div className="flex flex-col w-full  gap-3 ">
      <div className="flex flex-col w-full max-w-sm gap-3 ">{renderedInputs}</div>
      <div className="w-4xl flex justify-end">
        <button className="btn btn-primary rounded-2xl bg-blue-200 border-none text-blue-800">
          Save Changes
        </button>
      </div>
    </div>
  );
};

export default DataEditForm;
