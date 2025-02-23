
interface SignUpData {
  FirstName: string;
  LastName: string;
  UserName: string;
  Email: string;
  PhoneNumber: string;
  Password: string;
  ConfirmPassword: string;
  DateOfBirth: string;
  Gender: string;
  ProfilePicture : string;
}

interface ValidationResult {
  errors: Partial<Record<keyof SignUpData, string>>;
}

const defaultFromData: SignUpData = {
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

export function ValidateSignUpData(data: SignUpData): ValidationResult {
  const errors: Partial<Record<keyof SignUpData, string>> = { ...defaultFromData };

  if (!data.FirstName.trim()) {
    errors.FirstName = "First name is required.";
  } else if (!/^[A-Za-z]+$/.test(data.FirstName)) {
    errors.FirstName = "First name should only contain letters.";
  }

  if (!data.LastName.trim()) {
    errors.LastName = "Last name is required.";
  } else if (!/^[A-Za-z]+$/.test(data.LastName)) {
    errors.LastName = "Last name should only contain letters.";
  }

  if (!data.UserName.trim()) {
    errors.UserName = "Username is required.";
  }

  const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  if (!data.Email.trim()) {
    errors.Email = "Email is required.";
  } else if (!emailPattern.test(data.Email)) {
    errors.Email = "Invalid email format.";
  }

  const phonePattern = /^[0-9]{10}$/;
  if (!data.PhoneNumber.trim()) {
    errors.PhoneNumber = "Phone number is required.";
  } else if (!phonePattern.test(data.PhoneNumber)) {
    errors.PhoneNumber = "Invalid phone number. Should be 10 digits.";
  }

  const passwordPattern =
    /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$/;
  if (!data.Password.trim()) {
    errors.Password = "Password is required.";
  } else if (!passwordPattern.test(data.Password)) {
    errors.Password =
      "Password must be at least 8 characters long, include at least one lowercase letter, one uppercase letter, one number, and one special character.";
  }

  if (data.Password !== data.ConfirmPassword) {
    errors.ConfirmPassword = "Passwords do not match.";
  }

  if (!data.DateOfBirth.trim()) {
    errors.DateOfBirth = "Birth date is required.";
  }

  if (!data.Gender.trim()) {
    errors.Gender = "Gender is required.";
  }

  return { errors };
}
