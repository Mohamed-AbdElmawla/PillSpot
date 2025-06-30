import { Dialog, DialogPanel, DialogTitle } from "@headlessui/react";
import { useEffect, useState } from "react";
import { Button } from "../../UI/Button";
import InputIcon from "../../UI/InputIcon/InputIcon";
import {
  convertToFormData,
  defaultFromData,
  emptyFormData,
  inputArr,
} from "./data";
import { Iprops, IState } from "./types";
// import { v4 as uuid } from "uuid";
import { ChangeEvent } from "react";
import { ValidateSignUpData } from "./Validation";
import { SvgIcon } from "../../UI/SvgIcon";
import ErrorMessage from "../ErrorMessage/ErrorMessage";
import { useSelector, useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { register, reset } from "../../features/auth/auth";
import { RootState, AppDispatch } from "../../app/store";
import ImageUpload from "../../UI/ImageUpload";
import { clearProfilePicture } from "../../features/uploadPhoto/upload";
import { toast } from "sonner";
import { setColor} from "../../features/Toasts/toastSlice";












export default function SignUpModal({ buttonText }: Iprops) {
  //____________________ states ______________________ //

  const [isOpen, setIsOpen] = useState(false);
  const [signUpData, setSignUpData] = useState({ ...defaultFromData });
  const [errorMsgs, setErrors] = useState({ ...defaultFromData });
  const [gender, setGender] = useState("");

  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  const dispatch1 = useDispatch<AppDispatch>();

  const userState: IState = useSelector((state: RootState) => state.auth);
  // const toastState = useSelector((state:RootState)=>state.toastSlice) ;
  const userImage = useSelector(
    (state: RootState) => state.imgaeUploadSlice.profilePicture
  );

  //__________________useEffects_____________________________//

  useEffect(() => {
    if (userState.isError) {
      console.log("there is an error : ", userState.message);
    }

    if (userState.isSuccess || userState.user) {
       dispatch(setColor());
       
       toast.success("Account Created Successfully") ;
      
      navigate("/homepage");
    }

    dispatch(reset());
  }, [
    userState.isError,
    userState.isSuccess,
    userState.user,
    userState.message,
    navigate,
    dispatch,
  ]);

  // useEffect(()=>{
  //   if(toastState.signUpState===1){
  //     toast.success("Account Created Successfully") ;
  //   } else if(toastState.signUpState === 2){
  //     toast.error("An error occured") ;
  //   }
  // },[toastState.signUpState,dispatch])

  //___________________________Handlers______________________________//

  function handleSubmitData() {
    const obj = ValidateSignUpData(signUpData);

    if (!userImage) {
      obj.errors.ProfilePicture = "Profile Picture is required";
    }

    const isValid = Object.values(obj.errors).every((error) => error === "");
  
    if (isValid) {
      console.log("Form submitted with data: ", signUpData);
      console.log(userImage);
      const formData = convertToFormData(signUpData);
      if (userImage !== null) {
        formData.append("ProfilePicture", userImage);
      }
      dispatch(register(formData));
    } else {
      setErrors((prev) => ({ ...prev, ...obj.errors }));
      dispatch(setColor()) ;
      toast.error('Invalid Data');
      console.log("THere is errors : ", obj);
    }
  }

  function open() {
    setIsOpen(true);
  }

  function close() {
    setSignUpData(emptyFormData);
    setErrors(emptyFormData);
    setIsOpen(false);
    dispatch1(clearProfilePicture());
  }

  function handleChange(
    event: ChangeEvent<HTMLSelectElement | HTMLInputElement>
  ) {
    const { name, value } = event.target;
    // console.log("Changing:", name, value);
    setErrors((prev) => ({ ...prev, [name]: "" }));
    setSignUpData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  //_________________________Render_______________________________//

  const renderedInput = inputArr.map((inpt) => (
    <div key={inpt.name + "cleeXlrrmMdLg"}>
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
          value={signUpData[inpt.name]}
        />
      </div>
      <ErrorMessage msg={errorMsgs[inpt.name]} />
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
          <div className="fixed inset-0 bg-opacity-50 backdrop-blur-md"></div>
        )}

        <div className="fixed inset-0 z-10 w-screen overflow-y-auto">
          <div className="flex min-h-full items-center justify-center p-4">
            <DialogPanel
              transition
              className="w-400 max-w-2xl rounded-xl p-6 bg-gray-50 duration-300 ease-out data-[closed]:transform-[scale(95%)] data-[closed]:opacity-0"
            >
              {userState.isLoading ? (
                <span className="loading loading-ring w-75"></span>
              ) : (
                <>
                  <DialogTitle
                    as="h3"
                    className="text-base/7 font-medium text-white flex items-center justify-center"
                  >
                    <span className="block mb-5">Create new account</span>
                  </DialogTitle>

                  <div className="flex flex-col items-center">
                    <ImageUpload />
                    <div className="text-red-500 font-bold mb-5">
                      {errorMsgs["ProfilePicture"]}
                    </div>
                  </div>
                  <div className="flex gap-2">
                    <div className="flex flex-col w-1/2">
                      <div
                        className={`relative flex items-center w-full transition-all duration-300 ease-in-out ${
                          errorMsgs["FirstName"]
                            ? "border-2 border-red-500 rounded-lg"
                            : ""
                        }`}
                      >
                        <span className="absolute left-3 text-[#02457A]">
                          <SvgIcon width="30" height="30" src="flname.svg" />
                        </span>
                        <InputIcon
                          className="w-full indent-9 text-[#02457A] font-bold"
                          name="FirstName"
                          type="text"
                          title="First Name"
                          placeholder="First Name"
                          onChange={handleChange}
                          value={signUpData["FirstName"]}
                        />
                      </div>
                      <div className="text-red-500 font-bold">
                        {errorMsgs["FirstName"]}
                      </div>
                    </div>

                    <div className="flex flex-col w-1/2">
                      <div
                        className={`relative flex items-center w-full transition-all duration-300 ease-in-out ${
                          errorMsgs["LastName"]
                            ? "border-2 border-red-500 rounded-lg"
                            : ""
                        }`}
                      >
                        <span className="absolute left-3 text-[#02457A]">
                          <SvgIcon width="30" height="30" src="flname.svg" />
                        </span>
                        <InputIcon
                          className="w-full indent-9 text-[#02457A] font-bold"
                          name="LastName"
                          type="text"
                          title="Last Name"
                          placeholder="Last Name"
                          onChange={handleChange}
                          value={signUpData["LastName"]}
                        />
                      </div>
                      <div className="text-red-500 font-bold">
                        {errorMsgs["LastName"]}
                      </div>
                    </div>
                  </div>

                  {renderedInput}

                  <div className="flex flex-col items-center font-bold">
                    <select
                      name="Gender"
                      className="w-full p-2 border-2 border-gray-100 bg-gray-100 focus:border-gray-300 rounded-lg text-[#02457A] focus:outline-none"
                      value={gender}
                      onChange={(e) => {
                        setGender(e.target.value);
                        handleChange(e);
                      }}
                    >
                      <option value="" disabled>
                        Select Gender
                      </option>
                      <option value="male">Male</option>
                      <option value="female">Female</option>
                    </select>
                    <div className="text-red-500 font-bold">
                      {errorMsgs["Gender"]}
                    </div>
                  </div>
                  <div className="mt-4 flex items-center justify-center space-x-4">
                    <Button onClick={handleSubmitData}>SignUp </Button>
                    <Button color="white" onClick={close}>
                      Cancle
                    </Button>
                  </div>
                </>
              )}
            </DialogPanel>
          </div>
        </div>
      </Dialog>
    </>
  );
}
