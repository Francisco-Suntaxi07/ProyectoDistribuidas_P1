import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatsModel } from 'src/app/models/ChatsModel';
import { UserModel } from 'src/app/models/UserModel';
import { RoomsService } from 'src/app/services/rooms.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  private userId: number | undefined;
  private listUsers: UserModel[] = [];
  private connectedListUsers: UserModel[] = [];
  private listRooms: ChatsModel[] = [];

  constructor(
    private route: ActivatedRoute,
    private userService: UsersService,
    private roomsService: RoomsService,
  ) { }

  ngOnInit(): void {
    this.userId = this.route.snapshot.params["userId"];
    console.log("HOME: ", this.userId);
    this.loadUsers();
    this.loadRooms();
    this.createRooms();
  }

  loadUsers() {
    this.userService.findAllUsers().subscribe(data => {
      this.listUsers = data;
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

  createRooms() {
    let room: ChatsModel = new ChatsModel();
    room.user1 = this.userId;
    try {
      this.connectedListUsers.forEach((user: UserModel) => {
        room.user2 = user.id;
        if (this.verifyRooms(room.user2)) {
          this.roomsService.saveChats(room).subscribe({
            next: () => {
              console.log("Sala creada para el usuario con ID: ", user.id);
            },
            error: (error) => {
              console.log("Error al crear sala para el usuario con ID: ", user.id, error);
            }
          });
        }else{
          console.log("Ya existe la sala: ", room);
        }

      });
    } catch (error) {
      console.error(error);
    }

  }

  verifyRooms(room: number | undefined): boolean {
    this.loadUsers();
    this.loadRooms();
    for (let i = 0; i < this.listRooms.length; i++) {
      if ((this.userId == this.listRooms[i].user1) || (this.userId == this.listRooms[i].user2)) {
        if( room == this.listRooms[i].user1 || room == this.listRooms[i].user2){
          return false;
        }
        
      }
    }
    return true;
  }


}
