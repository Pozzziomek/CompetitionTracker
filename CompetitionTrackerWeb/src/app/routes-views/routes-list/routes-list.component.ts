import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Route } from '../../model/route';
import { Router } from "@angular/router";

@Component({
  selector: 'app-routes-list',
  templateUrl: './routes-list.component.html',
  styleUrls: ['./routes-list.component.css']
})
export class RoutesListComponent implements OnInit {

  routes: Array<Route> = [];
  
  constructor(private http: Http, private router: Router) { }

  ngOnInit() {
    this.http.get("http://localhost:57527/api/routes")
      .map((response) => response.json())
        .subscribe((data) => this.displayData(data));
  }

  displayData(data) {
    data.forEach(element => {
      let o = new Route();
      o.routeId = element.RouteId;
      o.routeName = element.RouteName;
      o.points = element.Points;
      this.routes.push(o);  
    });
  }

  goToRouteForm(event) {
    this.router.navigate(['/route']);
  }
}
