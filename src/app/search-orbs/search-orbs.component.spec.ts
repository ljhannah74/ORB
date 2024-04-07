import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchOrbsComponent } from './search-orbs.component';

describe('SearchOrbsComponent', () => {
  let component: SearchOrbsComponent;
  let fixture: ComponentFixture<SearchOrbsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SearchOrbsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SearchOrbsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});
