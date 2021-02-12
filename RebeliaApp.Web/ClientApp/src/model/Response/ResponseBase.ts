import { ResponseCode } from "../Shared/Enums";

export class ResponseBase {
  responseCode: ResponseCode;
  responseHeader: string;
  responseMessage: string;
}