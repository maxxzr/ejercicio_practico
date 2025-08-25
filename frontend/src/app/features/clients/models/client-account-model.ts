import { AccountTypeId, StatusAccountId, StatusClientId } from "../../../shared/enums/enums";

export interface ClientAccountModel
{
    clientId: number;
    accountId: number;
    number: string;
    accountTypeId: AccountTypeId;
    accountTypeDescription: string;
    statusAccountDescription: string;
    statusAccountId: StatusAccountId;
    initialBalance: number;
    currentBalance: number;
}