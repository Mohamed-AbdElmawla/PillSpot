import { Dialog, DialogPanel, DialogTitle } from "@headlessui/react";
import { useState } from "react";
import { Button } from "../../UI/Button";
import InputIcon from "../../UI/InputIcon/InputIcon";
import { defaultFromData, emptyFormData, inputArr } from "./data";
import { Iprops } from "./types";
// import { v4 as uuid } from "uuid";
import { ChangeEvent } from "react";
import { validateSignUpData } from "./Validation";
import { SvgIcon } from "../../UI/SvgIcon";

export default function SignUpModal({ buttonText }: Iprops) {
  //____________________ states ______________________ //
  const [isOpen, setIsOpen] = useState(false);
  const [signUpData, setSignUpData] = useState({ ...defaultFromData });
  console.log("SIgn up data is ", signUpData);
  //___________________________Handlers______________________________//

  function handleSubmitData() {
    // first do validation
    // if there any error return error element
    // if there is no errors send the data

    const obj = validateSignUpData(signUpData);
    const isValid = Object.values(obj.errors).every((error) => error === "");
    if (isValid) {
      console.log("Form submitted with data: ", signUpData);
    } else {
      console.log("THere is errors : ", obj);
    }
  }

  function open() {
    setIsOpen(true);
  }

  function close() {
    setIsOpen(false);
    setSignUpData(emptyFormData);
  }

  function handleChange(event: ChangeEvent<HTMLInputElement>) {
    const { name, value } = event.target;
    // console.log("Changing:", name, value);
    setSignUpData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  //_________________________Render_______________________________//
  const renderedInput = inputArr.map((inpt) => (
    <div className="relative flex items-center m-5" key={inpt.name+"cleeXlrrmMdLg"}>
      <span className="absolute left-3 text-[#02457A]">
        <SvgIcon width="30" height="30" src={inpt.icon} />
      </span>

      <InputIcon
        
        name={inpt.name}
        placeholder={inpt.placeHolder}
        type={inpt.type}
        onChange={handleChange}
        value={signUpData[inpt.name]}
      />
    </div>
  ));

  return (
    <>
      <Button onClick={open}>{buttonText}</Button>

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
                <span className="block mb-5">Create new account</span>
              </DialogTitle>

              <div className="flex gap-10 items-center justify-center">
                <div className="relative flex items-center m-5">
                  <span className="absolute left-3 text-[#02457A]">
                    <SvgIcon width="30" height="30" src="flname.svg" />
                  </span>
                  <InputIcon
                    name="firstName"
                    type="text"
                    title="First Name"
                    placeholder="First Name"
                    onChange={handleChange}
                    value={signUpData["firstName"]}
                  />
                </div>

                <div className="relative flex items-center m-5">
                  <span className="absolute left-3 text-[#02457A]">
                    <SvgIcon width="30" height="30" src="flname.svg" />
                  </span>
                  <InputIcon
                    name="lastName"
                    type="text"
                    title="Last Name"
                    placeholder="Last Name"
                    onChange={handleChange}
                    value={signUpData["lastName"]}
                  />
                </div>
              </div>

              {renderedInput}

              <div className="flex flex-col items-center">
                <div className="flex gap-6">
                  <label className="flex items-center gap-2 text-[#02457A]">
                    <input
                      type="radio"
                      name="gender"
                      value="male"
                      className="w-5 h-5 accent-[#02457A]"
                      onChange={handleChange}
                    />
                    Male
                  </label>
                  <label className="flex items-center gap-2 text-[#02457A]">
                    <input
                      type="radio"
                      name="gender"
                      value="female"
                      className="w-5 h-5 accent-[#02457A]"
                      onChange={handleChange}
                    />
                    Female
                  </label>
                </div>
              </div>

              <div className="mt-4 flex items-center justify-center space-x-4">
                <Button onClick={handleSubmitData}>SignUp </Button>
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
