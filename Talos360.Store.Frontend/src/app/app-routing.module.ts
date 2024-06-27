import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorComponent } from './shared/error/error.component';
import { StoreComponent } from './pages/store/store.component';
import { BasketComponent } from './pages/basket/basket.component';

const routes: Routes = [
  {path: "", redirectTo: "store", pathMatch: "full"},
  {path: "store", component: StoreComponent},
  {path: "basket", component: BasketComponent},
  {path: "**", component: ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
