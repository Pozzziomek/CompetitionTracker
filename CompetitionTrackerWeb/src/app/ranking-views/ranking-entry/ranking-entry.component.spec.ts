import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RankingEntryComponent } from './ranking-entry.component';

describe('RankingEntryComponent', () => {
  let component: RankingEntryComponent;
  let fixture: ComponentFixture<RankingEntryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RankingEntryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RankingEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
