import { Component, OnInit } from '@angular/core';
import { StoreService } from './store.service';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { Product } from 'src/app/shared/shared.types';

@UntilDestroy()
@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss']
})
export class StoreComponent implements OnInit {
  loaded = false;
  error = false;
  products: Product[] = [];

  constructor(private storeService: StoreService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.error = false;
    this.loaded = false;
    this.storeService.get()
    .pipe(untilDestroyed(this))
    .subscribe(products => {
      if (products == "error") {
        this.error = true;
      } else if (products) {
        this.products = products;
        this.loaded = true;
      }
    });
  }
}
