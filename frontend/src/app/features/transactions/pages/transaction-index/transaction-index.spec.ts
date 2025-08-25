import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionIndex } from './transaction-index';

describe('TransactionIndex', () => {
  let component: TransactionIndex;
  let fixture: ComponentFixture<TransactionIndex>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransactionIndex]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionIndex);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
