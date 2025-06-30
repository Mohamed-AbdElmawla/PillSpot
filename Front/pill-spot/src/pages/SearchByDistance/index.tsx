import React, { useEffect, useState } from 'react';
import useGeolocation from '../../hooks/GetLocation';
import axios from 'axios';
import { ProductItem } from '../../components/Result/types';
import ProductRow from './ProductRow';
import StickyHeader from './StickyHeader';
import { useLocation } from 'react-router-dom';

interface SearchByDistanceProps {
  searchTerm?: string;
}

// Helper: Group items by productId
function groupByProduct(items: ProductItem[]) {
  const map = new Map<string, { product: ProductItem['productDto']; pharmacies: ProductItem[] }>();
  for (const item of items) {
    const id = item.productDto.productId;
    if (!map.has(id)) {
      map.set(id, { product: item.productDto, pharmacies: [item] });
    } else {
      map.get(id)!.pharmacies.push(item);
    }
  }
  return Array.from(map.values());
}

const SkeletonProduct: React.FC = () => (
  <div className="mb-6 rounded-xl shadow-lg bg-white border border-slate-200 overflow-hidden animate-pulse">
    <div className="flex items-center gap-4 p-6">
      <div className="w-20 h-20 bg-slate-200 rounded-lg" />
      <div className="flex-1 flex flex-col gap-2">
        <div className="h-6 w-1/3 bg-slate-200 rounded" />
        <div className="h-4 w-1/2 bg-slate-200 rounded" />
        <div className="h-4 w-2/3 bg-slate-200 rounded" />
      </div>
    </div>
    <div className="px-6 pb-6 pt-2">
      <div className="h-4 w-1/4 bg-slate-200 rounded mb-2" />
      <div className="h-4 w-1/2 bg-slate-200 rounded" />
    </div>
  </div>
);

const SearchByDistance: React.FC<SearchByDistanceProps> = ({ searchTerm: propSearchTerm }) => {
  const { lat, lng } = useGeolocation();
  const location = useLocation();
  // Use prop if provided, otherwise fallback to query string
  const params = new URLSearchParams(location.search);
  const searchTerm = propSearchTerm ?? params.get('medecinetosearch') ?? '';

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [items, setItems] = useState<ProductItem[]>([]);

  useEffect(() => {
    if (!searchTerm || lat == null || lng == null) return;
    setLoading(true);
    setError(null);
    axios
      .get<ProductItem[]>(
        `${import.meta.env.VITE_BASE_URL}api/pharmacyproducts`,
        {
          params: {
            SearchTerm: searchTerm,
            UserLatitude: lat,
            UserLongitude: lng,
            PageNumber: 1,
            PageSize: 50,
          },
        }
      )
      .then((res) => {
        setItems(res.data);
      })
      .catch(() => {
        setError('Failed to fetch product or pharmacy data.');
      })
      .finally(() => setLoading(false));
  }, [searchTerm, lat, lng]);

  const grouped = groupByProduct(items);

  return (
    <div className="min-h-screen bg-gradient-to-br from-[#f7f9fb] to-[#e3eaf6] pb-8">
      <StickyHeader />
      <div className="px-4 md:px-16 mt-6">
        {loading && (
          <>
            <SkeletonProduct />
            <SkeletonProduct />
            <SkeletonProduct />
          </>
        )}
        {error && <div className="text-center text-lg text-red-600 mt-8">{error}</div>}
        {!loading && !error && grouped.length > 0 && (
          <div>
            <div className="mb-6 text-gray-700 text-lg font-medium">
              {grouped.length} product{grouped.length > 1 ? 's' : ''} found for
              <span className="ml-1 text-[#02457a] font-semibold">"{searchTerm}"</span>
            </div>
            <div className="flex flex-col gap-8">
              {grouped.map((group) => (
                <ProductRow key={group.product.productId} product={group.product} pharmacies={group.pharmacies} />
              ))}
            </div>
          </div>
        )}
        {!loading && !error && grouped.length === 0 && (
          <div className="text-center text-lg text-gray-500 mt-12">
            <div className="text-4xl mb-2">😕</div>
            No products or pharmacies found nearby.<br />
            Try searching for another product or check your location settings.
          </div>
        )}
      </div>
    </div>
  );
};

export default SearchByDistance;
