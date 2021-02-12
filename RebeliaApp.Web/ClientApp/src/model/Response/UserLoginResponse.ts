import { UserAccount } from "../Shared/UserAccount";
import { ResponseBase } from "./ResponseBase";

export class UserLoginResponse extends ResponseBase {
  tokenString: string;

}