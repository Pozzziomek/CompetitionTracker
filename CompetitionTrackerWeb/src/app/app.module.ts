import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { ContestantsListComponent } from './contestants-views/contestants-list/contestants-list.component';

import { HttpModule } from '@angular/http';
import { RouterModule} from '@angular/router';
import { ContestantComponent } from './contestants-views/contestant/contestant.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RoutesListComponent } from './routes-views/routes-list/routes-list.component';
import { RouteComponent } from './routes-views/route/route.component';
import { RankingEntriesListComponent } from './ranking-views/ranking-entries-list/ranking-entries-list.component';
import { RankingEntryComponent } from './ranking-views/ranking-entry/ranking-entry.component';
import { ModalInfoComponent } from './modal-info/modal-info.component';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    ContestantsListComponent,
    ContestantComponent,
    RoutesListComponent,
    RouteComponent,
    RankingEntriesListComponent,
    RankingEntryComponent,
    ModalInfoComponent
  ],
  entryComponents: [ModalInfoComponent],
  imports: [
    NgbModule.forRoot(),
    BrowserModule,
    HttpModule,
    RouterModule.forRoot([
      {
         path: 'contestants',
         component: ContestantsListComponent
      },
      {
        path: 'contestant',
        component: ContestantComponent
      },
      {
        path: 'routes',
        component: RoutesListComponent
      },
      {
        path: 'route',
        component: RouteComponent
      },
      {
        path: 'ranking',
        component: RankingEntriesListComponent
      },
      {
        path: 'ranking-entry',
        component: RankingEntryComponent
      },
      // Added in the end, because Angular matches path from top to bottom 
      {
        path: '**',
        redirectTo: '/ranking', 
        pathMatch:'full'
      }
   ]),
   FormsModule,
   ReactiveFormsModule
  ],
  providers: [NgbActiveModal],
  bootstrap: [AppComponent]
})
export class AppModule { }
