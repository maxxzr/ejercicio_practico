import { ClientModel } from "./client.model";

export interface ClientRequestModel extends ClientModel
{
    personId: number;
    repeatPassword: string;
}