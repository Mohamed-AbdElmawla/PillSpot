import { Dialog, DialogPanel, DialogTitle } from "@headlessui/react";
import { useState } from "react";
import { Button } from "../../UI/Button";
import InputIcon from "../../UI/InputIcon/InputIcon";
import { Iprops } from "./types";
// import { v4 as uuid } from "uuid";
import { ChangeEvent } from "react";

import { SvgIcon } from "../../UI/SvgIcon";
import ErrorMessage from "../ErrorMessage/ErrorMessage";
import { emptyLoginData, defaultErrorMsgs, inputArr } from "./data";
import { validateSignUpData } from "./Validation";

export default function LoginModal({ buttonText }: Iprops) {
  //____________________ states ______________________ //

  const [isOpen, setIsOpen] = useState(false);
  const [logInData, setlogInData] = useState(emptyLoginData);
  const [errorMsgs, setErrors] = useState(defaultErrorMsgs);

  //___________________________Handlers______________________________//

  function handleSubmitData() {
    const obj = validateSignUpData(logInData);
    const isValid = Object.values(obj.errors).every((error) => error === "");
    if (isValid) {
      console.log("Form submitted with data: ", logInData);
    } else {
      setErrors((prev) => ({ ...prev, ...obj.errors }));
      console.log("THere is errors : ", obj);
    }
  }

  function open() {
    setIsOpen(true);
  }

  function close() {
     setlogInData(emptyLoginData);
    setErrors(emptyLoginData);
    setIsOpen(false);
  }

  function handleChange(event: ChangeEvent<HTMLInputElement>) {
    const { name, value } = event.target;
    // console.log("Changing:", name, value);
    setErrors((prev) => ({ ...prev, [name]: "" }));
    setlogInData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }
  console.log(logInData) ;
  //_________________________Render_______________________________//

  const renderInput = inputArr.map((inpt) => (
    <div key={inpt.name + "cleeXlMdLg"}>
      <div
        className={`relative flex items-center m-3 transition-all duration-300 ease-in-out ${
          errorMsgs[inpt.name] ? "border-2 border-red-500 rounded-lg" : ""
        }`}
      >
        <span className="absolute left-3 text-[#02457A]">
          <SvgIcon width="30" height="30" src={inpt.icon} />
        </span>

        <InputIcon
          name={inpt.name}
          id={inpt.name}
          placeholder={inpt.placeHolder}
          type={inpt.type}
          onChange={handleChange}
          value={logInData[inpt.name]}
        />
      </div>
      <ErrorMessage msg={errorMsgs[inpt.name]} />
    </div>
  ));

  return (
    <>
      <Button color="white" onClick={open}>{buttonText}</Button>

      <Dialog
        open={isOpen}
        as="div"
        className="relative z-10 focus:outline-none"
        onClose={close}
      >
        {isOpen && (
          <div className="fixed inset-0 backdrop-blur-2xl bg-opacity-50 backdrop-blur-md"></div>
        )}

        <div className="fixed inset-0 z-10 w-screen overflow-y-auto">
          <div className="flex min-h-full items-center justify-center p-4">
            <DialogPanel
              transition
              className="w-400 max-w-2xl rounded-xl p-6 bg-gray-50 duration-300 ease-out data-[closed]:transform-[scale(95%)] data-[closed]:opacity-0"
            >
              <DialogTitle
                as="h3"
                className="text-base/7 font-medium text-white flex items-center justify-center"
              >
                <span className="block mb-5">Wellcome Back! </span>
              </DialogTitle>

              {renderInput}

              <div className="mt-4 flex items-center justify-center space-x-4">
                <Button onClick={handleSubmitData}>Login </Button>
                <Button color="white" onClick={close}>
                  Cancle
                </Button>
              </div>
            </DialogPanel>
          </div>
        </div>
      </Dialog>
    </>
  );
}
