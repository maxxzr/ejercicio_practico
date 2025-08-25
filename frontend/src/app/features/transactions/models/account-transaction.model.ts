import { AccountTypeId, StatusAccountId } from "../../../shared/enums/enums";

export interface AccountTransaction{
    accountId:number;
    number:string;
    clientName:string;
    accountTypeDescription:string;
    accountTypeId:AccountTypeId;
    statusAccountId:StatusAccountId;
}