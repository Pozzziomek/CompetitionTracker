import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RankingEntriesListComponent } from './ranking-entries-list.component';

describe('RankingEntriesListComponent', () => {
  let component: RankingEntriesListComponent;
  let fixture: ComponentFixture<RankingEntriesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RankingEntriesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RankingEntriesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
