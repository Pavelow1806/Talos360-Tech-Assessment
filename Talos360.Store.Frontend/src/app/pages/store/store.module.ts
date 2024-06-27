import { NgModule } from "@angular/core";
import { MatIconModule } from "@angular/material/icon";
import { StoreComponent } from "./store.component";
import { CommonModule } from "@angular/common";
import { SharedModule } from "src/app/shared/shared.module";
import { StoreProductComponent } from './store-supplier/store-product/store-product.component';
import { StoreSupplierComponent } from './store-supplier/store-supplier.component';

@NgModule({
    declarations: [
        StoreComponent,
        StoreProductComponent,
        StoreSupplierComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        MatIconModule,
    ],
    providers: [
    ],
    bootstrap: [StoreComponent]
})
export class StoreModule { }