export class Animal {
  constructor(public id: number, public name: string, public type: string) {}
}

export class AnimalCreate {
  constructor(public name: string, public type: string) {}
}
