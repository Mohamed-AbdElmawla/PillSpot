interface IProps {
  imgSrc: string | undefined;
  name: string | undefined;
  email: string | undefined;
  dataColor?: string;
}

const PharManagemetDetails = ({ imgSrc, name, email, dataColor }: IProps) => {
  const nameEmailColor = dataColor ? dataColor : "text-white";

  return (
    <div className="p-4">
      <div className="flex items-center gap-3 sm:gap-5">
        <div className="avatar">
          <div className="w-16 sm:w-24 rounded-full">
            <img src={`${import.meta.env.VITE_BASE_URL}${imgSrc}`} alt="Profile" />
          </div>
        </div>

        <div className={`hidden md:flex flex-col ${nameEmailColor}`}>
          <span className="font-bold text-xl sm:text-3xl">{name}</span>
          <span className="font-bold text-sm sm:text-lg">{email}</span>
        </div>
      </div>

      <div className="mt-6 sm:mt-10">
        <hr className="border-t-2 text-gray-300 my-4" />
      </div>
    </div>
  );
};

export default PharManagemetDetails;
