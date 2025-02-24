
interface Iprops{
    id?:string ;
    name : string ; 
    manfactr : string ;
    quantity : string ; 
    catetory:string ;
    exp : string ; 
    price : string ;
    stksts:string ;
}

export const medicines :Iprops[] = [
    { id: "1", name: "Paracetamol", manfactr: "PharmaCorp", quantity: "100", catetory: "Pain Reliever", exp: "2026-05-12", price: "5.00", stksts: "In Stock" },
    { id: "2", name: "Amoxicillin", manfactr: "MediLife", quantity: "50", catetory: "Antibiotic", exp: "2025-08-20", price: "12.50", stksts: "In Stock" },
    { id: "3", name: "Cetirizine", manfactr: "AllerMed", quantity: "30", catetory: "Antihistamine", exp: "2027-01-15", price: "7.25", stksts: "Low Stock" },
    { id: "4", name: "Omeprazole", manfactr: "GastroCare", quantity: "80", catetory: "Acid Reducer", exp: "2026-09-10", price: "10.00", stksts: "In Stock" },
    { id: "5", name: "Ibuprofen", manfactr: "HealWell", quantity: "120", catetory: "Pain Reliever", exp: "2025-11-30", price: "8.99", stksts: "In Stock" },
    { id: "6", name: "Metformin", manfactr: "DiabeCare", quantity: "200", catetory: "Diabetes Medication", exp: "2026-07-22", price: "15.75", stksts: "In Stock" },
    { id: "7", name: "Aspirin", manfactr: "CardioPharm", quantity: "60", catetory: "Blood Thinner", exp: "2025-12-05", price: "6.50", stksts: "Low Stock" },
    { id: "8", name: "Salbutamol", manfactr: "RespiraMed", quantity: "90", catetory: "Bronchodilator", exp: "2026-03-18", price: "18.00", stksts: "In Stock" },
    { id: "9", name: "Losartan", manfactr: "HyperTens", quantity: "75", catetory: "Blood Pressure", exp: "2027-06-14", price: "22.00", stksts: "In Stock" },
    { id: "10", name: "Atorvastatin", manfactr: "CholestMed", quantity: "40", catetory: "Cholesterol Control", exp: "2026-12-08", price: "20.50", stksts: "Low Stock" },
    { id: "11", name: "Paracetamol", manfactr: "PharmaCorp", quantity: "150", catetory: "Pain Reliever", exp: "2026-05-12", price: "5.50", stksts: "In Stock" },
    { id: "12", name: "Amoxicillin", manfactr: "MediLife", quantity: "45", catetory: "Antibiotic", exp: "2025-08-20", price: "12.50", stksts: "In Stock" },
    { id: "13", name: "Cetirizine", manfactr: "AllerMed", quantity: "20", catetory: "Antihistamine", exp: "2027-01-15", price: "7.25", stksts: "Low Stock" },
    { id: "14", name: "Omeprazole", manfactr: "GastroCare", quantity: "95", catetory: "Acid Reducer", exp: "2026-09-10", price: "10.00", stksts: "In Stock" },
    { id: "15", name: "Ibuprofen", manfactr: "HealWell", quantity: "130", catetory: "Pain Reliever", exp: "2025-11-30", price: "8.99", stksts: "In Stock" },
    { id: "16", name: "Metformin", manfactr: "DiabeCare", quantity: "210", catetory: "Diabetes Medication", exp: "2026-07-22", price: "15.75", stksts: "In Stock" },
    { id: "17", name: "Aspirin", manfactr: "CardioPharm", quantity: "70", catetory: "Blood Thinner", exp: "2025-12-05", price: "6.50", stksts: "Low Stock" },
    { id: "18", name: "Salbutamol", manfactr: "RespiraMed", quantity: "80", catetory: "Bronchodilator", exp: "2026-03-18", price: "18.00", stksts: "In Stock" },
    { id: "19", name: "Losartan", manfactr: "HyperTens", quantity: "85", catetory: "Blood Pressure", exp: "2027-06-14", price: "22.00", stksts: "In Stock" },
    { id: "20", name: "Atorvastatin", manfactr: "CholestMed", quantity: "50", catetory: "Cholesterol Control", exp: "2026-12-08", price: "20.50", stksts: "No Stock" },
  ];