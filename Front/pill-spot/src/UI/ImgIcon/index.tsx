interface Iprops{
    src:string ;
    w?:string ;
    h?:string ;
}

const ImgIcon = ({src , w="12" , h="12"}:Iprops) => {
  return (
    <>
      <div className={`mask mask-squircle h-${h} w-${w}`}>
        <img
          src={src}
          alt="Avatar Tailwind CSS Component"
        />
      </div>
    </>
  );
};

export default ImgIcon;
