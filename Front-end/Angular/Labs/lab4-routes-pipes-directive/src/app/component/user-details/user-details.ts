import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-details',
  imports: [],
  templateUrl: './user-details.html',
  styles: ``,
})
export class UserDetails {
  userId = 0
  constructor(active: ActivatedRoute) {
    this.userId = active.snapshot.params["id"]
  }
}
