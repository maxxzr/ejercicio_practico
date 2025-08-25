import { StatusClientId } from "../../../shared/enums/enums";

export interface ClientModel
{
    clientId: number;
    name: string;
    documentNumber: string;
    address: string;
    birthDate: string;
    age: number;
    phone: string;
    status: string;
    password: string;
    statusClientId: StatusClientId;
}