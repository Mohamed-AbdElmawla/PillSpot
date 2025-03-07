import img from "../../../assets/image.png";

const MedcineCard = () => {
  return (
    <div className="flex bg-white p-3 rounded-3xl items-center">
      <div>
        <img src={img} alt="medicine image" className="w-20 h-20 rounded-2xl" />
      </div>
      <div className="flex mx-5  gap-10">
        <div className="flex flex-col items-start justify-center">
          <div className="capitalize font-bold text-xl text-[#2e78b4]">
            name name
          </div>
          <div className="capitalize font-bold text-md text-[#2e78b4]">
            category
          </div>
        </div>
        <div className="flex gap-3 flex-col">
          <div className="badge badge-soft badge-info font-bold p-3">
            ADO : 40
          </div>
          <div className="badge badge-soft badge-info font-bold p-3">
            WDO : 20
          </div>
        </div>
      </div>
    </div>
  );
};

export default MedcineCard;
