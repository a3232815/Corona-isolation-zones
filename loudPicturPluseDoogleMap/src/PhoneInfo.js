// import React, { useState, useEffect } from 'react';
// import axios from 'axios';

// function PhoneInfo() {
//   const [phoneNumber, setPhoneNumber] = useState('');

//   useEffect(() => {
//     axios.get('https://api.example.com/phone-number')
//       .then(response => {
//         setPhoneNumber(response.data.phone_number);
//       })
//       .catch(error => {
//         console.log(error);
//       });
//   }, []);

//   return (
//     <div>
//       <p>Your phone number is: {phoneNumber}</p>
//     </div>
//   );
// }

// export default PhoneInfo;
import React, { useState, useEffect } from 'react';
import axios from 'axios';

function PhoneInfo() {
  const [phoneNumber, setPhoneNumber] = useState('');

  useEffect(() => {
    const apiKey = 'your_api_key_here';
    const apiUrl = `https://www.gov.il/api/phones/search.json?apikey=${apiKey}&q=משפחת כהן`;
    axios.get(apiUrl)
      .then(response => {
        setPhoneNumber(response.data[0].phones[0].phone_number);
      })
      .catch(error => {
        console.log(error);
      });
  }, []);

  return (
    <div>
      <p>Your phone number is: {phoneNumber}</p>
    </div>
  );
}

export default PhoneInfo;
