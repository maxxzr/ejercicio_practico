import { CommonModule,Location } from '@angular/common';
import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RouterModule } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { LoadingService } from '../../../../shared/loading/loading.service';
import { ClientAccountModel } from '../../models/client-account-model';
import { ToastService } from '../../../../shared/toast/toast.service';
import { ClientModel } from '../../models/client.model';
import { AccountForm } from "../../../accounts/pages/account-form/account-form";
import { Modal } from "../../../../shared/modal/modal";
import { AccountService } from '../../../accounts/services/account.services';

@Component({
  selector: 'app-client-accounts',
  imports: [ReactiveFormsModule, CommonModule, RouterModule, AccountForm, Modal],
  templateUrl: './client-accounts.html',
  styleUrl: './client-accounts.css'
})
export class ClientAccounts implements OnInit {

  clientService = inject(ClientService);
  accountService = inject(AccountService);
  toastService = inject(ToastService);
  loadingService = inject(LoadingService);
  activatedRoute = inject(ActivatedRoute);
  location: Location = inject(Location);
  router: Router = inject(Router);
  
  @ViewChild('modalAccount') modalAccount!: Modal;
  @ViewChild('accountForm') accountForm!: AccountForm;


  accounts: ClientAccountModel[] = [];
  client: ClientModel | undefined;
  ngOnInit(): void {
    this.loadingService.showLoading();
    const clientId = this.activatedRoute.snapshot.params['id'];

    this.clientService.getClientById(clientId).subscribe({
      next: client => {
        this.client = client;
        this.refreshAccount();
      },
      error: (error) => {
        this.toastService.showError(error);
        this.loadingService.hideLoading();
      }
    });
  }

  refreshAccount() {
    if (this.client?.clientId) {
      this.clientService.getAccounts(this.client.clientId).subscribe({
        next: accounts => {
          this.accounts = accounts;
          this.loadingService.hideLoading();
        },
        error: (error) => {
          this.toastService.showError(error);
          this.loadingService.hideLoading();
        }
      });
    }
  }
  showNewMoldaAccountForm() {
    this.accountForm.newForm(this.client?.clientId ?? 0);
    this.modalAccount.open()
  }

  showEditMoldaAccountForm(clientAccountModel: ClientAccountModel) {
    this.accountForm.loadForm({
      ...clientAccountModel,
    });
    this.modalAccount.open()
  }

  onSaveAccount() {
    this.modalAccount.close();
    this.refreshAccount();
  }

  showConfirmDeleteAccount(clientAccountModel: ClientAccountModel) {
    const confirmed = confirm('¿Estás seguro de que deseas eliminar esta cuenta?');
    if (confirmed) {
      this.accountService.delete(clientAccountModel.accountId).subscribe({
        next: () => {
          this.toastService.addSuccess('Cuenta eliminada con éxito');
          this.refreshAccount();
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
