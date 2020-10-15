import { Injectable } from '@angular/core';
import { Cat } from './cat';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CatService {
  constructor(private httpClient: HttpClient) { }

  url: string = "api/owner";

  get(): Observable<Cat[]> {
    return this.httpClient.get<Cat[]>(this.url);
  }
}
