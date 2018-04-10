import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { RankingEntry } from '../../model/ranking-entry';
import { Router } from "@angular/router";

@Component({
  selector: 'app-ranking-entries-list',
  templateUrl: './ranking-entries-list.component.html',
  styleUrls: ['./ranking-entries-list.component.css']
})
export class RankingEntriesListComponent implements OnInit {

  constructor(private http: Http, private router: Router) { }

  rankingEntries: Array<RankingEntry> = [];

  ngOnInit() {
    this.http.get("http://localhost:57527/api/rankingentries")
    .map((response) => response.json())
    .subscribe((data) => this.displayData(data));
  }

  displayData(data) {
    data.forEach(element => {
      let o = new RankingEntry();
      o.contestantFirstName = element.Contestant.FirstName;
      o.contestantLastName = element.Contestant.LastName;
      o.contestantPointsSum = element.PointsSum;
      o.contestantRoutes = element.ContestantRoutes;
      this.rankingEntries.push(o);
    });
  }

  goToRankingEntryForm(event) {
    this.router.navigate(['/ranking-entry']);
  }
}
