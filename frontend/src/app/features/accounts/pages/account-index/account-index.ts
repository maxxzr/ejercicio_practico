import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.services';
import { AccountModel } from '../../model/account.mode';
import { CommonModule } from '@angular/common';
import { LoadingService } from '../../../../shared/loading/loading.service';

@Component({
  selector: 'app-account-index',
  imports: [CommonModule],
  templateUrl: './account-index.html',
  styleUrl: './account-index.css'
})
export class AccountIndex implements OnInit {
  accountService = inject(AccountService);
  loadingService = inject(LoadingService);
  accounts: AccountModel[] = [];

  ngOnInit() {
    this.loadingService.showLoading();
    this.accountService.search().subscribe(accounts => {
      this.accounts = accounts;
      this.loadingService.hideLoading();
    });
  }

}
