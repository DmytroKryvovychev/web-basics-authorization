import { Component, OnInit } from '@angular/core';
import { AccountService } from './account.service';
import { Account, Role} from './account';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  accounts: Account[];
  roles: string[] = ['User', 'Admin'];
  email: string;
  password: string;
  role: string = 'User';


  ngOnInit() {
    this.accountService.get().subscribe(data => {
      data.forEach(acc => {

        acc.role = this.castRole(acc.role);
      });
      this.accounts = data;
    });
  }

  //you can delete only User, Admin has Protection
  onDelete(id: number) {
    this.accountService.delete(id).subscribe(idx => {
      this.accounts = this.accounts.filter(acc => acc.role !== 'Admin' ? acc.id !== idx : acc );
    });
  }

  onEditingRole(id: number) {
    this.accounts.map(item => { item.id === id ? item.isEditingRole = true : null});
  }

  cancelEditingRole(id: number) {
    this.accounts.map(item => { item.id === id ? item.isEditingRole = false : null });
  }


  onSubmit() {
    var i = this.role === 'User' ? Role.User : Role.Admin;
    this.accountService.set(this.email, this.password, i).subscribe(account => {
      account.role = this.castRole(account.role);
      this.accounts.push(account);
    });
  } 

  onChangeRole(id: number) {
    var intRole = this.role === 'User' ? 0 : 1;
    this.accountService.changeRole(id, intRole).subscribe(role => { this.accounts.forEach(acc => acc.id === id ? acc.role = this.roles[intRole] : null); });
    this.cancelEditingRole(id);
  }

  castRole(role: string) {
    switch (+role) {
    case 0:
      return "User";
    case 1:
      return "Admin";
    }
  }

}
