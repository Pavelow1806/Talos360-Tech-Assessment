import { Component, Input } from '@angular/core';
import { GroupedBasketItem } from '../basket.types';

@Component({
  selector: 'app-basket-product',
  templateUrl: './basket-product.component.html',
  styleUrls: ['./basket-product.component.scss']
})
export class BasketProductComponent {
  @Input("groupedBasketItem") groupedBasketItem!: GroupedBasketItem;
}
