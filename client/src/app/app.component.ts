import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/pagination';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit  {
baseUrl = 'https://localhost:5001/api/'
protected http = inject(HttpClient);
products:Product[]= [];
title="Stork"
ngOnInit(): void {
  this.http.get<Pagination<Product>>(this.baseUrl + 'product').subscribe({
    next:respons=> this.products=respons.data,
    error:error=> console.log(error),
    complete:()=> console.log("complete")
    
  });
}
}
