import { Component } from '@angular/core';
import { User } from './models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Banking App WebUI';

  selectedUser: User | undefined;

  selectedUserChange(selectedUser: User) {
    this.selectedUser = selectedUser;
  }

  constructor() {
  }
}
