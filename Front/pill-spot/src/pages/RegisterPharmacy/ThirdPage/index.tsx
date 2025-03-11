import { iconMap, thirdPage } from "../common";
import OneInput from "../oneInput";
import { ChangeEvent, useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { setTimingInfo } from "../../../features/Pharmacy/Register/PharmacyRegisterSlice";
import { RootState } from "../../../app/store";

const days = [
  "Sunday",
  "Monday",
  "Tuesday",
  "Wednesday",
  "Thursday",
  "Friday",
  "Saturday",
];

function WorkingDaysSelector() {
  const dispatch = useDispatch();
  const PharData = useSelector((state: RootState) => state.pharRegister);
  

  const [selectedDays, setSelectedDays] = useState<string[]>(PharData.DaysOpen ? PharData.DaysOpen.split(", ") : []);

  useEffect(() => {
    dispatch(setTimingInfo({ ...PharData, DaysOpen: selectedDays.length > 0 ? selectedDays.join(", ") : "" }));
  }, [selectedDays]);

  const toggleDay = (day: string) => {
    setSelectedDays((prev) =>
      prev.includes(day) ? prev.filter((d) => d !== day) : [...prev, day]
    );
  };

  return (
    <div className="w-64">
      <button className="border p-2 rounded w-full text-left">
        {selectedDays.length > 0 ? selectedDays.join(", ") : <span className="text-gray-400">Select Working Days</span>}
      </button>

      <div className="bg-white border rounded-2xl mt-2 w-112 p-2">
        <div className="grid grid-cols-3">
          {days.map((day) => (
            <label key={day} className="flex items-center gap-2 cursor-pointer">
              <input
                type="checkbox"
                checked={selectedDays.includes(day)}
                onChange={() => toggleDay(day)}
                className="cursor-pointer"
              />
              {day}
            </label>
          ))}
        </div>
      </div>
    </div>
  );
}


const TimeDetails = () => {
  const dispatch = useDispatch();
  const PharData = useSelector((state: RootState) => state.pharRegister);
  
  
  const [IsOpen24, setIsOpen24] = useState(PharData.IsOpen24 || false);
  const [workTime, setWorkTime] = useState({
    OpeningTime: PharData.OpeningTime || "",
    ClosingTime: PharData.ClosingTime || "",
  });

  useEffect(() => {
    dispatch(setTimingInfo({ ...PharData, IsOpen24, ...workTime }));
  }, [IsOpen24, workTime]);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setIsOpen24(event.target.checked);
  };

  function handleTimeChange(e: ChangeEvent<HTMLInputElement>) {
    setWorkTime((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  }

  const thirdPageRender = thirdPage.map((p) => (
    <div key={p.name}>
      <span className="text-gray-500 mb-2 block ml-2 font-bold">{p.title}</span>
      <OneInput
        type={p.type}
        placeHolder={p.placeHolder}
        name={p.name}
        onChange={handleTimeChange}
        value={workTime[p.name as keyof typeof workTime]}
      >
        {iconMap.get(p.name)}
      </OneInput>
    </div>
  ));

  return (
    <div className="flex flex-col gap-5 items-start">
      {thirdPageRender}

      <fieldset className="fieldset p-4 bg-white border border-gray-400 rounded-2xl text-lg h-15 w-full mt-5">
        <label className="fieldset-label">
          <input
            type="checkbox"
            className="checkbox"
            onChange={handleChange}
            checked={IsOpen24}
          />
          <span className="font-bold">We're open 24 hours a day</span>
        </label>
      </fieldset>

      <WorkingDaysSelector />
    </div>
  );
};

export default TimeDetails;
