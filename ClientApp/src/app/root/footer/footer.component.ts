import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  name: string;
  constructor(public Auth: AuthService) { }

  ngOnInit() {
    this.name = localStorage.getItem('Name');
  }

}
