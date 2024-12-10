import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { Animal } from '../../../../core/models/animal.model';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-animals-list',
  standalone: true,
  imports: [ButtonModule, CommonModule],
  templateUrl: './animals-list.component.html',
  styleUrl: './animals-list.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AnimalsListComponent {
  @Output() animalEdit = new EventEmitter<Animal>();
  @Output() animalDelete = new EventEmitter<Animal>();
  @Input() animals: Animal[] = [];

  onEdit(animal: Animal) {
    this.animalEdit.emit(animal);
  }

  onDelete(animal: Animal) {
    this.animalDelete.emit(animal);
  }
}
