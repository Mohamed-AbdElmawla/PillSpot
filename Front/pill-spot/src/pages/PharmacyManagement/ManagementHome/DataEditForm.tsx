import { useState } from "react";
import { MdModeEdit } from "react-icons/md";
import { v4 as uuid } from "uuid";

interface IInput {
  name: string;
  type: string;
  title: string;
  value: string | string[];
  id?: string;
}

const weekdays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

const inptData: IInput[] = [
  { name: "Name", type: "text", title: "Name", value: "pharmacy" },
  { name: "logo", type: "file", title: "Pharmacy Logo", value: "" },
  { name: "OpeningTime", type: "time", title: "Opening Time", value: "08:00" },
  { name: "ClosingTime", type: "time", title: "Closing Time", value: "22:00" },
  { name: "ContactNumber", type: "text", title: "Pharmacy Phone Number", value: "123445234" },
  { name: "IsOpen24", type: "checkbox", title: "Open 24", value: "false" },
  { name: "DaysOpen", type: "toggle", title: "Pharmacy Open Days", value: [] },
];

const DataEditForm = () => {
  const [fields, setFields] = useState<Record<string, string | string[]>>(
    Object.fromEntries(inptData.map((p) => [p.name, p.type === "toggle" ? [] : p.value]))
  );

  const [readOnly, setReadOnly] = useState<Record<string, boolean>>(
    Object.fromEntries(inptData.map((p) => [p.name, true]))
  );

  const handleOnEdit = (e: React.MouseEvent<HTMLButtonElement>) => {
    const inputName = e.currentTarget.name;
    setReadOnly((prev) => ({ ...prev, [inputName]: !prev[inputName] }));
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, type } = e.target;

    if (type === "checkbox") {
      setFields((prev) => ({ ...prev, [name]: (e.target as HTMLInputElement).checked ? "true" : "false" }));
    } else {
      setFields((prev) => ({ ...prev, [name]: e.target.value }));
    }
  };

  console.log(fields)


  const handleDayToggle = (day: string) => {
    if (readOnly["DaysOpen"]) return; 

    setFields((prev) => {
      const currentDays = prev["DaysOpen"] as string[];
      const newDays = currentDays.includes(day) ? currentDays.filter((d) => d !== day) : [...currentDays, day];
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
          <div className="flex justify-center items-center gap-2">
            {weekdays.map((day) => (
              <button
                key={day}
                type="button"
                onClick={() => handleDayToggle(day)}
                className={`px-4 py-2 rounded-xl ${
                  (fields["DaysOpen"] as string[]).includes(day)
                    ? "bg-blue-500 text-white"
                    : "bg-gray-200"
                } ${readOnly["DaysOpen"] ? "opacity-50 cursor-not-allowed" : "cursor-pointer"}`}
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
            value={p.type === "checkbox" ? undefined : (fields[p.name] as string)}
            checked={p.type === "checkbox" ? fields[p.name] === "true" : undefined}
            onChange={handleInputChange}
            className={`min-w-[600px] w-full bg-gray-200 h-10 pl-5 pr-10 rounded-r-2xl outline-none ${
              !readOnly[p.name] ? "border-red-400" : "border-none"
            }`}
            readOnly={p.type !== "checkbox" && readOnly[p.name]}
            disabled={p.type === "checkbox" && readOnly[p.name]}
          />
        )}

        {
          p.name === 'DaysOpen' ?
        <button name={p.name} onClick={handleOnEdit} type="button">
          <MdModeEdit className="absolute right top-1/2 transform -translate-y-1/2 text-2xl text-blue-400 cursor-pointer" />
        </button> 
        :
        <button name={p.name} onClick={handleOnEdit} type="button">
          <MdModeEdit className="absolute right-3 top-1/2 transform -translate-y-1/2 text-2xl text-blue-400 cursor-pointer" />
        </button> 
        }
      </div>
    </div>
  ));

  return (
    <div className="flex flex-col w-full gap-3">
      <div className="flex flex-col w-full max-w-sm gap-3">{renderedInputs}</div>
      <div className="w-4xl flex justify-end">
        <button className="btn btn-primary rounded-2xl bg-blue-200 border-none text-blue-800">
          Save Changes
        </button>
      </div>
    </div>
  );
};

export default DataEditForm;
