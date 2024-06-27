import { Product, ResponseBase, Supplier } from "src/app/shared/shared.types";

export interface StoreSupplier extends Supplier {
    products: Product[];
}
export interface StoreResponse extends ResponseBase {
    suppliers: StoreSupplier[];
}