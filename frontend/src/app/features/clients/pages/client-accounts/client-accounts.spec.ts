import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientAccounts } from './client-accounts';

describe('ClientAccounts', () => {
  let component: ClientAccounts;
  let fixture: ComponentFixture<ClientAccounts>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientAccounts]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientAccounts);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
