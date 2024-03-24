import { Component, OnInit } from '@angular/core';
import { assertExportDefaultSpecifier } from '@babel/types';

@Component({
  selector: 'app-search-orbs',
  templateUrl: './search-orbs.component.html',
  styleUrl: './search-orbs.component.scss'
})
export class SearchOrbsComponent implements OnInit {

  searchResult: Orb[] = [
    {
      location: { state: "Florida", county: "Broward"},
      assessorUrl: "http://www.bcpa.net/search.asp",
      taxUrl: "https://www.broward.county-taxes.com/public",
      landUrl: "http://www.broward.org/RecordsTaxesTreasury/Records/Pages/PublicRecordsSearch.aspx"
    },
    {
      location: { state: "Maryland", county: "Baltimore"},
      assessorUrl: "http://sdat.resiusa.org/RealProperty/Pages/",
      taxUrl: "http://www.baltimorecountymd.gov/Agencies/budfin/taxsearch/index.html",
      landUrl: "http://v3.mdlandrec.net/main/index.cfm?CFID=37749572&CFTOKEN=96667807&jsessionid=ac30c02aebd66aef4aeb124c920121f1444eTR",
    },
    {
      location: { state: "Pennsylvania", county: "Allegheny" },
      assessorUrl: "http://www2.county.allegheny.pa.us/RealEstate/",
      taxUrl: "Use Locality",
      landUrl: "https://pa_allegheny.uslandrecords.com/palr/"
    },
    {
      location: { state: "Pennsylvania", county: "Washington" },
      assessorUrl: "http://washcounty.info/wcmtp/tri.asp",
      taxUrl: "Use Locality",
      landUrl: "http://www.landex.com/webstore/"
    }
  ];

  stateList: string[] = [];
  countyList: string[] = [];

  ngOnInit(): void {
    this.getStates();
  }

  getStates() {
    this.stateList = [... new Set(this.searchResult.map(item => item.location.state))]; 
  }

  getCounties(selectedState: string) {
    this.countyList = [...new Set(this.searchResult.filter((orb) => orb.location.state == selectedState).map(item => item.location.county))];
    console.log(this.countyList);
  }

  onStateChange(newState: any) {
    console.log('State Changed! ', newState);
    this.getCounties(newState);
  }

}

export interface Orb {
  location: StateCounty;
  assessorUrl: string;
  taxUrl: string;
  landUrl: string;
}

export interface StateCounty {
  state: string;
  county: string;
}