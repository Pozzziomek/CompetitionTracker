import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Contestant } from '../../model/contestant';
import { Router } from "@angular/router";
import { Http, Headers } from '@angular/http';
import { Route } from '../../model/route';

@Component({
  selector: 'app-route',
  templateUrl: './route.component.html',
  styleUrls: ['./route.component.css']
})
export class RouteComponent implements OnInit {

  formData;
  route: Route = new Route();

  constructor(private router: Router, private http: Http) { }

  ngOnInit() {
    this.formData = new FormGroup({
      routeName:  new FormControl("", [
        Validators.required,
        Validators.maxLength(100)
      ]),
      points: new FormControl("", [
        Validators.required,
        Validators.min(10),
        Validators.max(1000)
      ])
    });
  }

  onClickSubmit(data) {
    this.route.routeName = data.routeName;
    this.route.points = data.points;
    const body = this.route;

    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    this.http.post("http://localhost:57527/api/routes", this.route, { headers: headers})
      .subscribe(
        data => this.router.navigate(['/routes']),
        error => console.log("Błąd przy dodawaniu trasy!")
      );
      //TODO: sprawdzenie w if poprawności danych
  }

}
