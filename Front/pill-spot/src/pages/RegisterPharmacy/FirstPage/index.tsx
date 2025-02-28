
import { firstPage, iconMap } from "../common";
import OneInput from "../oneInput";
import {useDispatch, useSelector } from "react-redux";
import { setMainInfo } from "../../../features/RegisterPharmacy/PharmacyRegisterSlice";
import { useState, ChangeEvent } from "react";
import { RootState } from "../../../app/store";

interface Idata {
    Name: string;
    ContactNumber: string;
    LicenseID: string;
    PharmacistLicense: File | null; // File should be null initially
}

const initialData: Idata = {
    Name: "",
    ContactNumber: "",
    LicenseID: "",
    PharmacistLicense: null, 
};

const FirstPage = () => {
    const [mainInfo, setMainInfostate] = useState<Idata>(initialData);
    const dispatch = useDispatch() ; 
    const RegData = useSelector((state:RootState)=>state.pharRegister) ;
    const RegFill = {...RegData,...mainInfo} ;
    dispatch(setMainInfo(RegFill));
    function handleChange(e: ChangeEvent<HTMLInputElement>) {
        const { name, value, type, files } = e.target;

        setMainInfostate((prev) => ({
            ...prev,
            [name]: type === "file" ? files?.[0] || null : value, 
        }));
    }

    const firstPageRender = firstPage.map((p) => (
        <div className="mt-5" key={p.name}>
            <OneInput
                type={p.type}
                placeHolder={p.placeHolder}
                name={p.name}
                onChange={handleChange}
            >
                {iconMap.get(p.name)}
            </OneInput>
        </div>
    ));

    console.log(mainInfo) ;

    return (
        <div>
            {firstPageRender}
        </div>
    );
};

export default FirstPage;
