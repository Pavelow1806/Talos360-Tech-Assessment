import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { BasketItem, GroupedBasketItem } from './basket.types';
import { BasketService } from './basket.service';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy()
@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BasketComponent {
  loaded = false;
  error = false;
  groupedBasketItems: GroupedBasketItem[] = [];

  constructor(private basketService: BasketService, private change: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.error = false;
    this.loaded = false;
    this.basketService.get()
    .pipe(untilDestroyed(this))
    .subscribe(basket => {
      console.log(basket.length, "lenth")
      const stage1 = basket
      .sort((p, c) => p.dateAdded > c.dateAdded ? 1 : -1)
      .map((i: BasketItem): GroupedBasketItem => {
        return {
          ...i,
          quantity: 1
        };
      });
      console.log(stage1)
      this.groupedBasketItems = stage1.reduce((a: GroupedBasketItem[], c) => {
        const group = a.find(i => i.productId);
        console.log(a.length, c.productId, group !== undefined);
        if (group) {
          group.quantity++;
          return a;
        } else {
          a.push(c);
          return a;
        }
      }, [] as GroupedBasketItem[]);
      this.change.markForCheck();
      console.log("grouped items", this.groupedBasketItems);
      this.loaded = true;
    });
  }
}
