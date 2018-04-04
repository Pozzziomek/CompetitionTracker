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

@NgModule({
  declarations: [
    AppComponent,
    ContestantsListComponent,
    ContestantComponent,
    RoutesListComponent,
    RouteComponent
  ],
  imports: [
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
   ]),
   FormsModule,
   ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
