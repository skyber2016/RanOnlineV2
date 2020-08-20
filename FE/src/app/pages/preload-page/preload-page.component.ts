import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-preload-page',
  templateUrl: './preload-page.component.html',
  styleUrls: ['./preload-page.component.scss']
})
export class PreloadPageComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.navigate(['/landing']).then(()=>{
    });
  }

}
