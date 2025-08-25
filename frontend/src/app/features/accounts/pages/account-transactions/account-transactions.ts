import { CommonModule, Location } from '@angular/common';
import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RouterModule } from '@angular/router';
import { LoadingService } from '../../../../shared/loading/loading.service';
import { AccountService } from '../../services/account.services';
import { ClientService } from '../../../clients/services/client.service';
import { ToastService } from '../../../../shared/toast/toast.service';
import { Modal } from "../../../../shared/modal/modal";
import { AccountModel } from '../../model/account.mode';
import { TransactionForm } from "../../../transactions/pages/transaction-form/transaction-form";
import { TransactionModel } from '../../../transactions/models/transaction.model';

@Component({
  selector: 'app-account-transactions',
  imports: [CommonModule, Modal, TransactionForm],
  templateUrl: './account-transactions.html',
  styleUrl: './account-transactions.css'
})
export class AccountTransactions implements OnInit{

  clientService = inject(ClientService);
  accountService = inject(AccountService);
  toastService = inject(ToastService);
  loadingService = inject(LoadingService);
  activatedRoute = inject(ActivatedRoute);
  location: Location = inject(Location);
  router: Router = inject(Router);

  account: AccountModel | undefined;
  transactions: TransactionModel[] = [];
  @ViewChild('modalTransaction') modalTransaction!: Modal;
  @ViewChild('transactionForm') transactionForm!: TransactionForm;

  ngOnInit(): void {
      this.loadingService.showLoading();
      const accountId = this.activatedRoute.snapshot.params['id'];
  
      this.accountService.get(accountId).subscribe({
        next: account => {
          this.account = account;
          this.refreshTransactions();
        },
        error: (error) => {
          this.toastService.showError(error);
          this.loadingService.hideLoading();
        }
      });
    }
  
    refreshTransactions() {
      if (this.account?.accountId) {
        this.accountService.getTransactions(this.account.accountId).subscribe({
          next: transactions => {
            this.transactions = transactions;
            this.loadingService.hideLoading();
          },
          error: (error) => {
            this.toastService.showError(error);
            this.loadingService.hideLoading();
          }
        });
      }
    }
    showNewMoldalTransactionForm() {
      this.transactionForm.newForm(this.account?.clientId ?? 0);
      this.modalTransaction.open()
    }
  
    showEditMoldalTransactionForm(trasactionModel: TransactionModel) {
      this.transactionForm.loadForm({
        ...trasactionModel,
      });
      this.modalTransaction.open()
    }
  
    onSaveTransaction() {
      this.modalTransaction.close();
      this.refreshTransactions();
    }
  
    showConfirmDeleteTransaction(transaction: TransactionModel) {
      const confirmed = confirm('¿Estás seguro de que deseas eliminar esta Transacción?');
      if (confirmed) {
        this.accountService.delete(transaction.transactionId).subscribe({
          next: () => {
            this.toastService.addSuccess('Transaccion eliminada con éxito');
            this.refreshTransactions();
          },
          error: (error) => {
            this.toastService.showError(error);
          }
        });
      }
    }

  backPage() {
    let locationState: any = this.location.getState();
    locationState['navigationId'] > 1 ? this.location.back() : this.router.navigate(['/clients']);
  }
}
