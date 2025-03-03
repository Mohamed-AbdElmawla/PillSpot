
import { NavLink } from "react-router-dom";

interface Iprops{
    pageURL : string ; 
    children : React.ReactNode ; 
    mainColor : string ;
    title:string ;
}


const ButtenLink = ({pageURL,mainColor,children,title}:Iprops) => {
  return (
    <NavLink
      to={`${pageURL}`}
      className={({ isActive }) =>
        `rounded-bl-3xl rounded-tl-3xl duration-200  ${
          isActive ? `${mainColor} bg-white flex justify-between items-center` : "text-white"
        }`
      }
    >
    
      <div className="relative flex gap-5 h-[60px] items-center justify-start p-4 px-10 
    hover:text-cyan-500 hover:bg-white duration-200 font-bold 
    hover:rounded-bl-3xl hover:rounded-tl-3xl 
    ">
        {children}
        <div className="hidden md:block">{title}</div>

      </div>
    </NavLink>
  );
};

export default ButtenLink;
