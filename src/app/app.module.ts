import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { ContestantsListComponent } from './contestants-views/contestants-list/contestants-list.component';

import { HttpModule } from '@angular/http';
import { RouterModule} from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    ContestantsListComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule.forRoot([
      {
         path: 'contestants',
         component: ContestantsListComponent
      }
   ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
