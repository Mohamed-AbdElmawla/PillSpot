import { firstPage, iconMap } from "../common";
import OneInput from "../oneInput";
import { useDispatch, useSelector } from "react-redux";
import { setMainInfo } from "../../../features/Pharmacy/Register/PharmacyRegisterSlice";
import { useState, ChangeEvent, useEffect } from "react";
import { RootState } from "../../../app/store";

interface Idata {
  Name: string;
  ContactNumber: string;
  LicenseId: string;
  PharmacistLicense: File | null;
}

const initialData: Idata = {
  Name: "",
  ContactNumber: "",
  LicenseId: "",
  PharmacistLicense: null,
};

const FirstPage = () => {
  const dispatch = useDispatch();
  const RegData = useSelector((state: RootState) => state.pharRegister);


  const [mainInfo, setMainInfostate] = useState<Idata>({ ...initialData, ...RegData });

  useEffect(() => {
    dispatch(setMainInfo({ ...RegData, ...mainInfo }));
  }, [mainInfo, dispatch, RegData]);
  

  function handleChange(e: ChangeEvent<HTMLInputElement>) {
    const { name, value, type, files } = e.target;

    setMainInfostate((prev) => ({
      ...prev,
      [name]: type === "file" ? files?.[0] || null : value,
    }));
  }

  const firstPageRender = firstPage.map((p) => (
    <div className="mt-5" key={p.name}>
      {p.type !== "file" && (
        <>
          <span className="text-gray-500 mb-2 block ml-2 font-bold">
            {p.title}
          </span>
          <OneInput
            type={p.type}
            placeHolder={p.placeHolder}
            name={p.name}
            onChange={handleChange}
            value={mainInfo[p.name as keyof Idata] || ""}
          >
            {iconMap.get(p.name)}
          </OneInput>
        </>
      )}

      {p.type === "file" && (
        <>
          <span className="text-gray-500 mb-2 block ml-2 font-bold">
            {p.title}
          </span>
          <fieldset className="fieldset">
            <input
              type="file"
              className="file-input rounded-2xl w-full focus:outline-none focus:border-gray-300"
              name="PharmacistLicense"
              onChange={handleChange}
            />
            <label className="fieldset-label">Max size 1MB</label>
          </fieldset>
        </>
      )}
    </div>
  ));

  return <div>{firstPageRender}</div>;
};

export default FirstPage;
