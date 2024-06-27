import { Component, OnInit } from '@angular/core';
import { NavigationItem } from '../shared.types';
import { BasketService } from 'src/app/pages/basket/basket.service';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy()
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  itemsInBasket = 0;

  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.basketService.get()
    .pipe(untilDestroyed(this))
    .subscribe(basket => this.itemsInBasket = basket.length);
  }
}
