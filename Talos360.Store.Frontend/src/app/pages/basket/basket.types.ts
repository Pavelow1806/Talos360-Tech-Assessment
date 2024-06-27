import { Product, ResponseBase, Supplier } from "src/app/shared/shared.types";

export interface GroupedBasketItem extends Product {
    quantity: number;

    // Local only
    supplier?: Supplier;
}
export interface BasketResponse extends ResponseBase {
    basketItems: GroupedBasketItem[];
}
export interface AddToBasketRequest {
    productId: number;
}
export interface AddToBasketResponse extends ResponseBase {
}
export interface RemoveFromBasketRequest {
    productId: number;
}
export interface RemoveFromBasketResponse extends ResponseBase {
}
export interface ClearBasketResponse extends ResponseBase {
}
export interface EstimateDispatchDateRequest {
    productIds: number[];
    orderDate: Date;
}
export interface DispatchDateResponse extends ResponseBase {
    date: Date;
}