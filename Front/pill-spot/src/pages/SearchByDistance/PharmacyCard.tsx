import React from 'react';
import { ProductItem } from '../../components/Result/types';
import MapLocation from '../../components/MapModal';

const InfoItem: React.FC<{ icon: React.ReactNode; label: string; value: React.ReactNode }> = ({ icon, label, value }) => (
  <div className="flex items-center gap-1 text-xs text-gray-700 whitespace-nowrap">
    <span className="text-blue-700 w-4 flex-shrink-0 flex items-center justify-center">{icon}</span>
    <span className="font-semibold">{label}</span>
    <span className="text-gray-900">{value}</span>
  </div>
);

const PharmacyCard: React.FC<{ item: ProductItem }> = ({ item }) => {
  const modalName = `map-modal-${item.pharmacyDto.pharmacyId || item.pharmacyDto.name.replace(/\s+/g, '-')}`;
  return (
    <div className="bg-white rounded-lg shadow p-3 flex flex-row gap-3 items-center mb-2 border border-slate-100 min-h-[64px]">
      <img
        src={item.pharmacyDto.logoURL.startsWith('http') ? item.pharmacyDto.logoURL : `${import.meta.env.VITE_BASE_URL}${item.pharmacyDto.logoURL}`}
        alt={item.pharmacyDto.name}
        className="w-12 h-12 object-cover rounded-full border"
      />
      <div className="flex-1 flex flex-col gap-0.5 min-w-0">
        <div className="flex items-center gap-2 flex-wrap">
          <h3 className="text-base font-semibold text-[#02457a] truncate max-w-[120px]">{item.pharmacyDto.name}</h3>
          <span className="px-2 py-0.5 rounded-full text-xs font-semibold bg-blue-100 text-blue-800">{item.formattedDistance || item.distance?.toFixed(2) + ' km'}</span>
          <span className={`px-2 py-0.5 rounded-full text-xs font-semibold ${item.quantity > 10 ? 'bg-green-100 text-green-800' : item.quantity > 0 ? 'bg-yellow-100 text-yellow-800' : 'bg-red-100 text-red-800'}`}>{item.quantity > 10 ? 'In Stock' : item.quantity > 0 ? 'Low Stock' : 'Out of Stock'}</span>
          {item.pharmacyDto.isOpen24 && (
            <span className="px-2 py-0.5 rounded-full text-xs font-bold bg-green-200 text-green-900 border border-green-300">24/7</span>
          )}
        </div>
        <div className="flex flex-wrap gap-x-4 gap-y-1 items-center mt-1">
          <InfoItem
            icon={<svg className="w-3 h-3" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M17.657 16.657L13.414 12.414a2 2 0 0 0-2.828 0l-4.243 4.243" /></svg>}
            label="Address:"
            value={item.pharmacyDto.locationDto.additionalInfo || 'N/A'}
          />
          <InfoItem
            icon={<svg className="w-3 h-3" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M3 5a2 2 0 0 1 2-2h2a2 2 0 0 1 2 2v2a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5zm0 0v0a16 16 0 0 0 16 16v0a2 2 0 0 0 2-2v-2a2 2 0 0 0-2-2h-2a2 2 0 0 0-2 2v2a2 2 0 0 0 2 2" /></svg>}
            label="Contact:"
            value={<span className="font-mono">{item.pharmacyDto.contactNumber}</span>}
          />
          <InfoItem
            icon={<svg className="w-3 h-3" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M8 7V6a1 1 0 0 1 1-1h6a1 1 0 0 1 1 1v1" /></svg>}
            label="Hours:"
            value={item.pharmacyDto.isOpen24 ? '24/7' : `${item.pharmacyDto.openingTime} - ${item.pharmacyDto.closingTime}`}
          />
          <InfoItem
            icon={<svg className="w-3 h-3" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M3 7h18M3 11h18M3 15h18" /></svg>}
            label="Days:"
            value={item.pharmacyDto.daysOpen}
          />
          <InfoItem
            icon={<svg className="w-3 h-3" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M20 13V7a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v6" /></svg>}
            label="Stock:"
            value={<span>{item.quantity} available</span>}
          />
        </div>
      </div>
      <div className="flex flex-col gap-1 text-xs items-end min-w-[80px]">
        <div className="flex gap-1">
          <button className="btn btn-xs btn-outline" onClick={() => navigator.clipboard.writeText(item.pharmacyDto.contactNumber)} title="Copy contact">
            <svg className="w-4 h-4 inline" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M8 17v1a3 3 0 0 0 3 3h6a3 3 0 0 0 3-3V7a3 3 0 0 0-3-3h-6a3 3 0 0 0-3 3v1" /></svg>
          </button>
          <a className="btn btn-xs btn-primary" href={`tel:${item.pharmacyDto.contactNumber}`} title="Call pharmacy">
            <svg className="w-4 h-4 inline" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M3 5a2 2 0 0 1 2-2h2a2 2 0 0 1 2 2v2a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5zm0 0v0a16 16 0 0 0 16 16v0a2 2 0 0 0 2-2v-2a2 2 0 0 0-2-2h-2a2 2 0 0 0-2 2v2a2 2 0 0 0 2 2" /></svg>
          </a>
          <MapLocation
            modalName={modalName}
            name={item.pharmacyDto.name}
            distance={item.formattedDistance || item.distance?.toFixed(2) || ''}
            lng={item.pharmacyDto.locationDto.longitude}
            lat={item.pharmacyDto.locationDto.latitude}
          />
        </div>
      </div>
    </div>
  );
};

export default PharmacyCard; 