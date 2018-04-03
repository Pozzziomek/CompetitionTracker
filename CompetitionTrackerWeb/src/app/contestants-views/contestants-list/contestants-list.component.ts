import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Contestant } from '../../model/contestant';
import {Router} from "@angular/router";

@Component({
  selector: 'app-contestants-list',
  templateUrl: './contestants-list.component.html',
  styleUrls: ['./contestants-list.component.css']
})
export class ContestantsListComponent implements OnInit {

  contestants: Array<Contestant> = [];
  
  constructor(private http: Http, private router: Router) { }

  ngOnInit() {
    this.http.get("http://localhost:57527/api/contestants")
      .map((response) => response.json())
        .subscribe((data) => this.displayData(data));
  }

  displayData(data) {
    data.forEach(element => {
      let o = new Contestant();
      o.firstName = element.FirstName;
      o.lastName = element.LastName;
      this.contestants.push(o);
    });
  }

  goToContestantForm(event) {
    this.router.navigate(['/contestant']);
  }
}
