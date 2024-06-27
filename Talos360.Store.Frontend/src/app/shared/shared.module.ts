import { NgModule } from "@angular/core";
import { MatIconModule } from "@angular/material/icon";
import { ErrorComponent } from "./error/error.component";
import { HeaderComponent } from "./header/header.component";
import { MaxWidthComponent } from "./max-width/max-width.component";
import { ScrollableComponent } from "./scrollable/scrollable.component";
import { ItemComponent } from "./header/header-item/header-item.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { SpinnerComponent } from './spinner/spinner.component';

@NgModule({
    declarations: [
        ScrollableComponent,
        HeaderComponent,
        ItemComponent,
        ErrorComponent,
        MaxWidthComponent,
        SpinnerComponent,
    ],
    imports: [
        MatIconModule,
        CommonModule,
        RouterModule,
    ],
    exports: [
        ScrollableComponent,
        HeaderComponent,
        ItemComponent,
        ErrorComponent,
        MaxWidthComponent,
        SpinnerComponent,
    ]
  })
  export class SharedModule { }