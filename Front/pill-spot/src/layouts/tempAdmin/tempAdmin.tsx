// import { useEffect, useState } from "react";
// import { useDispatch } from "react-redux";
// import { AppDispatch } from "../../app/store";
// import { logout } from "../../features/auth/authLogin";

// const AdminCategories = () => {
//   const [categories, setCategories] = useState([]);
//   const [newCategoryName, setNewCategoryName] = useState("");
//   const [subCategoryInputs, setSubCategoryInputs] = useState({});
//   const [subCategories, setSubCategories] = useState({});
//   const [products, setProducts] = useState([]);
//   const [productForm, setProductForm] = useState({
//     name: "",
//     description: "",
//     price: "",
//     manufacturer: "",
//     dosage: "",
//     sideEffects: "",
//     isPrescriptionRequired: false,
//     subCategoryId: "",
//     image: null,
//   });
//   const [loading, setLoading] = useState(false);
//   const dispatch = useDispatch<AppDispatch>();

//   const fetchCategories = async () => {
//     try {
//       const response = await fetch("https://localhost:7298/api/categories");
//       const data = await response.json();
//       setCategories(data);

//       for (const cat of data) {
//         fetchSubCategories(cat.categoryId);
//       }
//     } catch (error) {
//       console.error("Error fetching categories:", error);
//     }
//   };

//   const fetchSubCategories = async (categoryId) => {
//     try {
//       const response = await fetch(
//         `https://localhost:7298/api/categories/${categoryId}/subcategories`
//       );
//       const data = await response.json();
//       setSubCategories((prev) => ({
//         ...prev,
//         [categoryId]: data,
//       }));
//     } catch (error) {
//       console.error("Error fetching subcategories:", error);
//     }
//   };

//   const fetchProducts = async () => {
//     try {
//       const response = await fetch("https://localhost:7298/api/products");
//       const data = await response.json();
//       setProducts(data);
//     } catch (error) {
//       console.error("Error fetching products:", error);
//     }
//   };

//   const handleAddCategory = async (e) => {
//     e.preventDefault();
//     if (!newCategoryName.trim()) return;

//     try {
//       setLoading(true);
//       const response = await fetch("https://localhost:7298/api/categories", {
//         method: "POST",
//         headers: { "Content-Type": "application/json" },
//         body: JSON.stringify({ name: newCategoryName }),
//       });

//       if (response.ok) {
//         setNewCategoryName("");
//         fetchCategories();
//       } else {
//         console.error("Failed to add category");
//       }
//     } catch (error) {
//       console.error("Error posting category:", error);
//     } finally {
//       setLoading(false);
//     }
//   };

//   const handleAddSubCategory = async (categoryId) => {
//     const name = subCategoryInputs[categoryId];
//     if (!name?.trim()) return;

//     try {
//       await fetch(
//         `https://localhost:7298/api/categories/${categoryId}/subcategories`,
//         {
//           method: "POST",
//           headers: { "Content-Type": "application/json" },
//           body: JSON.stringify({ name }),
//         }
//       );
//       setSubCategoryInputs((prev) => ({ ...prev, [categoryId]: "" }));
//       fetchSubCategories(categoryId);
//     } catch (error) {
//       console.error("Error posting subcategory:", error);
//     }
//   };

//   const handleAddProduct = async (e) => {
//     e.preventDefault();
//     const formData = new FormData();
//     formData.append("Name", productForm.name);
//     formData.append("Description", productForm.description);
//     formData.append("Price", productForm.price);
//     formData.append("Manufacturer", productForm.manufacturer);
//     formData.append("Dosage", productForm.dosage);
//     formData.append("SideEffects", productForm.sideEffects);
//     formData.append("IsPrescriptionRequired", productForm.isPrescriptionRequired);
//     formData.append("SubCategoryId", productForm.subCategoryId);
//     formData.append("UsageInstructions", "IT IS EASY");
//     if (productForm.image) formData.append("Image", productForm.image);

//     try {
//       formData.forEach(element => {
//           console.log(element) ;
//       });
//       const response = await fetch("https://localhost:7298/api/medicines", {
//         method: "POST",
//         body: formData,
//       });

//       if (response.ok) {
//         fetchProducts();
//         setProductForm({
//           name: "",
//           description: "",
//           price: "",
//           manufacturer: "",
//           dosage: "",
//           sideEffects: "",
//           isPrescriptionRequired: false,
//           subCategoryId: "",
//           image: null,
//         });
//       } else {
//         console.error("Failed to add product");
//       }
//     } catch (error) {
//       console.error("Error posting product:", error);
//     }
//   };

//   const handleLogout = () => {
//     dispatch(logout());
//   };

//   useEffect(() => {
//     fetchCategories();
//     fetchProducts();
//   }, []);

//   return (
//     <div className="p-4 max-w-6xl mx-auto">
//       <div className="flex justify-between items-center mb-4">
//         <h2 className="text-2xl font-bold">Admin Panel</h2>
//         <button
//           onClick={handleLogout}
//           className="bg-red-500 text-white px-4 py-2 rounded"
//         >
//           Logout
//         </button>
//       </div>

