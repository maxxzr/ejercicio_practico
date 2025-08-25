import { Component, inject, OnInit } from '@angular/core';
import { TransactionModel } from '../../models/transaction.model';
import { TransactionService } from '../../services/transaction.services';
import { CommonModule } from '@angular/common';
import { LoadingService } from '../../../../shared/loading/loading.service';

@Component({
  selector: 'app-transaction-index',
  imports: [CommonModule],
  templateUrl: './transaction-index.html',
  styleUrl: './transaction-index.css'
})
export class TransactionIndex implements OnInit {
  accountService = inject(TransactionService);
  loadingService = inject(LoadingService);
  transactions: TransactionModel[] = [];

  ngOnInit() {
    this.loadingService.showLoading();
    this.accountService.search().subscribe(transactions => {
      this.transactions = transactions;
      this.loadingService.hideLoading();
    });
  }
}
