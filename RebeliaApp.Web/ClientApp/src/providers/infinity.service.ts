import { Army, Scenario } from '../model/Shared';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class InfinityService{
  baseUrl: string = 'https://localhost:5001/'

  constructor(private http: HttpClient) {
    
  }

  public GetInfinityArmies(): Observable<Army[]>{
    return this.http.get<Army[]>(this.baseUrl + 'api/GameData/GetInfinityArmies');
    
  }

  public GetInfinityScenarios(): Observable<Scenario[]>{
    return this.http.get<Scenario[]>(this.baseUrl + 'api/GameData/GetInfinityScenarios');
  }

}

