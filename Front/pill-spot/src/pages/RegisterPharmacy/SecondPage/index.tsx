import { useEffect, useRef, useState } from "react";
import maplibregl from "maplibre-gl";
import "maplibre-gl/dist/maplibre-gl.css";
import axios from "axios";
import { useDispatch, useSelector } from "react-redux";
import { setLocationInfo } from "../../../features/Pharmacy/Register/PharmacyRegisterSlice";
import { RootState } from "../../../app/store";

const Map = () => {
  const mapContainer = useRef<HTMLDivElement>(null);
  const [selectedLocation, setSelectedLocation] = useState<{ lat: number; lng: number } | null>(null);
  const [location, setLocationState] = useState({ CityName: "", GovernmentName: "" });
  const markerRef = useRef<maplibregl.Marker | null>(null);

  const dispatch = useDispatch();
  const PharRegData = useSelector((state: RootState) => state.pharRegister);


  useEffect(() => {
    if (selectedLocation) {
      dispatch(
        setLocationInfo({
          ...PharRegData,
          ...location,
          Longitude: selectedLocation.lng.toString(),
          Latitude: selectedLocation.lat.toString(),
        })
      );
    }
  }, [selectedLocation, location, dispatch]);

  useEffect(() => {
    if (!mapContainer.current) return;

    const map = new maplibregl.Map({
      container: mapContainer.current,
      style: {
        version: 8,
        sources: {
          osm: {
            type: "raster",
            tiles: ["https://a.tile.openstreetmap.org/{z}/{x}/{y}.png"],
            tileSize: 256,
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
          },
        },
        layers: [
          {
            id: "osm-layer",
            type: "raster",
            source: "osm",
            minzoom: 0,
            maxzoom: 19,
          },
        ],
      },
      center: [PharRegData.Longitude ? parseFloat(PharRegData.Longitude) : 30.0444, 
               PharRegData.Latitude ? parseFloat(PharRegData.Latitude) : 31.2357],
      zoom: 12,
    });

    map.addControl(new maplibregl.NavigationControl(), "top-right");

    if (PharRegData.Longitude && PharRegData.Latitude) {
      const storedLocation = { lng: parseFloat(PharRegData.Longitude), lat: parseFloat(PharRegData.Latitude) };
      setSelectedLocation(storedLocation);

      markerRef.current = new maplibregl.Marker({ color: "blue" })
        .setLngLat([storedLocation.lng, storedLocation.lat])
        .setPopup(new maplibregl.Popup().setText(`Lat: ${storedLocation.lat}, Lng: ${storedLocation.lng}`))
        .addTo(map)
        .togglePopup();
    }

    map.on("click", (e) => {
      const { lng, lat } = e.lngLat;
      setSelectedLocation({ lat, lng });

      if (markerRef.current) markerRef.current.remove();

      markerRef.current = new maplibregl.Marker({ color: "blue" })
        .setLngLat([lng, lat])
        .setPopup(new maplibregl.Popup().setText(`Lat: ${lat.toFixed(5)}, Lng: ${lng.toFixed(5)}`))
        .addTo(map)
        .togglePopup();
    });

    return () => map.remove();
  }, [PharRegData.Longitude, PharRegData.Latitude]);

  useEffect(() => {
    if (!selectedLocation) return;

    const fetchLocation = async () => {
      try {
        const response = await axios.get(
          `https://api.opencagedata.com/geocode/v1/json?q=${selectedLocation.lat}+${selectedLocation.lng}&key=${import.meta.env.VITE_CAGE_KEY}`
        );

        const data = response.data.results[0]?.components || {};
        setLocationState({
          CityName: data.city || data.town || data.village || "Unknown",
          GovernmentName: data.state || "Unknown",
        });
      } catch (error) {
        console.error("Error fetching location:", error);
      }
    };

    fetchLocation();
  }, [selectedLocation]);

  return (
    <div className="flex flex-col items-center">
      <div className="w-180 h-[590px] border border-gray-300 rounded-lg shadow-lg" ref={mapContainer}></div>

      {location.CityName && (
        <div className="mt-4 text-center">
          <p className="text-lg font-semibold">📍 Selected Location:</p>
          <p className="text-gray-700">
            <strong>City:</strong> {location.CityName}
          </p>
          <p className="text-gray-700">
            <strong>Governorate:</strong> {location.GovernmentName}
          </p>
        </div>
      )}
    </div>
  );
};

export default Map;
