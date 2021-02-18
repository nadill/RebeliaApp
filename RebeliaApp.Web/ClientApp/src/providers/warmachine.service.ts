import { Army, Scenario } from '../model/Shared';
import { FriendlyGameResultRequest } from '../model/Request/FriendlyGameResultRequest';
import { FriendlyGameResultResponse } from '../model/Response/FriendlyGameResultResponse';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class WarmachineService {
  baseUrl: string = 'https://localhost:5001/'

  constructor(private http: HttpClient) {

  }

  public GetWarmachineArmies(): Observable<Army[]> {
    return this.http.get<Army[]>(this.baseUrl + 'Api/WarmachineEndpoint/GetWarmachineArmies');
  }

  public GetWarmachineScenarios(): Observable<Scenario[]> {
    return this.http.get<Scenario[]>(this.baseUrl + 'Api/WarmachineEndpoint/GetWarmachineScenarios');
  }

  public SubmitFriendlyGameResult(request: FriendlyGameResultRequest): Observable<FriendlyGameResultResponse> {
    return this.http.post<FriendlyGameResultResponse>(this.baseUrl + 'Api/WarmachineEndpoint/SubmitFriendlyGameResult', request);
  }

}

