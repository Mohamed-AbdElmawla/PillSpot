interface Iprops{
    imgSrc : string ; 
    name : string ; 
    email:string ; 
    dataColor? : string ;
}

const PharManagemetDetails = ({imgSrc,name,email,dataColor}:Iprops) => {
  const nameEmailColor = (dataColor) ? dataColor : "text-white" ;
  return (
    <div>
      <div className="flex gap-5 items-center">
        <div className="avatar">
          <div className="w-24 rounded-full">
            <img src={imgSrc} />
          </div>
        </div>
        <div className={`flex flex-col ${nameEmailColor}`}>
          <span className="font-bold text-3xl">{name}</span>
          <span className="font-bold textarea-lg">{email}</span>
        </div>
      </div>

      <div className="mt-15">
        <hr className="border-t-2 text-gray-300 my-4" />
      </div>
    </div>
  );
};

export default PharManagemetDetails;
