import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, concatMap, delay, retry, retryWhen, take, throwError } from 'rxjs';
import { Product } from 'src/app/shared/shared.types';
import { StoreResponse, StoreSupplier } from './store.types';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy()
@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private $suppliers: BehaviorSubject<StoreSupplier[] | undefined | "error"> = new BehaviorSubject<StoreSupplier[] | undefined | "error">(undefined);

  constructor(private httpClient: HttpClient) { }

  get() {
    this.httpClient.get<StoreResponse>("api/store")
    .pipe(
      untilDestroyed(this),
      retryWhen(errors => errors.pipe(delay(1000), take(10), concatMap(throwError)))
    )
    .subscribe(response => {
      if (response && response.success) {
        this.$suppliers.next(response.suppliers);
      } else {
        this.$suppliers.next("error");
      }
    });
    return this.$suppliers.asObservable();
  }
}
