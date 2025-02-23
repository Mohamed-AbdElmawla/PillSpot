import { InputData, ISignUpData } from "./types";

export const inputArr: InputData[] = [
    {
      placeHolder: "User Name",
      type: "text",
      icon: "username.svg",
      name: "UserName",
    },
    {
      title: "Email",
      placeHolder: "Email",
      type: "text",
      icon: "email.svg",
      name: "Email",
    },
    {
      placeHolder: "Phone Number",
      type: "text",
      icon: "phone.svg",
      name: "PhoneNumber",
    },
    {
      placeHolder: "Password",
      type: "password",
      icon: "pass.svg",
      name: "Password",
    },
    {
      placeHolder: "Confirm Password",
      type: "password",
      icon: "confirmpass.svg",
      name: "ConfirmPassword",
    },
    {
      type: "date",
      icon: "birth.svg",
      name: "DateOfBirth",
      placeHolder: "",
    },
  ];
  

export const defaultFromData: ISignUpData = {
  FirstName: "",
  LastName: "",
  UserName: "",
  Email: "",
  PhoneNumber: "",
  Password: "",
  ConfirmPassword: "",
  DateOfBirth: "",
  Gender: "",
  ProfilePicture :"",

};

export const emptyFormData: ISignUpData = {
    FirstName: "",
    LastName: "",
    UserName: "",
    Email: "",
    PhoneNumber: "",
    Password: "",
    ConfirmPassword: "",
    DateOfBirth: "",
    Gender: "",
    ProfilePicture : "" , 
};


export const convertToFormData = (data: ISignUpData): FormData => {
    const formData = new FormData();

    Object.entries(data).forEach(([key, value]) => {
        if (value !== undefined && value !== null) {
            formData.append(key, value);
        }
    });

    return formData;
};