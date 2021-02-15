import { ResponseBase } from "./ResponseBase";
import { UserAccount } from '../Shared/UserAccount';


export class GetAllAccountsResponse extends ResponseBase {
  accountList: UserAccount[];
}