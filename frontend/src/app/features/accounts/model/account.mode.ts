import { AccountTypeId, StatusAccountId } from "../../../shared/enums/enums";

export interface AccountModel{
    accountId: number;
    clientId: number;
    clientName?:string;
    number: string;
    accountTypeId: AccountTypeId;
    accountTypeDescription?: string;
    initialBalance: number;
    currentBalance: number;
    statusAccountId: StatusAccountId;
    statusAccountDescription?:string;
}