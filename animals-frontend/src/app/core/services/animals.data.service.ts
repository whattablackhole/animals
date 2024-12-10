import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Animal } from '../models/animal.model';
import { BaseDataService } from './base-data.service';
import {
  BehaviorSubject,
  Observable,
  catchError,
  take,
  tap,
} from 'rxjs';
import { environment } from '../../../environment/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class AnimalsDataService extends BaseDataService<Animal> {
  private animals$ = new BehaviorSubject<Animal[]>([]);

  constructor(http: HttpClient) {
    super(http, environment.animalsApiBaseUrl);
  }

  override create(item: Omit<Animal, 'id'>): Observable<Animal> {
    return super.create(item).pipe(
      tap(() => this.refreshAnimals()),
      take(1),
      catchError((err) => {
        console.error('Error creating animal:', err);
        throw err;
      })
    );
  }

  override delete(id: number): Observable<Animal> {
    return super.delete(id).pipe(
      tap(() => this.refreshAnimals()),
      take(1),
      catchError((err) => {
        console.error('Error deleting animal:', err);
        throw err;
      })
    );
  }

  refreshAnimals(): void {
    this.getAll()
      .pipe(
        take(1),
        catchError((err) => {
          console.error('Error refreshing animals:', err);
          throw err;
        })
      )
      .subscribe((animals) => this.animals$.next(animals));
  }

  getAnimals$(): Observable<Animal[]> {
    return this.animals$.asObservable();
  }
}
