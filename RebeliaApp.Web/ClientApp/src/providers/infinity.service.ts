import { Army, Scenario, FriendlyGameResult } from '../model/Shared';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class InfinityService {
  baseUrl: string = 'https://localhost:5001/'

  constructor(private http: HttpClient) {
    
  }

  public GetInfinityArmies(): Observable<Army[]>{
    return this.http.get<Army[]>(this.baseUrl + 'Api/InfinityEndpoint/GetInfinityArmies');
  }

  public GetInfinityScenarios(): Observable<Scenario[]>{
    return this.http.get<Scenario[]>(this.baseUrl + 'Api/InfinityEndpoint/GetInfinityScenarios');
  }

  public SumbitFriendlyGameResult(request: FriendlyGameResult) {
  }

}

