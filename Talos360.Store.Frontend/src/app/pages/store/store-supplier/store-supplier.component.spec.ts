import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreSupplierComponent } from './store-supplier.component';

describe('StoreSupplierComponent', () => {
  let component: StoreSupplierComponent;
  let fixture: ComponentFixture<StoreSupplierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoreSupplierComponent]
    });
    fixture = TestBed.createComponent(StoreSupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
