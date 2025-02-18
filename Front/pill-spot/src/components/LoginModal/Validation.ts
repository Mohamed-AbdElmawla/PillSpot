interface SignUpData {
    userName: string;
    password: string;
  }
  
  interface ValidationResult {
    errors: Partial<Record<keyof SignUpData, string>>;
  }
  
  const defaultFromData: SignUpData = {
    userName: "",
    password: "",
  };
  
  export function validateSignUpData(data: SignUpData): ValidationResult {
    let errors: Partial<Record<keyof SignUpData, string>> = {};
    errors = { ...defaultFromData };

    if (!data.userName.trim()) {
      errors.userName = "Username is required.";
    }
  
    if (!data.password.trim()) {
      errors.password = "Password is required.";
    }
  
    return { errors };
  }
  