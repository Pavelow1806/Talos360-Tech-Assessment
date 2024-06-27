import { Product, ResponseBase } from "src/app/shared/shared.types";

export interface BasketItem extends Product {
    basketItemId: string;
    dateAdded: Date;
}
export interface BasketResponse extends ResponseBase {
    basketItems: BasketItem[];
}
export interface AddToBasketResponse extends ResponseBase {
    item: BasketItem;
}
export interface RemoveFromBasketResponse extends ResponseBase {
}
export interface ClearBasketResponse extends ResponseBase {
}