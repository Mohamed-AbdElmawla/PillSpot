import { Dialog, DialogPanel, DialogTitle } from "@headlessui/react";
import { useState } from "react";
import { Button } from "../../UI/Button";
// import Input from "../../UI/Input";
import { Iprops } from "./types";
import InputIcon from "../../UI/InputIcon/InputIcon";
import { inputArr } from "./inputs";

export default function SignUpModal({ buttonText }: Iprops) {
  const [isOpen, setIsOpen] = useState(false);

  function open() {
    setIsOpen(true);
  }

  function close() {
    setIsOpen(false);
  }

  //____________Render_____________//
  const renderedInput = inputArr.map((inpt) => (
    <InputIcon
      name={inpt.name}
      placeHolder={inpt.placeHolder}
      icon={inpt.icon}
      type={inpt.type}
    />
  ));

  return (
    <>
      <Button onClick={open}>{buttonText}</Button>

      <Dialog
        open={isOpen}
        as="div"
        className="relative z-10 focus:outline-none"
        onClose={close}
        __demoMode
      >
        <div className="fixed inset-0 z-10 w-screen overflow-y-auto ">
          <div className="flex min-h-full items-center justify-center p-4">
            <DialogPanel
              transition
              className="w-400 max-w-2xl rounded-xl p-6 backdrop-blur-2xl duration-300 ease-out data-[closed]:transform-[scale(95%)] data-[closed]:opacity-0"
            >
              <DialogTitle
                as="h3"
                className="text-base/7 font-medium text-white flex items-center justify-center"
              >
                <h3 className="mb-5">Create new account</h3>
              </DialogTitle>
              <div className="flex gap-10 items-center justify-center">
                <InputIcon
                  name="firstName"
                  type="text"
                  title="First Name"
                  placeHolder="First Name"
                  icon="flname.svg"
                />
                <InputIcon
                  name="lastName"
                  type="text"
                  title="Last Name"
                  placeHolder="Last Name"
                  icon="flname.svg"
                />
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
                    />
                    Male
                  </label>
                  <label className="flex items-center gap-2 text-[#02457A]">
                    <input
                      type="radio"
                      name="gender"
                      value="female"
                      className="w-5 h-5 accent-[#02457A]"
                    />
                    Female
                  </label>
                </div>
              </div>
              <div className="mt-4 flex flex-col items-center">
                <Button onClick={close}>Submit</Button>
              </div>
            </DialogPanel>
          </div>
        </div>
      </Dialog>
    </>
  );
}
