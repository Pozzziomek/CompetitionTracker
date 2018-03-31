import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Contestant } from '../../model/contestant';

@Component({
  selector: 'app-contestants-list',
  templateUrl: './contestants-list.component.html',
  styleUrls: ['./contestants-list.component.css']
})
export class ContestantsListComponent implements OnInit {

  contestants: Array<Contestant> = [];
  constructor(private http: Http) { }

  ngOnInit() {
    this.http.get("http://localhost:57527/api/contestants")
      .map((response) => response.json())
        .subscribe((data) => this.displayData(data));
  }

  displayData(data) {
    data.forEach(element => {
      this.contestants.push(new Contestant(element.FirstName, element.LastName))
    });
  }
}
