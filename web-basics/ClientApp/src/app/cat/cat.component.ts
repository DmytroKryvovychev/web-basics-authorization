import { Component, OnInit } from '@angular/core';
import { CatService } from './cat.service';
import { Cat } from './cat';

@Component({
  selector: 'app-cat',
  templateUrl: './cat.component.html',
  styleUrls: ['./cat.component.css']
})
export class CatComponent implements OnInit {

  constructor(private catService: CatService) { }

  cats: Cat[];

  ngOnInit() {
    this.catService.get().subscribe(data => {
      this.cats = data;
    });
  }
}
