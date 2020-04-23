import { NgModule, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';



@NgModule({
  imports: [
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule
  ],
  exports: [
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule
  ]
})


export class MaterialModule implements OnInit {
  ngOnInit() {
  }
}
