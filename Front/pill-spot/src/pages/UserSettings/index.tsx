import axios from 'axios';
import { ChangeEvent, useState } from 'react'
import { Link } from 'react-router-dom'

const UserSettingMain = () => {
  const [category,setCat] = useState('');


  function handleChange(e:ChangeEvent<HTMLInputElement>){
    const {value} = e.target ;
    setCat(value);
  }

  async function handleClick(){
      const response = await axios.post('https://localhost:7298/api/categories' , { name :category}) ;
      console.log(response);
      const responseGet = await axios.get('https://localhost:7298/api/categories') ;
      console.log(responseGet.data) ;
  }

  console.log(category)


  return (
    <div>
        
      <Link to={"/pharmacyregister"} >
        register pharmacy
      </Link>

      <input type="text" onChange={handleChange} />
      <button className='btn' onClick={handleClick}>
          add category
      </button>
    </div>
  )
}

export default UserSettingMain
