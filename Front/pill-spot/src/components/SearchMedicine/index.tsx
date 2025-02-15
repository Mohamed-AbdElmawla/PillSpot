import Input from "../../UI/Input";
import { ChangeEvent, Dispatch, SetStateAction } from "react";

interface Iprop {
  setMedecineSearch: Dispatch<SetStateAction<string>>;
}

const SearchMedicine = ({ setMedecineSearch }: Iprop) => {
  const handleOnChnage = (
    event: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLTextAreaElement>
  ) => {
    const { value } = event.target;
    setMedecineSearch(value.toLowerCase().trim());
  };

  return (
    <div>
      <Input
        type="text"
        name=""
        placeholder="Your Medecine Name"
        value={""}
        onChange={handleOnChnage}
      />
    </div>
  );
};

export default SearchMedicine;
