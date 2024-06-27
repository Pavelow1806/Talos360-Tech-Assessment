import { NgModule } from "@angular/core";
import { MatIconModule } from "@angular/material/icon";
import { StoreComponent } from "./store.component";
import { CommonModule } from "@angular/common";
import { SharedModule } from "src/app/shared/shared.module";
import { ItemComponent } from './store-item/store-item.component';

@NgModule({
    declarations: [
        StoreComponent,
        ItemComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
    ],
    providers: [
    ],
    bootstrap: [StoreComponent]
})
export class StoreModule { }