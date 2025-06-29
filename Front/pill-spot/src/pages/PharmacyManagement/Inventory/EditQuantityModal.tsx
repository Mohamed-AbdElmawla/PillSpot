import { useState, FormEvent } from "react";
import { motion, AnimatePresence } from "framer-motion";

interface EditQuantityModalProps {
  open: boolean;
  onClose: () => void;
  onSubmit: (values: { quantity: number; minStock: number; isAvailable: boolean }) => void;
  initialQuantity: number;
  initialMinStock?: number;
  initialIsAvailable?: boolean;
  productName: string;
}

const EditQuantityModal = ({
  open,
  onClose,
  onSubmit,
  initialQuantity,
  initialMinStock = 1,
  initialIsAvailable = true,
  productName,
}: EditQuantityModalProps) => {
  const [quantity, setQuantity] = useState(initialQuantity);
  const [minStock, setMinStock] = useState(initialMinStock);
  const [isAvailable, setIsAvailable] = useState(initialIsAvailable);

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    onSubmit({ quantity, minStock, isAvailable });
    onClose();
  };

  return (
    <AnimatePresence>
      {open && (
        <div className="fixed inset-0 z-50 flex items-center justify-center backdrop-blur-sm bg-black/10">
          <motion.div
            initial={{ opacity: 0, scale: 0.8 }}
            animate={{ opacity: 1, scale: 1 }}
            exit={{ opacity: 0, scale: 0.8 }}
            transition={{ duration: 0.3, type: "spring", stiffness: 300, damping: 25 }}
            className="bg-white p-8 rounded-2xl shadow-2xl min-w-[340px] max-w-[90vw] border border-gray-100 flex flex-col items-center"
          >
            <h2 className="text-2xl font-extrabold mb-4 text-blue-800 tracking-tight">Edit Product Quantity</h2>
            <div className="mb-2 text-base font-semibold text-gray-600">{productName}</div>
            <form onSubmit={handleSubmit} className="flex flex-col gap-5 w-full">
              <label className="flex flex-col text-sm font-medium text-gray-700">
                Quantity
                <input
                  type="number"
                  min={0}
                  value={quantity}
                  onChange={e => setQuantity(Number(e.target.value))}
                  className="mt-1 border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
                  required
                />
              </label>
              <label className="flex flex-col text-sm font-medium text-gray-700">
                Minimum Stock Threshold
                <input
                  type="number"
                  min={0}
                  value={minStock}
                  onChange={e => setMinStock(Number(e.target.value))}
                  className="mt-1 border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
                />
              </label>
              <label className="flex items-center gap-2 text-sm font-medium text-gray-700">
                <input
                  type="checkbox"
                  checked={isAvailable}
                  onChange={e => setIsAvailable(e.target.checked)}
                  className="accent-blue-600"
                />
                Is Available
              </label>
              <div className="flex gap-3 mt-2 w-full justify-end">
                <button type="submit" className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-2 rounded-lg font-semibold shadow transition">Save</button>
                <button type="button" className="bg-gray-200 hover:bg-gray-300 text-gray-700 px-6 py-2 rounded-lg font-semibold shadow transition" onClick={onClose}>Cancel</button>
              </div>
            </form>
          </motion.div>
        </div>
      )}
    </AnimatePresence>
  );
};

export default EditQuantityModal; 