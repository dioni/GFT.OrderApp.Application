import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class OrderService {

    constructor(
        private http: HttpClient, 
        @Inject('BASE_URL') private baseUrl: string) {
      }

      sendOrder(input: string): Observable<any> {
        return this.http.post<string>(this.baseUrl + 'order', input);
      }
}