export interface ProductItem {
    distance: number;
    formattedDistance: string;
    quantity: number;
    productDto: {
      productId: string;
      name: string;
      description: string;
      usageInstructions: string;
      price: number;
      imageURL: string;
      createdDate: string;
      subCategoryDto: {
        subCategoryId: string;
        name: string;
        categoryDto: {
          categoryId: string;
          name: string;
        };
      };
    };
    pharmacyDto: {
      pharmacyId: string;
      name: string;
      logoURL: string;
      logo: string | null;
      locationDto: {
        longitude: number;
        latitude: number;
        additionalInfo: string;
        cityDto: null ; 
      };
      contactNumber: string;
      openingTime: string;
      closingTime: string;
      isOpen24: boolean;
      daysOpen: string;
    };
  }
  