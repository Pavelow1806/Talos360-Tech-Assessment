import { NgModule } from "@angular/core";
import { MatIconModule } from "@angular/material/icon";
import { BasketComponent } from "./basket.component";
import { CommonModule } from "@angular/common";
import { SharedModule } from "src/app/shared/shared.module";
import { BasketProductComponent } from './basket-product/basket-product.component';

@NgModule({
    declarations: [
        BasketComponent,
        BasketProductComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
    ],
    providers: [
    ],
    bootstrap: [BasketComponent]
})
export class BasketModule { }