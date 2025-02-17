interface SignUpData {
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    phoneNumber: string;
    password: string;
    confirmPassword: string;
    age: string;
    accountImage: string;
    birthDate: string;
    gender: string;
  }
  
  interface ValidationResult {
    errors: Partial<Record<keyof SignUpData, string>>;
  }
  
  export const defaultFromData: SignUpData = {
    firstName: "",
    lastName: "",
    userName: "",
    email: "",
    phoneNumber: "",
    password: "",
    confirmPassword: "",
    age: "",
    accountImage: "",
    birthDate: "",
    gender: ""
  };


  export function validateSignUpData(data: SignUpData): ValidationResult {
    let errors: Partial<Record<keyof SignUpData, string>> = {};
    errors = {...defaultFromData} ;

    if (!data.firstName.trim()) {
      errors.firstName = "First name is required.";
    } else if (!/^[A-Za-z]+$/.test(data.firstName)) {
      errors.firstName = "First name should only contain letters.";
    }
  
    if (!data.lastName.trim()) {
      errors.lastName = "Last name is required.";
    } else if (!/^[A-Za-z]+$/.test(data.lastName)) {
      errors.lastName = "Last name should only contain letters.";
    }
  
    if (!data.userName.trim()) {
      errors.userName = "Username is required.";
    }
  
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (!data.email.trim()) {
      errors.email = "Email is required.";
    } else if (!emailPattern.test(data.email)) {
      errors.email = "Invalid email format.";
    }
  
    const phonePattern = /^[0-9]{10}$/;
    if (!data.phoneNumber.trim()) {
      errors.phoneNumber = "Phone number is required.";
    } else if (!phonePattern.test(data.phoneNumber)) {
      errors.phoneNumber = "Invalid phone number. Should be 10 digits.";
    }
  
    const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$/;
    if (!data.password.trim()) {
      errors.password = "Password is required.";
    } else if (!passwordPattern.test(data.password)) {
      errors.password = "Password must be at least 8 characters long, include at least one lowercase letter, one uppercase letter, one number, and one special character.";
    }
  
    if (data.password !== data.confirmPassword) {
      errors.confirmPassword = "Passwords do not match.";
    }
  
    const age = parseInt(data.age, 10);
    if (!data.age.trim()) {
      errors.age = "Age is required.";
    } else if (isNaN(age)) {
      errors.age = "Age must be a valid number.";
    } else if (age < 6 || age > 90) {
      errors.age = "Age must be between 6 and 90.";
    }
  
    if (!data.accountImage.trim()) {
      errors.accountImage = "Account image is required.";
    }
  
    if (!data.birthDate.trim()) {
      errors.birthDate = "Birth date is required.";
    }
  
    if (!data.gender.trim()) {
      errors.gender = "Gender is required.";
    }
    
  
    return { errors };
  }
  