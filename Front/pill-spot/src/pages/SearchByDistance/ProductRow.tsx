import React from 'react';
import { ProductItem } from '../../components/Result/types';

import { hasManufacturer } from './utils';
import PharmacyCard from './PharmacyCard';

const DetailRow: React.FC<{ icon: React.ReactNode; label: string; value: React.ReactNode }> = ({ icon, label, value }) => (
  <div className="flex items-center gap-3 py-1 px-2">
    <span className="text-blue-700 w-5 flex-shrink-0 flex items-center justify-center">{icon}</span>
    <span className="font-semibold text-gray-700 min-w-[100px]">{label}</span>
    <span className="text-gray-900">{value}</span>
  </div>
);

const ProductRow: React.FC<{
  product: ProductItem['productDto'];
  pharmacies: ProductItem[];
}> = ({ product, pharmacies }) => {
  return (
    <section className="w-full mb-10 flex flex-col md:flex-row gap-6">
      {/* Product details - 1/4 width */}
      <div className="md:w-1/4 w-full bg-gradient-to-br from-white to-blue-50 rounded-2xl shadow-2xl border border-slate-200 p-6 flex flex-col items-center justify-start relative overflow-hidden">
        <div className="absolute top-0 left-0 w-full h-2 bg-gradient-to-r from-[#49708f] to-[#02457a] rounded-t-2xl" />
        <img
          src={product.imageURL.startsWith('http') ? product.imageURL : `${import.meta.env.VITE_BASE_URL}${product.imageURL}`}
          alt={product.name}
          className="w-40 h-40 object-contain rounded-xl border-4 border-blue-100 shadow-lg mb-4 mt-2 bg-white"
        />
        <h2 className="text-2xl font-extrabold text-[#02457a] mb-2 text-center flex items-center gap-2">
          {product.name}
        </h2>
        <div className="text-2xl font-bold text-green-700 flex items-center gap-1 mb-4">
          <svg className="w-6 h-6" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M12 8c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2zm0 10c-2.21 0-4-1.79-4-4h2a2 2 0 0 0 4 0h2c0 2.21-1.79 4-4 4z" /></svg>
          {product.price} EGP
        </div>
        {/* Details card */}
        <div className="w-full bg-white/80 border border-slate-200 rounded-lg shadow-sm p-3 mb-3 flex flex-col gap-1">
          <DetailRow
            icon={<svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M20 21V7a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v14" /></svg>}
            label="Category:"
            value={product.subCategoryDto?.categoryDto?.name || 'Category'}
          />
          <DetailRow
            icon={<svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M9 17v-2a4 4 0 1 1 8 0v2" /></svg>}
            label="Subcategory:"
            value={product.subCategoryDto?.name || 'Subcategory'}
          />
          {hasManufacturer(product) && (
            <DetailRow
              icon={<svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M3 7v4a1 1 0 0 0 1 1h16a1 1 0 0 0 1-1V7" /></svg>}
              label="Manufacturer:"
              value={product.manufacturer}
            />
          )}
          <DetailRow
            icon={<svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M8 7V6a1 1 0 0 1 1-1h6a1 1 0 0 1 1 1v1" /></svg>}
            label="Created:"
            value={product.createdDate ? new Date(product.createdDate).toLocaleDateString() : 'N/A'}
          />
        </div>
        <div className="w-full border-t border-slate-200 my-2" />
        <div className="w-full text-gray-700 text-sm mb-2 text-center px-1">
          {product.description}
        </div>
        {product.usageInstructions && (
          <div className="w-full flex items-center gap-2 text-xs text-blue-800 italic text-center px-1">
            <svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M12 20h9" /></svg>
            <span className="font-semibold">Usage:</span> <span>{product.usageInstructions}</span>
          </div>
        )}
      </div>
      {/* Pharmacies - 3/4 width */}
      <div className="md:w-3/4 w-full flex flex-col gap-4">
        <div className="text-lg font-semibold text-[#02457a] mb-2">Available at {pharmacies.length} pharmacy{pharmacies.length > 1 ? 'ies' : 'y'}:</div>
        {pharmacies.length === 0 && (
          <div className="text-gray-500 text-center">No pharmacies found for this product.</div>
        )}
        {pharmacies.map((item) => (
          <PharmacyCard key={item.pharmacyDto.pharmacyId + item.distance} item={item} />
        ))}
      </div>
    </section>
  );
};

export default ProductRow; 