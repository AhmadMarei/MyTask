import { RoomData } from './../_models/roomData';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-room-info',
  templateUrl: './room-info.component.html',
  styleUrls: ['./room-info.component.css']
})
export class RoomInfoComponent implements OnInit {
  public now: Date = new Date();
  @Input() roomData: RoomData;
  constructor() { }

  ngOnInit() {
  }

}
//  RoomInfoComponent is child component to TaskComponent
