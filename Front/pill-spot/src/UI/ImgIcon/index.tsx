interface Iprops{
    src:string ;
    w?:string ;
    h?:string ;
}

const ImgIcon = ({src , w="12" }:Iprops) => {
  return (
    <>
      <div className={`mask mask-squircle`}>
        <img
          src={src}
          alt="Avatar Tailwind CSS Component"
        />
      </div>
    </>
  );
};

export default ImgIcon;
