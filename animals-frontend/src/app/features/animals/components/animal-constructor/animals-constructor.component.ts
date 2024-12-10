import { ChangeDetectionStrategy, Component, EventEmitter, Output } from '@angular/core';
import {
  AnimalFormComponent,
  AnimalSubmitData,
} from '../shared/animal-form/animal-form.component';

@Component({
  selector: 'app-animals-constructor',
  standalone: true,
  imports: [AnimalFormComponent],
  templateUrl: './animals-constructor.component.html',
  styleUrl: './animals-constructor.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AnimalsConstructorComponent {
  @Output() createAnimal = new EventEmitter();
  
  onSubmit(data: AnimalSubmitData) {
    this.createAnimal.emit(data);
  }
}
