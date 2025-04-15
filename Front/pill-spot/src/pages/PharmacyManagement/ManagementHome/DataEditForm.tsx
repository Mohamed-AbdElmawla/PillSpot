import { useState } from "react";
import { MdModeEdit } from "react-icons/md";
import { useDispatch, useSelector } from "react-redux";
import { v4 as uuid } from "uuid";
import { AppDispatch, RootState } from "../../../app/store";
import { fetchCurrentPharmacy, updateCurrentPharmacy } from "../../../features/Pharmacy/CRUD/UserPharmaciesSlice/CurPharmacy";

interface IInput {
  name: string;
  type: string;
  title: string;
  value: string | string[];
  id?: string;
}

const weekdays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
const weekdaysMap: Record<string, string> = {
  Sunday: "Sunday",
  Monday: "Monday",
  Tuesday: "Tuesday",
  Wednesday: "Wednesday",
  Thursday: "Thursday",
  Friday: "Friday",
  Saturday: "Saturday",
};

const DataEditForm = () => {
  const dispatch = useDispatch<AppDispatch>();
  const currentPharmacy = useSelector(
    (state: RootState) => state.currentPharmacy
  );
  const daysOpenString = currentPharmacy.pharmacy?.daysOpen || "";
  const daysOpenArray = daysOpenString
    ? daysOpenString.split(", ").map((day) => weekdaysMap[day] || day)
    : [];

  const inptData: IInput[] = [
    { name: "Name", type: "text", title: "Name", value: currentPharmacy.pharmacy?.name || "",},
    { name: "logo", type: "file", title: "Pharmacy Logo", value: ""  },
    { name: "OpeningTime", type: "time", title: "Opening Time", value: currentPharmacy.pharmacy?.openingTime || "08:00",},
    { name: "ClosingTime", type: "time", title: "Closing Time", value: currentPharmacy.pharmacy?.closingTime || "22:00",},
    { name: "ContactNumber", type: "text", title: "Pharmacy Phone Number", value: currentPharmacy.pharmacy?.contactNumber || "123445234",},
    { name: "IsOpen24", type: "checkbox", title: "Open 24", value: currentPharmacy.pharmacy?.isOpen24 ? "true" : "false",},
    { name: "DaysOpen", type: "toggle", title: "Pharmacy Open Days", value: daysOpenArray,},
  ];

  const [fields, setFields] = useState<Record<string, string | string[]>>(
    Object.fromEntries(
      inptData.map((p) => [p.name, p.type === "toggle" ? daysOpenArray : p.value])
    )
  );

  const [readOnly, setReadOnly] = useState<Record<string, boolean>>(
    Object.fromEntries(inptData.map((p) => [p.name, true]))
  );

  const handleOnEdit = (e: React.MouseEvent<HTMLButtonElement>) => {
    const inputName = e.currentTarget.name;
    setReadOnly((prev) => ({ ...prev, [inputName]: !prev[inputName] }));
  };

  async function handleEdit() {
    const formData = new FormData();
  
    const defaultValues: Record<string, string | undefined | boolean> = {
      Name: currentPharmacy.pharmacy?.name,
      OpeningTime: currentPharmacy.pharmacy?.openingTime,
      ClosingTime: currentPharmacy.pharmacy?.closingTime,
      ContactNumber: currentPharmacy.pharmacy?.contactNumber,
      IsOpen24: currentPharmacy.pharmacy?.isOpen24 ? "true" : "false", 
      DaysOpen: currentPharmacy.pharmacy?.daysOpen || "", 
    };
  
    Object.entries(fields).forEach(([key, value]) => {
      console.log(key, " ", value);
    
      if (key === "logo") {
        const fileInput = document.querySelector<HTMLInputElement>('input[name="logo"]');
        if (fileInput?.files && fileInput.files.length > 0) {
          formData.append(key, fileInput.files[0]);
        }
      } else if (key === "DaysOpen") {
        let formattedValue = Array.isArray(value) ? value.join(", ") : value;
        let formattedDefault = defaultValues[key];
    
        formattedDefault = (formattedDefault as string).split(", ").filter(Boolean).sort().join(", ");
        formattedValue = (formattedValue as string).split(", ").filter(Boolean).sort().join(", ");
    
        if (formattedValue !== formattedDefault) {
          formData.append(key, formattedValue);
        }
      } else {
        // Handle all other fields
        
        const currentVal = value ?? "";
    
        
          formData.append(key, currentVal as string);
        
      }
    });
    

    console.log(formData);
  
    try {
      await dispatch(updateCurrentPharmacy({ data: formData, pharmacyId: currentPharmacy.pharmacy?.pharmacyId })).unwrap();
      dispatch(fetchCurrentPharmacy(currentPharmacy.pharmacy?.pharmacyId));
    } catch (error) {
      console.error("Failed to update pharmacy:", error);
    }
  }
  

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, type } = e.target;

    if (type === "checkbox") {
      setFields((prev) => ({
        ...prev,
        [name]: (e.target as HTMLInputElement).checked ? "true" : "false",
      }));
    } else {
      setFields((prev) => ({ ...prev, [name]: e.target.value }));
    }
  };

  console.log(fields);

  const handleDayToggle = (day: string) => {
    if (readOnly["DaysOpen"]) return;

    setFields((prev) => {
      const currentDays = prev["DaysOpen"] as string[];
      const newDays = currentDays.includes(day)
        ? currentDays.filter((d) => d !== day)
        : [...currentDays, day];
      return { ...prev, DaysOpen: newDays };
    });
  };

  const uniqueElements = inptData.map((p) => ({ ...p, id: uuid() }));

  const renderedInputs = uniqueElements.map((p) => (
    <div key={p.name} className="flex gap-1 items-center">
      <span className="bg-blue-200 h-10 flex items-center justify-start px-4 rounded-l-2xl min-w-[300px]">
        {p.title}
      </span>
      <div className="relative flex-1 flex justify-center items-center">
        {p.type === "toggle" ? (
          <div className="grid grid-cols-4 gap-2 h-20 w-130 mr-11">
          {weekdays.map((day) => (
            <button
              key={day}
              type="button"
              onClick={() => handleDayToggle(day)}
              className={`px-4 py-2 rounded-xl text-center ${
                (fields["DaysOpen"] as string[]).includes(day) || daysOpenArray.includes(day)
                  ? "bg-blue-500 text-white"
                  : "bg-gray-200"
              } ${
                readOnly["DaysOpen"]
                  ? "opacity-50 cursor-not-allowed"
                  : "cursor-pointer"
              }`}
              disabled={readOnly["DaysOpen"]}
            >
              {day}
            </button>
          ))}
        </div>
        
        ) : (
          <input
            name={p.name}
            type={p.type}
            value={
              p.type === "checkbox" ? undefined : (fields[p.name] as string)
            }
            checked={
              p.type === "checkbox" ? fields[p.name] === "true" : undefined
            }
            onChange={handleInputChange}
            className={`min-w-[600px] w-full bg-gray-200 h-10 pl-5 pr-10 rounded-r-2xl outline-none ${
              !readOnly[p.name] ? "border-red-400" : "border-none"
            }`}
            readOnly={p.type !== "checkbox" && readOnly[p.name]}
            disabled={p.type === "checkbox" && readOnly[p.name]}
          />
        )}

        {p.name === "DaysOpen" ? (
          <button name={p.name} onClick={handleOnEdit} type="button">
            <MdModeEdit className="absolute right top-1/2 transform -translate-y-1/2 text-2xl text-blue-400 cursor-pointer" />
          </button>
        ) : (
          <button name={p.name} onClick={handleOnEdit} type="button">
            <MdModeEdit className="absolute right-3 top-1/2 transform -translate-y-1/2 text-2xl text-blue-400 cursor-pointer" />
          </button>
        )}
      </div>
    </div>
  ));

  return (
    <div className="flex flex-col w-full gap-3">
      <div className="flex flex-col w-full max-w-sm gap-3">
        {renderedInputs}
      </div>
      <div className="w-4xl flex justify-end">
        <button className="btn btn-primary rounded-2xl bg-blue-200 border-none text-blue-800 mt-20"
         onClick={handleEdit}
        >
          Save Changes
        </button>
      </div>
    </div>
  );
};

export default DataEditForm;
