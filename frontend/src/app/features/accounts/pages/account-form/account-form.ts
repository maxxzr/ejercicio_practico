import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoadingService } from '../../../../shared/loading/loading.service';
import { ToastService } from '../../../../shared/toast/toast.service';
import { CommonModule } from '@angular/common';
import { AccountTypes, StatusAccount } from '../../../../shared/enums/data';
import { AccountTypeId, FormMode, StatusAccountId } from '../../../../shared/enums/enums';
import { AccountModel } from '../../model/account.mode';
import { AccountService } from '../../services/account.services';

@Component({
  selector: 'app-account-form',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './account-form.html',
  styleUrl: './account-form.css'
})
export class AccountForm {
  @Input() clientId: number | undefined;
  @Output() onSave = new EventEmitter<any>();
  @Output() onCancel = new EventEmitter<any>();

  accountForm: FormGroup;

  accountTypes = AccountTypes;
  statusAccount = StatusAccount;
  mode: FormMode = FormMode.Add;

  constructor(private fb: FormBuilder, private activatedRoute: ActivatedRoute, private router: Router, private accountService: AccountService, private toastService: ToastService, private loadingService: LoadingService) {
    const clientId = this.clientId ?? this.activatedRoute.snapshot.params['id'];
    this.accountForm = this.fb.group({
      clientId: [clientId],
      number: ['', [Validators.required, Validators.minLength(6)]],
      accountTypeId: [AccountTypeId.Simple, [Validators.required]],
      initialBalance: [0, [Validators.required, Validators.min(0)]],
      statusAccountId: [StatusAccountId.Enabled, [Validators.required]],
      currentBalance: [0],
    });
  }
  newForm(clientId: number) {
    this.loadForm({
      clientId: clientId,
      number: '',
      accountTypeId: AccountTypeId.Simple,
      initialBalance: 0,
      statusAccountId: StatusAccountId.Enabled,
      currentBalance: 0,
      accountId: 0
    });
    this.mode = FormMode.Add;
  }

  loadForm(account: AccountModel) {
    this.mode = FormMode.Edit;
    this.accountForm = this.fb.group({
      accountId: [account.accountId],
      clientId: [account.clientId],
      number: [account.number, [Validators.required, Validators.minLength(6)]],
      accountTypeId: [account.accountTypeId, [Validators.required]],
      initialBalance: [account.initialBalance, [Validators.required, Validators.min(0)]],
      statusAccountId: [account.statusAccountId, [Validators.required]],
      currentBalance: [account.currentBalance],
    });
  }

  onSubmit() {
    this.accountForm.markAllAsTouched();
    if (this.accountForm.valid) {
      var data = this.accountForm.value;
      var $save = this.mode == FormMode.Add ? this.accountService.post(data) : this.accountService.put(data.clientId, data);
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
