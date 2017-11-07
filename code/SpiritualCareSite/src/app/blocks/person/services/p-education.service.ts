import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPEducation } from '../models/i-p-education';

@Injectable()
export class PEducationService {
  private getAllUrl = this.config.BaseURL + 'P_Education/GetP_Educations';
  private getOneUrl = this.config.BaseURL + 'P_Education/GetP_Education';
  private addUrl = this.config.BaseURL + 'P_Education/PostP_Education';
  private updateUrl = this.config.BaseURL + 'P_Education/PutP_Education';
  private deleteUrl = this.config.BaseURL + 'P_Education/DeleteP_Education';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPEducation[]> {
    return this.http.get<IPEducation[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPEducation> {
    return this.http.get<IPEducation>(this.getOneUrl + '/' + id);
  }

  add(person: IPEducation): Observable<IPEducation> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPEducation);
  }

  update(person: IPEducation): Observable<IPEducation> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPEducation);
  }

  delete(id: number): Observable<IPEducation> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPEducation);
  }
}
