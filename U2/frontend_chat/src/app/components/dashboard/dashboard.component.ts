import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatsModel } from 'src/app/models/ChatsModel';
import { UserModel } from 'src/app/models/UserModel';
import { RoomsService } from 'src/app/services/rooms.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  roomId: number | undefined;
  private listUsers: UserModel[] = [];
  connectedListUsers: UserModel[] = [];
  private userId: Number = 0;
  private listRooms: ChatsModel[] = [];
  showChatComponent: boolean = false;

  constructor(
    private userService: UsersService,
    private route: ActivatedRoute,
    private roomsService: RoomsService,
  ) { }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.params["userId"]);
    this.loadUsers();
    this.loadRooms();
  }

  loadUsers() {
    this.userService.findAllUsers().subscribe(data => {
      this.listUsers = data;
      console.log("DASHBOARD: ", this.listUsers);
      this.listUsers.forEach((user: UserModel) => {
        if (this.userId != user.id) {
          this.connectedListUsers.push(user);
        }
      });
    });
  }

  loadRooms() {
    this.roomsService.findAllChats().subscribe(data => {
      this.listRooms = data;
    });
  }

  sendIdRoom(userId: number | undefined) {
    for (let i = 0; i < this.listRooms.length; i++) {
      if ((userId == this.listRooms[i].user1 || userId == this.listRooms[i].user2) && (this.userId == this.listRooms[i].user1 || this.userId  == this.listRooms[i].user2)) {
        console.log(userId, " = ", this.listRooms[i].user1);
        this.roomId = this.listRooms[i].id;
        break;
      } else{
        this.roomId = 0;
      }
    }
    this.showChatComponent = true;
  }

  grupalChat(){
    this.roomId = 0;
    this.showChatComponent = true;
  }

}
