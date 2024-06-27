import { NgModule } from "@angular/core";
import { MatIconModule } from "@angular/material/icon";
import { BasketComponent } from "./basket.component";
import { CommonModule } from "@angular/common";
import { SharedModule } from "src/app/shared/shared.module";
import { MatTableModule } from '@angular/material/table';

@NgModule({
    declarations: [
        BasketComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        MatIconModule,
        MatTableModule,
    ],
    providers: [
    ],
    bootstrap: [BasketComponent]
})
export class BasketModule { }