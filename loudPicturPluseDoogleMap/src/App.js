import React from 'react';
import { GoogleMap, LoadScript } from '@react-google-maps/api';
import Map from './siluv';
import InputAddress from './InputAddress'
import PhoneInfo from './PhoneInfo'
import ImageUploader from './ImageUploader'

function App() {
  return (
    <div>
      <Map></Map>
      <PhoneInfo></PhoneInfo>
      {/* <InputAddress></InputAddress> */}
      <ImageUploader></ImageUploader>
    </div>
  )
}

export default App;
