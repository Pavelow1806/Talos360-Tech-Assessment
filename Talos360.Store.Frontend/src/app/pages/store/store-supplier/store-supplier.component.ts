import { Component, Input } from '@angular/core';
import { StoreSupplier } from '../store.types';

@Component({
  selector: 'app-store-supplier',
  templateUrl: './store-supplier.component.html',
  styleUrls: ['./store-supplier.component.scss']
})
export class StoreSupplierComponent {
  @Input("supplier") supplier!: StoreSupplier;
}
