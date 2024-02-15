import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  userId: string = "";
  constructor(
    private route: ActivatedRoute
  ){ }

  ngOnInit(): void {
    this.userId = this.route.snapshot.params["userId"];
    console.log(": " , this.userId);
  }

}
