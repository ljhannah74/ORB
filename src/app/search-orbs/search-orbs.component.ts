import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-search-orbs',
    templateUrl: './search-orbs.component.html',
    styleUrl: './search-orbs.component.scss'
})
export class SearchOrbsComponent implements OnInit {

    orbsList: Orb[] = [
        {
            location: { state: "Florida", county: "Broward" },
            assessorUrl: "http://www.bcpa.net/search.asp",
            taxUrl: "https://www.broward.county-taxes.com/public",
            landUrl: "http://www.broward.org/RecordsTaxesTreasury/Records/Pages/PublicRecordsSearch.aspx"
        },
        {
            location: { state: "Maryland", county: "Baltimore" },
            assessorUrl: "https://sdat.dat.maryland.gov/RealProperty/Pages/default.aspx",
            taxUrl: "https://www.baltimorecountymd.gov/departments/budfin/taxpayer-services/tax-search",
            landUrl: "https://mdlandrec.net/main/",
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
    selectedOrb: Orb[] = [];

    selectedStateCounty: StateCounty = { state: "", county: "" };


    ngOnInit(): void {
        this.getStates();
    }

    getStates() {
        this.stateList = [... new Set(this.orbsList.map(item => item.location.state))];
    }

    getCounties(selectedState: string) {
        this.selectedStateCounty.state = selectedState;
        this.countyList = [...new Set(this.orbsList.filter((orb) => orb.location.state == selectedState).map(item => item.location.county))];
    }

    getOrbs() {
        this.selectedOrb = this.orbsList.filter((orb) => orb.location.state == this.selectedStateCounty.state && orb.location.county == this.selectedStateCounty.county);
        console.log(this.selectedOrb);
    }

    onStateChange(newState: any) {
        this.getCounties(newState);
    }

    onSearchClicked(newCounty: any) {
        this.selectedStateCounty.county = newCounty;
        this.getOrbs();
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