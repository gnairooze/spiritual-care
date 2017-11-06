import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { IPPerson } from '../models/i-p-person';

@Injectable()
export class PersonService {
  private prefixUrl = 'http://localhost:8050/person/api/';

  private getPersonsUrl = this.prefixUrl + 'P_Person/GetP_Persons';
  private getPersonUrl = this.prefixUrl + 'P_Person/GetP_Persons';

  private getPersonPersonsUrl = this.prefixUrl + 'P_Person_Person/GetP_Person_Persons';
  private getPersonPersonUrl = this.prefixUrl + 'P_Person_Person/GetP_Person_Person';

  private getPersonFacebooksUrl = this.prefixUrl + 'P_Facebook/GetP_Facebooks';
  private getPersonFacebookUrl = this.prefixUrl + 'P_Facebook/GetP_Facebook';

  constructor(private http: HttpClient) { }

  getPersons(): Observable<IPPerson[]> {
    return this.http.get<IPPerson[]>(this.getPersonsUrl);
  }

  getPerson(id: number): Observable<IPPerson> {
    return this.http.get<IPPerson>(this.getPersonUrl + '/' + id);
  }
}
