import { Component } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
stateChanged(value: any) {
  this.selectedState = value;
}
  states = [
    { st: 'PA'},
    { st: 'MD'}, 
    { st: 'FL'}
  ];

  selectedState?: {};
}
