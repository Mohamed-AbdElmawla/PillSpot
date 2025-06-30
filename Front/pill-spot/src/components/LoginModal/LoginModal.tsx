import { Dialog, DialogPanel, DialogTitle } from "@headlessui/react";
import { useEffect, useState } from "react";
import { Button } from "../../UI/Button";
import InputIcon from "../../UI/InputIcon/InputIcon";
import { Iprops } from "./types";
// import { v4 as uuid } from "uuid";
import { ChangeEvent } from "react";

import { SvgIcon } from "../../UI/SvgIcon";
import ErrorMessage from "../ErrorMessage/ErrorMessage";
import { emptyLoginData, defaultErrorMsgs, inputArr } from "./data";
import { validateSignUpData } from "./Validation";
import ContWith from "./ContinueWith/ContWith";
import { useDispatch, useSelector } from "react-redux";
import { login, resetLogin } from "../../features/auth/authLogin";
import { AppDispatch, RootState } from "../../app/store";
import { toast } from "sonner";
import {
  setColor
} from "../../features/Toasts/toastSlice";
import { useNavigate } from "react-router-dom";
import { FetchHomeCategory, FetchHomeProducts } from "../../features/HomePage/Products/fetchProdcuts";

export default function LoginModal({ buttonText }: Iprops) {
  //____________________ states ______________________ //

  const [isOpen, setIsOpen] = useState(false);
  const [logInData, setlogInData] = useState(emptyLoginData);
  const [errorMsgs, setErrors] = useState(defaultErrorMsgs);
  const dispatch = useDispatch<AppDispatch>();
  const userState = useSelector((state: RootState) => state.authLogin);
  const navigate = useNavigate();

  useEffect(() => {
    if (userState.isErrorLogin) {
      dispatch(setColor());
      toast.error("Invalid Credentials");
      console.log("there is an error : ", userState.messageLogin);
    }

    if (userState.isSuccessLogin) {
      dispatch(setColor());
      dispatch(FetchHomeProducts({PageNumber:"1",PageSize:"12"}));
      dispatch(FetchHomeCategory());
      toast.success("Welcome Back!");
      // if(userState.userLogin === 'superadmin'){
      //   navigate("/tempAdminPage")
      //   return ;
      // }

      navigate("/homepage");
      console.log(userState.userLogin);
    }
    dispatch(resetLogin());
  }, [
    userState.isErrorLogin,
    userState.isSuccessLogin,
    userState.userLogin,
    userState.messageLogin,
    navigate,
    dispatch,
  ]);

  //___________________________Handlers______________________________//

  function handleSubmitData() {
    const obj = validateSignUpData(logInData);
    const isValid = Object.values(obj.errors).every((error) => error === "");
    if (isValid) {
      console.log("Form submitted with data: ", logInData);
      dispatch(login(logInData));
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

  //_________________________Render_______________________________//

  const renderInput = inputArr.map((inpt) => (
    <div key={inpt.name + "cleeXlMdLg"} className="container">
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
      <Button color="white" onClick={open}>
        {buttonText}
      </Button>

      <Dialog
        open={isOpen}
        as="div"
        className="relative z-10 focus:outline-none"
        onClose={close}
      >
        {isOpen && (
          <div className="fixed inset-0 bg-black/50 backdrop-blur-md"></div>
        )}

        <div className="fixed inset-0 z-10 w-screen flex items-center justify-center p-4">
          <DialogPanel
            transition
            className="w-full max-w-md sm:max-w-xl md:max-w-2xl lg:max-w-3xl min-h-[60vh] md:min-h-[70vh] lg:min-h-[80vh] rounded-xl p-4 sm:p-6 bg-gray-50 duration-300 ease-out transform scale-100 data-[closed]:scale-95 data-[closed]:opacity-0 flex flex-col justify-between"
          >
            {userState.isLoadingLogin ? (
              <div className="loading loading-ring w-75 m-auto"></div>
            ) : (
              <>
                <div className="flex flex-col my-auto gap-3">
                  <DialogTitle
                    as="h3"
                    className="text-lg sm:text-xl font-medium text-gray-900 flex items-center justify-center"
                  >
                    <span className="block mb-4">Welcome Back!</span> 
                  </DialogTitle>
               

                  {renderInput}
                 

                  <div className="mt-4 flex flex-wrap items-center justify-center gap-4">
                    <Button onClick={handleSubmitData}>Login</Button>
                    <Button color="white" onClick={close}>
                      Cancel
                    </Button>
                  </div>
                </div>

                <div className="mt-auto flex flex-col items-center mb-13">
                  <ContWith />
                </div>
              </>
            )}
          </DialogPanel>
        </div>
      </Dialog>
    </>
  );
}
