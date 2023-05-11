import { useState } from 'react';
import { GoogleMap, Marker, useJsApiLoader } from '@react-google-maps/api';


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

function Map() {
  const [markerPosition, setMarkerPosition] = useState(center);

  // A map loading hook that is part of the library '@react-google-maps/api'
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: 'AIzaSyB1lL3LLPiOURiFC9xe-Qkp-Z4vEZWuYwo'
  });

  //A function that receives a location on the world map and moves the icon of the location there
  const changeLocation = (event) => {
    const { latLng } = event;
    setMarkerPosition({      
      lat: latLng.lat(),
      lng: latLng.lng()
    });
  };

  return isLoaded ? (
    <GoogleMap
      id="map"
      mapContainerStyle={containerStyle}
      center={center}
      zoom={12}
      onClick={changeLocation}
    >
      <Marker position={markerPosition} />
    </GoogleMap>
  ) : <></>;
}

export default Map;