import { Product, ResponseBase } from "src/app/shared/shared.types";

export interface GroupedBasketItem extends Product {
    quantity: number;
}
export interface BasketResponse extends ResponseBase {
    basketItems: GroupedBasketItem[];
}
export interface AddToBasketRequest {
    productId: number;
}
export interface AddToBasketResponse extends ResponseBase {
}
export interface RemoveFromBasketResponse extends ResponseBase {
}
export interface ClearBasketResponse extends ResponseBase {
}