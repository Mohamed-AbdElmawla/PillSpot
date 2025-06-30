

// this input for the add medecine 
export const InputNames = {
  MedicineName: "MedicineName",
  Manufacturer: "Manufacturer",
  Quantity: "Quantity",
  Category: "Category",
  exp: "exp",
  price: "price",
} as const;


export const InputStaff = {
  JobTitle : "JobTitle" , 
  PhoneNumber : "PhoneNumber", 
  Email : "Email"
} as const ;


// interface IMedicine {
//   MedicineName: string;
//   Manufacturer: string;
//   Quantity: string;
//   Category: "cate1" | "cate2" | "cate3" | "cate4";
// }

interface IStaffInput {
  name: string;
  type: string ; 
  title : string ;
}

interface IMedicineInputs {
  name: string;
  type: string ; 
  title : string ;
  options? : string[] ;
}

export const addMedicine: IMedicineInputs[] = [
  { name: InputNames.MedicineName, type: "text" , title : "Medicine Name"},
  { name: InputNames.Manufacturer, type: "text" , title : "Manufacturer"},
  { name: InputNames.Quantity, type: "text" , title : "Quantity"},
  { name: InputNames.Category, type: "list" , title : "Category" , options : ['cate1' , 'cate2' , 'cate3']},
  { name: InputNames.exp, type: "date" , title : "Expiration Date"},
  { name: InputNames.price, type: "text" , title : "Price"},
];


export const addEmployee : IStaffInput[] = [{name:InputStaff.Email,type:"text",title:"User Name"}] ;
export const editEmployee : IStaffInput[] = [
  {name:InputStaff.JobTitle,type:"text",title:"Jop Title"},
  {name:InputStaff.PhoneNumber,type:"text",title:"Phone Number"},
] ;