//       {/* Add Category */}
//       <form onSubmit={handleAddCategory} className="mb-6 flex gap-2">
//         <input
//           type="text"
//           placeholder="New category name"
//           className="border p-2 rounded w-full"
//           value={newCategoryName}
//           onChange={(e) => setNewCategoryName(e.target.value)}
//         />
//         <button
//           type="submit"
//           className="bg-blue-500 text-white px-4 py-2 rounded"
//           disabled={loading}
//         >
//           {loading ? "Adding..." : "Add"}
//         </button>
//       </form>

//       {/* Category Cards */}
//       <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
//         {categories.map((cat) => (
//           <div key={cat.categoryId} className="border p-4 rounded shadow">
//             <h3 className="text-lg font-semibold">{cat.name}</h3>
//             <p className="text-gray-500 mb-2">ID: {cat.categoryId}</p>

//             {/* Add Subcategory */}
//             <input
//               type="text"
//               placeholder="New subcategory"
//               className="border p-1 rounded w-full mb-2"
//               value={subCategoryInputs[cat.categoryId] || ""}
//               onChange={(e) =>
//                 setSubCategoryInputs((prev) => ({
//                   ...prev,
//                   [cat.categoryId]: e.target.value,
//                 }))
//               }
//             />
//             <button
//               onClick={() => handleAddSubCategory(cat.categoryId)}
//               className="bg-green-500 text-white px-3 py-1 rounded text-sm"
//             >
//               Add Subcategory
//             </button>

//             {/* Subcategory List */}
//             {subCategories[cat.categoryId]?.length > 0 && (
//               <div className="mt-4">
//                 <p className="font-semibold text-sm text-gray-700">
//                   Subcategories:
//                 </p>
//                 <ul className="list-disc list-inside text-sm text-gray-600">
//                   {subCategories[cat.categoryId].map((sub) => (
//                     <li key={sub.subCategoryId}>
//                       {sub.name} : {sub.subCategoryId}
//                     </li>
//                   ))}
//                 </ul>
//               </div>
//             )}
//           </div>
//         ))}
//       </div>

//       {/* Add Product */}
//       <div className="mt-8">
//         <h2 className="text-xl font-bold mb-2">Add New Medicine</h2>
//         <form onSubmit={handleAddProduct} className="grid gap-3">
//           <input type="text" placeholder="Name" className="border p-2 rounded" value={productForm.name} onChange={(e) => setProductForm((prev) => ({ ...prev, name: e.target.value }))} />
//           <textarea placeholder="Description" className="border p-2 rounded" value={productForm.description} onChange={(e) => setProductForm((prev) => ({ ...prev, description: e.target.value }))} />
//           <input type="number" placeholder="Price" className="border p-2 rounded" value={productForm.price} onChange={(e) => setProductForm((prev) => ({ ...prev, price: e.target.value }))} />
//           <input type="text" placeholder="Manufacturer" className="border p-2 rounded" value={productForm.manufacturer} onChange={(e) => setProductForm((prev) => ({ ...prev, manufacturer: e.target.value }))} />
//           <input type="text" placeholder="Dosage" className="border p-2 rounded" value={productForm.dosage} onChange={(e) => setProductForm((prev) => ({ ...prev, dosage: e.target.value }))} />
//           <input type="text" placeholder="Side Effects" className="border p-2 rounded" value={productForm.sideEffects} onChange={(e) => setProductForm((prev) => ({ ...prev, sideEffects: e.target.value }))} />
//           <label className="flex gap-2 items-center">
//             <input type="checkbox" checked={productForm.isPrescriptionRequired} onChange={(e) => setProductForm((prev) => ({ ...prev, isPrescriptionRequired: e.target.checked }))} />
//             Prescription Required
//           </label>
//           <select className="border p-2 rounded" value={productForm.subCategoryId} onChange={(e) => setProductForm((prev) => ({ ...prev, subCategoryId: e.target.value }))} >
//             <option value="">Select Subcategory</option>
//             {Object.entries(subCategories).map(([catId, subs]) =>
//               subs.map((sub) => (
//                 <option key={sub.subCategoryId} value={sub.subCategoryId}>
//                   {sub.name}
//                 </option>
//               ))
//             )}
//           </select>
//           <input type="file" accept="image/*" onChange={(e) => setProductForm((prev) => ({ ...prev, image: e.target.files[0] }))} />
//           <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded">
//             Add Medicine
//           </button>
//         </form>
//       </div>

//       {/* Display Products */}
//       <div className="mt-8">
//         <h2 className="text-xl font-bold mb-2">All Medicines</h2>
//         <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
//           {products.map((product) => (
//             <div key={product.productId} className="border p-4 rounded shadow">
//               <h3 className="text-lg font-semibold">{product.name}</h3>
//               <p className="text-gray-600 text-sm">{product.description}</p>
//               <p className="text-green-700 font-bold mt-1">${product.price}</p>
//               <p className="text-gray-500 text-sm">
//                 SubCategory ID: {product.subCategoryId}
//               </p>
//               {product.imageUrl && (
//                 <img
//                   src={product.imageUrl}
//                   alt={product.name}
//                   className="w-full h-40 object-cover mt-2 rounded"
//                 />
//               )}
//             </div>
//           ))}
//         </div>
//       </div>
//     </div>
//   );
// };

// export default AdminCategories;