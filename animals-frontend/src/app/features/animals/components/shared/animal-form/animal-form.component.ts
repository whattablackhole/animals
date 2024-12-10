import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { Animal } from '../../../../../core/models/animal.model';
import { animalTypes } from '../../../mocks/animal-types';

export interface AnimalSubmitData extends Omit<Animal, 'id'> {}

@Component({
  selector: 'app-animal-form',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    DropdownModule,
    InputTextModule,
    CommonModule,
  ],
  templateUrl: './animal-form.component.html',
  styleUrl: './animal-form.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AnimalFormComponent {
  // could be animal editable controls
  @Input() animal?: Animal;
  @Input() captions?: { submitCaption: string };
  @Input() viewType: 'column' | 'default' = 'default';
  @Output() onValueSubmit = new EventEmitter<AnimalSubmitData>();

  animalTypeOptions;

  form: FormGroup;

  constructor(private readonly fb: FormBuilder) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      type: ['', Validators.required],
    });
    this.animalTypeOptions = animalTypes.map((t) => ({ name: t }));
  }

  ngOnInit() {
    if (this.animal) {
      this.form.patchValue({ name: this.animal.name });
      this.form.patchValue({ type: { name: this.animal.type } });
    }
  }

  onSubmit() {
    if (this.form.valid) {
      const formData = this.form.value;

      this.onValueSubmit.next({
        name: formData.name,
        type: formData.type.name,
      });
    }
    {
      //TODO: add validation errors;
    }
  }
}
