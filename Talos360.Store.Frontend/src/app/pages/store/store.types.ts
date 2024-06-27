import { Product, ResponseBase } from "src/app/shared/shared.types";

export interface ItemsResponse extends ResponseBase {
    products: Product[];
}