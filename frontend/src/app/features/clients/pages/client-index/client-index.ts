import { Component, inject, signal } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { ClientModel } from '../../models/client.model';
import { CommonModule } from '@angular/common';
import { toSignal } from '@angular/core/rxjs-interop';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, distinctUntilChanged, startWith, switchMap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-client-index',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './client-index.html',
  styleUrl: './client-index.css'
})
export class ClientIndex {

  private router = inject(Router);
  private clientService = inject(ClientService);
    searchControl = new FormControl('');
    clients = toSignal(
      this.searchControl.valueChanges.pipe(
        startWith(''),
        debounceTime(500),
        distinctUntilChanged(),
        switchMap(name => this.clientService.search(name || ''))
      ),
      { initialValue: [] }
  );

  onNewClient() {
    this.router.navigate(['/clients/add']);
  }
}
