import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { RankingEntry } from '../../model/ranking-entry';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalInfoComponent } from '../../modal-info/modal-info.component';

@Component({
  selector: 'app-ranking-entries-list',
  templateUrl: './ranking-entries-list.component.html',
  styleUrls: ['./ranking-entries-list.component.css']
})
export class RankingEntriesListComponent implements OnInit {

  constructor(private http: Http, private router: Router, private modal: NgbModal) { }

  rankingEntries: Array<RankingEntry> = [];

  ngOnInit() {
    this.loadRankingEntries();
  }

  loadRankingEntries() {
    this.http.get("http://localhost:57527/api/rankingentries")
    .map((response) => response.json())
    .subscribe((data) => this.mapData(data));
  }

  mapData(data) {
    this.rankingEntries = [];
    data.forEach(element => {
      let o = new RankingEntry();
      o.rankingEntryId = element.RankingEntryId;
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

  onClick(entryId: number) {
    let options: any = {
      size: "dialog-centered"
    };

    const modalRef = this.modal.open(ModalInfoComponent, options);
    modalRef.componentInstance.rankingEntryId = entryId;
    modalRef.result.then(
      (result) => {
        this.loadRankingEntries()
      },
      (reason) => console.log(`Dismissed with ${reason}`)
    );
  }
}
