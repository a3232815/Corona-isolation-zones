import { useState } from 'react';
import { GoogleMap, Marker, useJsApiLoader } from '@react-google-maps/api';

const libraries = ['places'];
//size of display map
const containerStyle = {
  width: '1000px',
  height: '1000px'
};


//Location on the world map
const center = {
  // The wind line of some geographical location on Earth
  lat: 51.5074,
  // The longitude of some geographic location on Earth
  lng: -0.1278
};
const options = { disableDefaultUI: true, zoomControl: true };

function Map() {
  const [markerPosition, setMarkerPosition] = useState(center);
  const [address, setAddress] = useState('');
  // const [coordinates, setCoordinates] = useState(center);

  // A map loading hook that is part of the library '@react-google-maps/api'
  const { isLoaded , loadError } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: 'AIzaSyB1lL3LLPiOURiFC9xe-Qkp-Z4vEZWuYwo',
    libraries,
  });

  //A function that receives a location on the world map and moves the icon of the location there
  const changeLocation = (event) => {
    const { latLng } = event;
    setMarkerPosition({      
      lat: latLng.lat(),
      lng: latLng.lng()
    });
  };

const handleAddressChange = (event) => {
    setAddress(event.target.value);
  };

  const handleAddressSubmit = (event) => {
    event.preventDefault();
    const geocoder = new window.google.maps.Geocoder();
    geocoder.geocode({ address: address }, (results, status) => {
      if (status === 'OK') {
        const { lat, lng } = results[0].geometry.location;
        setMarkerPosition({ lat: lat(), lng: lng() });
      } else {
        alert('Geocode was not successful for the following reason: ' + status);
      }
    });
  };

  if (loadError) return <div>Map cannot be loaded right now, sorry.</div>;


  return isLoaded ? (
    <>
    <form onSubmit={handleAddressSubmit}>
        <label>
          Enter Address:
          <input type="text" value={address} onChange={handleAddressChange} />
        </label>
        <button type="submit">Submit</button>
      </form>
    <GoogleMap
      id="map"
      mapContainerStyle={containerStyle}
      center={markerPosition}
      zoom={12}
      onClick={changeLocation}
      options={options}
    >
      <Marker position={markerPosition} />
    </GoogleMap></>
  ) : <></>;
}

export default Map;