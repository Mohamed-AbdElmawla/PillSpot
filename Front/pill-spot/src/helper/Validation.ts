type ValidationType = "name" | "password" | "userName" | "phoneNumber";

export const validateInput = (value: string, type: ValidationType): string | null => {
  if (!value.trim()) {
    return `${type} cannot be empty.`;
  }

  switch (type) {
    case "name":
      if (!/^[A-Za-z\s]+$/.test(value)) {
        return "Name can only contain letters and spaces.";
      }
      if (value.length < 3 || value.length > 50) {
        return "Name must be between 3 and 50 characters.";
      }
      break;

    case "userName":
      if (!/^[a-zA-Z0-9_]+$/.test(value)) {
        return "Username can only contain letters, numbers, and underscores.";
      }
      if (value.length < 3 || value.length > 20) {
        return "Username must be between 3 and 20 characters.";
      }
      break;

    case "password":
      if (value.length < 8) {
        return "Password must be at least 8 characters long.";
      }
      if (!/[A-Z]/.test(value)) {
        return "Password must contain at least one uppercase letter.";
      }
      if (!/[a-z]/.test(value)) {
        return "Password must contain at least one lowercase letter.";
      }
      if (!/[0-9]/.test(value)) {
        return "Password must contain at least one number.";
      }
      if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) {
        return "Password must contain at least one special character.";
      }
      break;

    case "phoneNumber":
      if (!/^\d{11}$/.test(value)) {
        return "Phone number must be exactly 11 digits.";
      }
      break;
  }

  return null;
};
