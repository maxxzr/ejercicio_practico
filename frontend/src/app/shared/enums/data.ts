import { SelectItemModel } from "../models/select-item.model";
import { AccountTypeId, GenderId, StatusAccountId, StatusClientId, TransactionTypeId } from "./enums";

export const Genders: SelectItemModel[] = [
    { id: GenderId.Male, name: 'Masculino' },
    { id: GenderId.Female, name: 'Femenino' }
];

export const StatusClient: SelectItemModel[] = [
    { id: StatusClientId.Active, name: 'Activo' },
    { id: StatusClientId.Inactive, name: 'Inactivo' },
    { id: StatusClientId.Suspended, name: 'Suspendido' },
];

export const StatusAccount: SelectItemModel[] = [
    { id: StatusAccountId.Enabled, name: 'Habilitada' },
    { id: StatusAccountId.Blocked, name: 'Bloqueada' },
    { id: StatusAccountId.Suspended, name: 'Suspendida' },
];

export const AccountTypes: SelectItemModel[] = [
    { id: AccountTypeId.Simple, name: 'Simple' },
    { id: AccountTypeId.Current, name: 'Corriente' },
];

export const TransactionTypes: SelectItemModel[] = [
    { id: TransactionTypeId.Debit, name: 'Debito' },
    { id: TransactionTypeId.Credit, name: 'Credito' },
];