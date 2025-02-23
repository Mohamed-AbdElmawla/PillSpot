import React from "react";

interface Iprops{
    details:string ;
    children : React.ReactNode ;
}


const Padge = ({details,children}:Iprops) => {
  return <div className="badge badge-soft badge-neutral">
    {children}
    {details} 
  </div>;
};

export default Padge;
