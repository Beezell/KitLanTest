import { Component } from '@angular/core';
import { UserService , User} from '../../services/user.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-list',
  imports: [CommonModule],
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']  
})
export class UserListComponent {
  users: User[] = [];

  constructor(private userService: UserService){}

  ngOnInit(): void{
    this.userService.getUsers().subscribe(data => {
      this.users = data;
    }, error =>{
      console.error('Erreur récupération users', error);
    })
  }

}
