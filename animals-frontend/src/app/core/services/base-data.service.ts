import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export abstract class BaseDataService<T> {
  constructor(protected http: HttpClient, private baseUrl: string) {}

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl);
  }

  getById(id: number): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`);
  }

  create(item: Omit<T, 'id'>): Observable<T> {
    return this.http.post<T>(this.baseUrl, item);
  }

  update(item: T, id: number): Observable<T> {
    return this.http.patch<T>(`${this.baseUrl}/${id}`, item);
  }

  delete(id: number): Observable<T> {
    return this.http.delete<T>(`${this.baseUrl}/${id}`);
  }
}
