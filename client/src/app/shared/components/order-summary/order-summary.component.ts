import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { CartService } from '../../../core/services/cart.service';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-order-summary',
  standalone: true,
  imports: [MatLabel,CommonModule,FormsModule,MatFormField,MatIcon,MatButton,RouterLink],
  templateUrl: './order-summary.component.html',
  styleUrl: './order-summary.component.scss'
})
export class OrderSummaryComponent {
cartService = inject(CartService);
location: any;



  removeCouponCode(){

  }

  applyCouponCode(){

  }
}
