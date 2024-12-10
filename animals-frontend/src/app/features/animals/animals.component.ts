import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Animal, AnimalCreate } from '../../core/models/animal.model';
import { AnimalsDataService } from '../../core/services/animals.data.service';
import { Observable } from 'rxjs';
import { AnimalsConstructorComponent } from './components/animal-constructor/animals-constructor.component';
import { AnimalsListComponent } from './components/animal-list/animals-list.component';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AnimalSubmitData } from './components/shared/animal-form/animal-form.component';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html',
  styleUrls: ['./animals.component.scss'],
  standalone: true,
  imports: [AnimalsConstructorComponent, AnimalsListComponent, CommonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AnimalsComponent {
  animals$: Observable<Animal[]>;

  constructor(
    private readonly animalsDataService: AnimalsDataService,
    private readonly router: Router
  ) {
    this.animals$ = this.animalsDataService.getAnimals$();
  }

  ngOnInit() {
    this.animalsDataService.refreshAnimals();
  }

  deleteAnimal(animal: Animal) {
    this.animalsDataService.delete(animal.id).subscribe();
  }

  editAnimal(animal: Animal) {
    this.router.navigate([`edit`, animal.id]);
  }

  createAnimal(data: AnimalSubmitData) {
    const newAnimal: AnimalCreate = { name: data.name, type: data.type };
    this.animalsDataService.create(newAnimal).subscribe();
  }
}
