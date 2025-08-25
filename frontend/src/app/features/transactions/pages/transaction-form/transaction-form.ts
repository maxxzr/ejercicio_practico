import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TransactionModel } from '../../models/transaction.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TransactionTypes } from '../../../../shared/enums/data';
import { FormMode, TransactionTypeId } from '../../../../shared/enums/enums';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../../../../shared/toast/toast.service';
import { LoadingService } from '../../../../shared/loading/loading.service';
import { AccountService } from '../../../accounts/services/account.services';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-transaction-form',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './transaction-form.html',
  styleUrl: './transaction-form.css'
})
export class TransactionForm {
  @Input() accountId: number | undefined;
  @Output() onSave = new EventEmitter<any>();
  @Output() onCancel = new EventEmitter<any>();

  transactionForm: FormGroup;

  transactionTypes = TransactionTypes;
  mode: FormMode = FormMode.Add;

  constructor(private fb: FormBuilder, private activatedRoute: ActivatedRoute, private router: Router, private accountService: AccountService, private toastService: ToastService, private loadingService: LoadingService) {
    const accountId = this.accountId ?? this.activatedRoute.snapshot.params['id'];
    this.transactionForm = this.fb.group({
      accountId: [accountId],
      amount: [0, [Validators.required, Validators.minLength(8)]],
      transactionTypeId: [TransactionTypeId.Debit, [Validators.required]],
    });
  }

  newForm(accountId: number) {

  }

  loadForm(transaction: TransactionModel) {

  }

  onSubmit() {
    this.transactionForm.markAllAsTouched();
    if (this.transactionForm.valid) {
      var data = this.transactionForm.value;
      var $save = this.accountService.postTransaction(data.accountId,data);
      this.loadingService.showLoading();
      $save.subscribe({
        next: (result) => {
          this.loadingService.hideLoading();
          if (result.success) {
            this.toastService.addSuccess(result.message);
            this.onSave?.emit(result);
          } else {
            this.toastService.addError(result.message);
          }
        },
        error: (error) => {
          this.loadingService.hideLoading();
          this.toastService.showError(error);
        }
      })
    }
  }

  cancel() {
    this.onCancel?.emit();
  }
}
