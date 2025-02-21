interface Iprops{
    src:string ;
}

const ImgIcon = ({src}:Iprops) => {
  return (
    <>
      <div className="mask mask-squircle h-12 w-12">
        <img
          src={src}
          alt="Avatar Tailwind CSS Component"
        />
      </div>
    </>
  );
};

export default ImgIcon;
