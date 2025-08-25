import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormMode, GenderId, StatusClientId } from '../../../../shared/enums/enums';
import { ClientService } from '../../services/client.service';
import { CommonModule } from '@angular/common';
import { ToastService } from '../../../../shared/toast/toast.service';
import { LoadingService } from '../../../../shared/loading/loading.service';
import { Genders, StatusClient } from '../../../../shared/enums/data';

@Component({
  selector: 'app-client-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './client-form.html',
  styleUrl: './client-form.css'
})
export class ClientForm implements OnInit {
  clientForm: FormGroup;
  title: string = 'Titulo';
  mode: FormMode | undefined;
  genders = Genders;
  statusClient = StatusClient;

  get isDetailMode(): boolean {
    return this.mode === FormMode.Detail;
  };

  get isNewMode(): boolean {
    return this.mode === FormMode.Add;
  };

  constructor(private fb: FormBuilder, private activatedRoute: ActivatedRoute, private router: Router, private clientService: ClientService, private toastService: ToastService, private loadingService: LoadingService) {
    this.clientForm = this.fb.group({
      clientId: [0],
      personId: [0],
      name: ['', [Validators.required, Validators.minLength(3)]],
      documentNumber: ['', [Validators.required, Validators.minLength(6)]],
      address: ['', [Validators.required, Validators.minLength(6)]],
      phone: ['', [Validators.required, Validators.minLength(6)]],
      genderId: [GenderId.Male, Validators.required],
      birthDate: [new Date(), Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      repeatPassword: ['', Validators.required],
      statusClientId: [StatusClientId.Active, Validators.required]
    });
  }
  ngOnInit(): void {
    this.title = this.activatedRoute.snapshot.data['title'];
    this.mode = this.activatedRoute.snapshot.data['mode'];

    if (this.mode == FormMode.Detail || this.mode == FormMode.Edit) {
      if (this.mode == FormMode.Detail) this.clientForm.disable();
      const clientId = this.activatedRoute.snapshot.params['id'];
      this.clientService.getClientById(clientId).subscribe({
        next: (client) => {
          this.clientForm.patchValue(client);
          this.clientForm.get('birthDate')?.setValue(client.birthDate.substring(0, 10));
          this.clientForm.get('repeatPassword')?.setValue(client.password);
        },
        error: () => {
          this.router.navigate(['/clients']);
        }
      });
    }
  }


  onSubmit() {
    this.clientForm.markAllAsTouched();
    if (this.clientForm.valid) {
      var data = this.clientForm.value;
      var $save = this.mode == FormMode.Add ? this.clientService.post(data) : this.clientService.put(data.clientId, data);
      this.loadingService.showLoading();
      $save.subscribe({
        next: (result) => {
          this.loadingService.hideLoading();
          if (result.success) {
            this.toastService.addSuccess(result.message);
            this.router.navigate([`clients/${result.dataId}/detail`]);
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


  deleteClient() {
    if (this.isDetailMode) {
      if (confirm('¿Está seguro de eliminar este cliente?')) {
        const clientId = this.activatedRoute.snapshot.params['id'];
        this.loadingService.showLoading();
        this.clientService.delete(clientId).subscribe({
          next: (result) => {
            this.loadingService.hideLoading();
            if (result.success) {
              this.toastService.addSuccess(result.message);
              this.router.navigate(['/clients']);
            } else {
              this.toastService.addError(result.message);
            }
          },
          error: (error) => {
            this.loadingService.hideLoading();
            this.toastService.showError(error);
          }
        });
      }
    }
  }

  backPage() {
    this.router.navigate(['/clients']);
  }
}
