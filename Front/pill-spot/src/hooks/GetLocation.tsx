import { useEffect, useState } from 'react';

interface Coordinates {
  lat: number | null;
  lng: number | null;
}

function useGeolocation(): Coordinates {
  const [coords, setCoords] = useState<Coordinates>({ lat: null, lng: null });

  useEffect(() => {
    if (!navigator.geolocation) return;

    navigator.geolocation.getCurrentPosition(
      (position) => {
        setCoords({
          lat: position.coords.latitude,
          lng: position.coords.longitude,
        });
      },
      () => {
        setCoords({ lat: null, lng: null }); 
      }
    );
  }, []);

  return coords;
}

export default useGeolocation;
