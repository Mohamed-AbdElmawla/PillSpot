
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
        `rounded-3xl duration-200 ${
          isActive ? `${mainColor} bg-white` : "text-amber-50"
        }`
      }
    >
      <div className="flex gap-5 h-[60px] items-center rounded-3xl justify-start p-4  hover:text-cyan-500 hover:bg-white duration-200 font-bold">
        {children}
        <div>{title}</div>
      </div>
    </NavLink>
  );
};

export default ButtenLink;
