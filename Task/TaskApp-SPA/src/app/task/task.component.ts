import { RoomData } from './../_models/roomData';
import { environment } from './../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { RoomService } from '../_services/room.service';
import { HubConnectionBuilder, HubConnection } from '@aspnet/signalr';
import { interval, Subscription } from 'rxjs';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  rooms: RoomData[] = [];
  showInfo = false;
  // i add id in this place because i didnot know if Client have more than one house in that way i have to had list of Houses which
  // the clint have
  id = 'hus1';
  baseUrl = environment.baseUrl;
  isWarning = false;
  hubConnection: HubConnection;
  subscription: Subscription;
  loading = false;
  constructor(private roomService: RoomService) { }

  ngOnInit() {}
  getValue(id) {
    this.roomService.getRoomsInfo(id).subscribe(
      response => {
        this.rooms = response;
        this.showInfo = true;
        this.loading = false;

      },
      error => {
        this.isWarning = true;
        this.loading = false;

      }
    );
  }
  showRoomsInfo() {
    this.loading = true;
    this.hubConnection = new HubConnectionBuilder().withUrl('http://localhost:5000/data').build();
    this.hubConnection.start();
    this.hubConnection.on('refresh', () => {
      this.getValue(this.id);
    });
    const secondsCounter = interval(3000);
    this.subscription = secondsCounter.subscribe(n =>
      this.hubConnection.invoke('refresh'));
  }
  hideRoomsInfo() {
    this.subscription.unsubscribe();
    this.showInfo = false;
    if (this.isWarning) { this.isWarning = false; }
  }

}
