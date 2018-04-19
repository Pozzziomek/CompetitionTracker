import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-info',
  templateUrl: './modal-info.component.html',
  styleUrls: ['./modal-info.component.css']
})
export class ModalInfoComponent implements OnInit {

  @Input() rankingEntryId: number;
  
  constructor(private http: Http, private router: Router, public activeModal: NgbActiveModal) { }

  ngOnInit() {
    
  }

  confirmDelete() {
    this.http.delete("http://localhost:57527/api/rankingentries/" + this.rankingEntryId)
      .subscribe(
        data => {
          this.activeModal.close();
        },
        error => alert("Błąd usunięcia wpisu z rankingu!")
      );
  }
}
