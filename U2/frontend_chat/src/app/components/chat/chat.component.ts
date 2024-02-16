import { Component, ElementRef, OnInit, QueryList, ViewChildren, Input  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserModel } from 'src/app/models/UserModel';
import { ChatMessage } from 'src/app/models/chat-message';
import { ChatService } from 'src/app/services/chat.service';
import { RoomsService } from 'src/app/services/rooms.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  @Input() roomId: number | undefined;

  messageInput: string = '';
  userId: string="";
  messageList: any[] = [];
  user1: UserModel = new UserModel();
  user2: UserModel = new UserModel();

  constructor(
    private chatService: ChatService,
    private route: ActivatedRoute,
    private userService: UsersService,
    private roomService: RoomsService
    ) { }

  ngOnInit(): void {
    let roomIdString: string;
    this.userId = this.route.snapshot.params["userId"];
    if (this.roomId !== undefined) {
      roomIdString = this.roomId.toString();
    } else {
      roomIdString = "0";
    }
    console.log("SALA ROOM CREADA: ", roomIdString);
    this.chatService.joinRoom(roomIdString);
    this.lisenerMessage();
    this.findUsers();
  }

  findUsers(){
    let room;
    let axuUser2;
    this.userService.findUserById(Number(this.userId)).subscribe(data =>{
      this.user1 = data;
    });
    this.roomService.findChatsById(this.roomId).subscribe(data => {
      room = data;
      if(this.user1.id == room.user1){
        axuUser2=room.user2;
      }else{
        axuUser2=room.user1;
      }
      this.userService.findUserById(Number(axuUser2)).subscribe(data =>{
        this.user2 = data;
       // console.log("USUARIO 1:" , this.user1.name);
        //console.log("USUARIO 2:" , this.user2.name);
      });
      
    });
  
  }

  sendMessage() {
    let roomIdString: string;
    const chatMessage = {
      message: this.messageInput,
      user: this.userId
    }as ChatMessage
    if (this.roomId !== undefined) {
      roomIdString = this.roomId.toString();
    } else {
      roomIdString = "0";
    }
    this.chatService.sendMessage(roomIdString, chatMessage);
    this.messageInput = '';
  }

  lisenerMessage() {
    this.chatService.getMessageSubject().subscribe((messages: any) => {
      this.messageList = messages.map((item: any)=> ({
        ...item,
        message_side: item.user === this.userId ? 'sender': 'receiver'
      }))
    });
  }
}
