import { TransactionTypeId } from "../../../shared/enums/enums";

export interface TransactionModel {
    statusAccountDescription: string;
    accountTypeDescription: string;
    accountNumber: string;
    clientName: string;
    transactionId: number;
    accountId: number;
    amount: number;
    balance: number;
    dateTransaction: Date;
    initialBalance: number;
    transactionTypeId: TransactionTypeId;
}