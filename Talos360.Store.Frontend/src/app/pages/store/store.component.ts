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
  products: Product[] = [];

  constructor(private storeService: StoreService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.loaded = false;
    this.storeService.get()
    .pipe(untilDestroyed(this))
    .subscribe(products => {
      this.products = products;
      this.loaded = true;
    });
  }
}
