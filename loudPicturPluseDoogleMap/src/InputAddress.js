import React, { useState } from 'react';
import { GoogleMap, useLoadScript } from '@react-google-maps/api';

const libraries = ['places'];
const mapContainerStyle = { width: '100%', height: '400px' };
const center = { lat: 32.0853, lng: 34.7818 };
const options = { disableDefaultUI: true, zoomControl: true };

function InputAddress() {
  const [address, setAddress] = useState('');
  const [coordinates, setCoordinates] = useState(center);

  const { isLoaded, loadError } = useLoadScript({
    googleMapsApiKey: 'AIzaSyB1lL3LLPiOURiFC9xe-Qkp-Z4vEZWuYwo',
    libraries,
  });

  const handleAddressChange = (event) => {
    setAddress(event.target.value);
  };

  const handleAddressSubmit = (event) => {
    event.preventDefault();
    const geocoder = new window.google.maps.Geocoder();
    geocoder.geocode({ address: address }, (results, status) => {
      if (status === 'OK') {
        const { lat, lng } = results[0].geometry.location;
        setCoordinates({ lat: lat(), lng: lng() });
      } else {
        alert('Geocode was not successful for the following reason: ' + status);
      }
    });
  };

  if (loadError) return <div>Map cannot be loaded right now, sorry.</div>;

  return isLoaded ? (
    <div>
      <form onSubmit={handleAddressSubmit}>
        <label>
          Enter Address:
          <input type="text" value={address} onChange={handleAddressChange} />
        </label>
        <button type="submit">Submit</button>
      </form>
      <GoogleMap
        mapContainerStyle={mapContainerStyle}
        zoom={20}
        center={coordinates}
        options={options}
      />
    </div>
  ) : (
    <div>Loading Map...</div>
  );
}

export default InputAddress;

