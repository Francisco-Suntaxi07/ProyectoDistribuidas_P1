import { Component, ElementRef, OnInit, QueryList, ViewChildren, Input  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChatMessage } from 'src/app/models/chat-message';
import { ChatService } from 'src/app/services/chat.service';

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

  constructor(
    private chatService: ChatService,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    let roomIdString: string;
    this.userId = this.route.snapshot.params["userId"];
    console.log("IMPU TRECIBIDO", this.roomId);
    if (this.roomId !== undefined) {
      roomIdString = this.roomId.toString();
    } else {
      roomIdString = "0";
    }
    console.log("SALA ROOM CREADA: ", roomIdString);
    this.chatService.joinRoom(roomIdString);
    this.lisenerMessage();
    
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
