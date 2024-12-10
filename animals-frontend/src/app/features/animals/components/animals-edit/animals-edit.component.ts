import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AnimalsDataService } from '../../../../core/services/animals.data.service';
import { Animal } from '../../../../core/models/animal.model';
import {
  BehaviorSubject,
  catchError,
  delay,
  of,
  Subject,
  take,
  tap,
} from 'rxjs';

import {
  AnimalFormComponent,
  AnimalSubmitData,
} from '../shared/animal-form/animal-form.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-animals-edit',
  standalone: true,
  imports: [AnimalFormComponent, CommonModule],
  templateUrl: './animals-edit.component.html',
  styleUrl: './animals-edit.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AnimalsEditComponent {
  animalId: number;
  animal$ = new Subject<Animal | null>();
  loadingError$ = new BehaviorSubject<boolean>(false);

  $navigateOnError = new Subject().pipe(
    delay(1000),
    tap(() => {
      this.router.navigate(['/']);
    })
  );

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private animalsDataService: AnimalsDataService
  ) {
    this.animalId = Number(this.route.snapshot.paramMap.get('id'));
    this.animalsDataService
      .getById(this.animalId)
      .pipe(
        tap((animal) => {
          this.animal$.next(animal);
        }),
        take(1),
        catchError(() => {
          this.loadingError$.next(true);
          return of(null);
        })
      )
      .subscribe();
  }

  updateAnimal(animalSubmitData: AnimalSubmitData) {
    const animal = new Animal(
      this.animalId,
      animalSubmitData.name,
      animalSubmitData.type
    );

    this.animalsDataService
      .update(animal, this.animalId)
      .pipe(
        tap(() => {
          this.router.navigate(['/']);
        }),
        take(1),
        catchError(() => {
          this.loadingError$.next(true);
          return of(null);
        })
      )
      .subscribe();
  }
}
