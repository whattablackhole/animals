import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimalsConstructorComponent } from './animals-constructor.component';

describe('AnimalsConstructorComponent', () => {
  let component: AnimalsConstructorComponent;
  let fixture: ComponentFixture<AnimalsConstructorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnimalsConstructorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnimalsConstructorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
