import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Contestant } from '../../model/contestant';
import { Router } from '@angular/router';
import { RankingEntry } from '../../model/ranking-entry';
import { Route } from '../../model/route';
import { RankingEntryDetails } from '../../model/ranking-entry-details';
 
@Component({
  selector: 'app-ranking-entry',
  templateUrl: './ranking-entry.component.html',
  styleUrls: ['./ranking-entry.component.css']
})
export class RankingEntryComponent implements OnInit {

  contestants: Array<Contestant> = [];
  routes: Array<Route> = [];
  rankingEntryDetails: RankingEntryDetails = new RankingEntryDetails();

  constructor(private http: Http, private router: Router) { }

  ngOnInit() {
    this.http.get("http://localhost:57527/api/contestants")
    .map((response) => response.json())
      .subscribe((data) => this.displayContestantData(data));
    
    this.http.get("http://localhost:57527/api/routes")
    .map((response) => response.json())
      .subscribe((data) => this.displayRouteData(data));
  }

  displayContestantData(data) {
    data.forEach(element => {
      let o = new Contestant();
      o.contestantId = element.ContestantId;
      o.firstName = element.FirstName;
      o.lastName = element.LastName;
      this.contestants.push(o);
    });
  }

  displayRouteData(data) {
    data.forEach(element => {
      let o = new Route();
      o.routeId = element.RouteId;
      o.routeName = element.RouteName;
      o.points = element.Points;
      this.routes.push(o);  
    });
  }

  setContestant(id: number) {
    this.rankingEntryDetails.contestantId = id;
  }

  setRoute(id: number) {
    this.rankingEntryDetails.routeId = id;
  }

  onClickSubmit() {
    const body = this.rankingEntryDetails;

    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    this.http.post("http://localhost:57527/api/rankingentries", body, { headers: headers})
      .subscribe(
        data => this.router.navigate(['/ranking']),
        error => console.log("Błąd dodania wpisu do rankingu!")
      );
  }
}
