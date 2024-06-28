import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { BasketService } from './basket.service';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { GroupedBasketItem } from './basket.types';
import { StoreService } from '../store/store.service';
import { map, switchMap, tap } from 'rxjs';

@UntilDestroy()
@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent {
  loaded = false;
  error = false;
  groupedBasketItems: GroupedBasketItem[] = [];
  displayedColumns = [
    "productId",
    "name",
    "supplierName",
    "quantity",
    "control"
  ]
  estimatedDeliveryDate: Date | undefined = undefined;

  constructor(private basketService: BasketService, private storeService: StoreService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.error = false;
    this.loaded = false;
    this.basketService.get()
    .pipe(untilDestroyed(this))
    .subscribe(basket => {
      this.groupedBasketItems = basket
      .map(i => {
        return {
          ...i,
          supplier: this.storeService.supplier(i.supplierId)
        }
      });
      this.loaded = true;
    });
    this.basketService.basket
    .pipe(
      untilDestroyed(this),
      tap(basket => console.log(basket)),
      switchMap(basket => this.basketService.calculateEstimatedDeliveryDate({
        productIds: basket.map(i => i.productId),
        orderDate: new Date()
      }))
    )
    .subscribe(response => {
      console.log(response)
      if (response && response.success) {
        this.estimatedDeliveryDate = response.estimatedDispatchDate;
      }
    });
  }
  remove(element: GroupedBasketItem) {
    this.basketService.remove({productId: element.productId})
    .pipe(untilDestroyed(this))
    .subscribe();
  }
  add(element: GroupedBasketItem) {
    this.basketService.add({productId: element.productId})
    .pipe(untilDestroyed(this))
    .subscribe();
  }
}
