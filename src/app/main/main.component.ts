import { Component } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
stateChanged(value: any) {
  this.selectedState = value;
  this.counties = this.allCounties.filter((c) => c.st == this.selectedState);
}

countyChanged(value: any) {
  this.selectedCounty = value;
}

  states = [
    { st: 'PA'},
    { st: 'MD'}, 
    { st: 'FL'}
  ];

  allCounties = [
    { county: 'ALLEGHENY', st: 'PA'},
    { county: 'WASHINGTON', st: 'PA'},
    { county: 'BEAVER', st: 'PA'},
    { county: 'ANNEARUNDEL', st: 'MD'},
    { county: 'BALTIMORE', st: 'MD'},
    { county: 'PALMBEACH', st: 'FL'},
    { county: 'BROWARD', st: 'FL'},
    { county: 'BREVARD', st: 'FL'}
  ];

  counties = [
    { county: '', st: '' }
  ];

  selectedCounty? : {};
  selectedState?: {};
}
