
interface Iprops {
  msg: string;
}

const ErrorMessage = ({ msg }: Iprops) => {
  return (
    <>
      <div
        className={`ml-5 text-red-500 font-bold transition-all duration-300 ease-in-out ${
          msg ? "opacity-100 translate-y-0" : "opacity-0 translate-y-2"
        }`}
      >
        {msg}
      </div>
    </>
  );
};

export default ErrorMessage;
