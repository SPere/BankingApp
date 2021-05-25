import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Observable } from 'rxjs';
import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  providers: [
    {
      multi: true,
      provide: NG_VALUE_ACCESSOR,
      useExisting: UserListComponent
    }
  ]
})
export class UserListComponent {

  users$: Observable<User[]>;
  selectedUser: User | undefined;

  @Output() selectedUserChange: EventEmitter<User> = new EventEmitter();

  onChange = (newValue: number) => {};
  onTouch = () => {};

  constructor(private userService: UserService, private fb: FormBuilder) {
    this.users$ = this.userService.getUsers();
  }

  selectUser(user: User){
    this.selectedUser = user;
    this.selectedUserChange.emit(user);
  }
}
