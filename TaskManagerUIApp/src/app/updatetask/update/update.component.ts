import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  task:any;
  display='none'; 
  constructor( private route: ActivatedRoute) {  
  }
  ngOnInit() {
    this.display='block'; 
    this.route.paramMap.subscribe(params => {
      this.task = params;
    });
  }
}
