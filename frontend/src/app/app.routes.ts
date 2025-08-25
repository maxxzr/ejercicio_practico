import { Routes } from '@angular/router';
import { ClientIndex } from './features/clients/pages/client-index/client-index';
import { ClientForm } from './features/clients/pages/client-form/client-form';
import { FormMode } from './shared/enums/enums';
import { ClientAccounts } from './features/clients/pages/client-accounts/client-accounts';
import { AccountTransactions } from './features/accounts/pages/account-transactions/account-transactions';
import { AccountIndex } from './features/accounts/pages/account-index/account-index';
import { TransactionIndex } from './features/transactions/pages/transaction-index/transaction-index';

export const routes: Routes = [
    { path: '', component: ClientIndex },
    { path: 'clients', component: ClientIndex },
    { path: 'clients/add', component: ClientForm, data: { title: 'Nuevo cliente', mode: FormMode.Add } },
    { path: 'clients/:id/edit', component: ClientForm, data: { title: 'Editar cliente', mode: FormMode.Edit } },
    { path: 'clients/:id/detail', component: ClientForm, data: { title: 'Detalle cliente', mode: FormMode.Detail } },
    { path: 'clients/:id/accounts', component: ClientAccounts, data: { title: 'Cuentas cliente'} },
    { path: 'accounts/:id/transactions', component: AccountTransactions, data: { title: 'Movimientos cuenta', mode: FormMode.Detail } },
    { path: 'accounts', component: AccountIndex},
    { path: 'transactions', component: TransactionIndex},
    { path: '*', component: ClientIndex },
];
