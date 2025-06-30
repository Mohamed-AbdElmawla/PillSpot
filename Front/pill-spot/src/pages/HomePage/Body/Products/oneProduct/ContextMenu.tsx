import { useState } from "react";
import { FaRegHeart } from "react-icons/fa6";
import { toast } from "sonner";
import { subscribeToProductAvailability } from "../../../../../features/NotificationSubscribe/NotificationSubscribService";


interface CategoryDto {
  categoryId: string;
  name: string;
}

interface SubCategoryDto {
  categoryDto: CategoryDto;
  subCategoryId: string;
  name: string;
}

interface ProductDto {
  productId: string;
  subCategoryDto: SubCategoryDto;
  name: string;
  description: string;
  usageInstructions: string;
  price: number;
  imageURL: string;
  manufacturer: string;
  createdDate: string;
}

interface LocationDto {
  longitude: number;
  latitude: number;
  additionalInfo: string;
  cityDto: null;
}

interface PharmacyDto {
  pharmacyId: string;
  name: string;
  logoURL: string;
  logo: null;
  locationDto: LocationDto;
  contactNumber: string;
  openingTime: string;
  closingTime: string;
  isOpen24: boolean;
  daysOpen: string;
}

interface ContextMenuProps {
  x: number;
  y: number;
  visible: boolean;
  productDto: ProductDto;
  pharmacyDto: PharmacyDto;
  onClose: () => void;
}

const NOTIFICATION_TYPE_OPTIONS = [
  "General",
  "PriceChange",
  "Promotion",
  "ProductInfo",
  "StockAlert",
  "PriceDrop",
  "Restock",
  "Discount",
  "RequestUpdate",
  "ProductAvailable",
  "ProductUnavailable",
  "LowStock",
  "ProductRemoved"
];

const ContextMenu = ({ x, y, visible, productDto, pharmacyDto, onClose }: ContextMenuProps) => {
  // const [trackModalOpen, setTrackModalOpen] = useState(false);
  const [selectedType, setSelectedType] = useState<string>("ProductAvailable");
  const [submitting, setSubmitting] = useState(false);

  const handleAddToWishlist = () => {
    toast.success("Added to wishlist");
    onClose();
  };

  const handleViewDetails = () => {
    toast.info("Viewing product details");
    onClose();
  };

  const handleTrackSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setSubmitting(true);
    try {
      await subscribeToProductAvailability(productDto.productId, {
        isEnabled: true,
        notificationTypes: [selectedType]
      });
      toast.success("You will be notified for this product.");
    } catch {
      toast.error("Failed to subscribe for product notification.");
    }
    setSubmitting(false);
    onClose();
  };

  const handleCopyProductName = async () => {
    try {
      await navigator.clipboard.writeText(productDto.name);
      toast.success("Product name copied to clipboard");
    } catch {
      toast.error("Failed to copy product name");
    }
    onClose();
  };

  const handleCopyPharmacyName = async () => {
    try {
      await navigator.clipboard.writeText(pharmacyDto.name);
      toast.success("Pharmacy name copied to clipboard");
    } catch {
      toast.error("Failed to copy pharmacy name");
    }
    onClose();
  };

  if (!visible) return null;

  return (
    <>
      <div
        className="fixed z-50 bg-white border border-gray-200 rounded-lg shadow-lg py-2 min-w-[240px]"
        style={{ left: x, top: y }}
      >
        <button
          onClick={handleAddToWishlist}
          className="w-full px-4 py-2 text-left text-sm text-gray-700 hover:bg-gray-100 flex items-center gap-2"
        >
          <FaRegHeart className="text-lg" />
          Add to Wishlist
        </button>
        <button
          onClick={handleViewDetails}
          className="w-full px-4 py-2 text-left text-sm text-gray-700 hover:bg-gray-100 flex items-center gap-2"
        >
          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
          </svg>
          View Details
        </button>
        <form onSubmit={handleTrackSubmit} className="flex flex-col gap-2 px-4 py-2">
          <label className="font-semibold text-sm mb-1">Notification Tracking Type:</label>
          <div className="flex gap-2 items-center">
            <select
              className="border rounded px-2 py-1 text-sm"
              value={selectedType}
              onChange={e => setSelectedType(e.target.value)}
            >
              {NOTIFICATION_TYPE_OPTIONS.map(opt => (
                <option key={opt} value={opt}>{opt}</option>
              ))}
            </select>
            <button
              type="submit"
              className="bg-blue-700 text-white px-3 py-1 rounded font-semibold disabled:opacity-60"
              disabled={submitting}
            >
              {submitting ? "Saving..." : "Track"}
            </button>
          </div>
        </form>
        <hr className="my-1" />
        <button
          onClick={handleCopyProductName}
          className="w-full px-4 py-2 text-left text-sm text-gray-700 hover:bg-gray-100 flex items-center gap-2"
        >
          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M8 16H6a2 2 0 01-2-2V6a2 2 0 012-2h8a2 2 0 012 2v2m-6 12h8a2 2 0 002-2v-8a2 2 0 00-2-2h-8a2 2 0 00-2 2v8a2 2 0 002 2z" />
          </svg>
          Copy Product Name
        </button>
        <button
          onClick={handleCopyPharmacyName}
          className="w-full px-4 py-2 text-left text-sm text-gray-700 hover:bg-gray-100 flex items-center gap-2"
        >
          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M8 16H6a2 2 0 01-2-2V6a2 2 0 012-2h8a2 2 0 012 2v2m-6 12h8a2 2 0 002-2v-8a2 2 0 00-2-2h-8a2 2 0 00-2 2v8a2 2 0 002 2z" />
          </svg>
          Copy Pharmacy Name
        </button>
      </div>
    </>
  );
};

export default ContextMenu; 