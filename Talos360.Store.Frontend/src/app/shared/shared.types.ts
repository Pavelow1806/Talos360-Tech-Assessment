export interface ResponseBase {
    success: boolean;
    message: string;
}

export interface NavigationItem {
    name: string;
    url: string;
}
export interface Product {
    productId: number;
    name: string;
    supplierId: number;
}
export interface Supplier {
    supplierId: number;
    name: string;
    leadTime: number;
}