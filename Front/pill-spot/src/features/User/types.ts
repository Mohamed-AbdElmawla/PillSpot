export interface IcurUser {
    firstName: string,
    lastName: string ,
    email: string,
    userName: string ,
    phoneNumber: string,
    profilePictureUrl: string,
    dateOfBirth: string,
    gender: string ,
  }
  
 export  const emptyUser : IcurUser = {
    
      firstName: "",
      lastName:  "",
      email: "",
      userName: "" ,
      phoneNumber: "",
      profilePictureUrl:"" ,
      dateOfBirth:"" ,
      gender: "" ,
    
  }
  
  // {
  //   FirstName: 'Mohamed',
  //   LastName: 'Ramadan',
  //   PhoneNumber: '1231231231',
  //   DateOfBirth: '2014-06-19',
  //   Password: '',
  //   NewPassword: ''
  // }

  export interface IeditUser  {
    FirstName : string , 
    LastName : string , 
    DateOfBirth : string ,
    PhoneNumber : string ,
  }


 