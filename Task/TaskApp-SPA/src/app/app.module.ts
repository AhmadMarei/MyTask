import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule  } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TaskComponent } from './task/task.component';
import { RoomInfoComponent } from './room-info/room-info.component';
import { RoomService } from './_services/room.service';

@NgModule({
   declarations: [
      AppComponent,
      TaskComponent,
      RoomInfoComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule
   ],
   providers: [
     RoomService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
