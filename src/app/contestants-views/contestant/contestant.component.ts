import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Contestant } from '../../model/contestant';
import { Router } from "@angular/router";
import { Http, Headers } from '@angular/http';

@Component({
  selector: 'app-contestant',
  templateUrl: './contestant.component.html',
  styleUrls: ['./contestant.component.css']
})
export class ContestantComponent implements OnInit {

  formData;
  contestant: Contestant = new Contestant();

  constructor(private router: Router, private http: Http) { }

  ngOnInit() {
    this.formData = new FormGroup({
      firstName:  new FormControl("", [
        Validators.required,
        this.dataLengthValidation
      ]),
      lastName: new FormControl("", [
        Validators.required,
        this.dataLengthValidation
      ])
    });
  }

  dataLengthValidation(formControl: FormControl) {
    if (formControl.value.length < 3 || formControl.value.length > 40) {
      return {dataLengthValidation: true}
    }
    return null;
  }

  onClickSubmit(data) {
    this.contestant.firstName = data.firstName;
    this.contestant.lastName = data.lastName;
    const body = this.contestant;

    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    this.http.post("http://localhost:57527/api/contestants", this.contestant, { headers: headers})
      .subscribe(
        data => this.router.navigate(['/contestants']),
        error => console.log("Cos nie dziala!")
      );
      //TODO: sprawdzenie w if poprawności danych
  }
}