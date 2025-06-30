import { ProductItem } from '../../components/Result/types';
 
export function hasManufacturer(product: ProductItem['productDto'] | (ProductItem['productDto'] & { manufacturer?: string })): product is ProductItem['productDto'] & { manufacturer: string } {
  return 'manufacturer' in product && typeof product.manufacturer === 'string';
} 