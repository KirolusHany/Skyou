import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Cart, CartItem } from '../../shared/models/cart';
import { Product } from '../../shared/models/product';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
baseUrl=environment.apiUrl;
private httpClient = inject(HttpClient);
cart = signal<Cart| null>(null);
itemCount = computed(()=>{
    return  this.cart()?.items.reduce((sum, item)=>sum + item.quantity,0);
})

totals = computed(()=>{
  const cart= this.cart();
  if(!cart) return null;
  const subtotal  = cart.items.reduce((sum, item)=>sum + item.price * item.quantity,0);
  const shipping = 0;
  const discount = 0;
  return {
    shipping,discount,subtotal,total:subtotal+shipping-discount
  }
})

getCart(id:string){
  return this.httpClient.get<Cart>(this.baseUrl + 'cart?cartId='+id).pipe(
    map(cart=>{
      this.cart.set(cart);
      return cart;
    })
  )
}

setCart(cart:Cart){
  return this.httpClient.post<Cart>(this.baseUrl + 'cart', cart).subscribe({
    next:cart => this.cart.set(cart)  
  })
}

addItemToCart(item:CartItem|Product,quantity=1){
  const cart = this.cart() ?? this.CreateCart();
  if(this.isProduct(item)){
    item = this.mapProdutToCartItem(item);
  }
  cart.items= this.addOrUpdateItems(cart.items,item,quantity);
  this.setCart(cart);
}

removeItemFromCart(productId : number, quantity=1){
  const cart = this.cart();
  if(!cart) return;
  const index =  cart.items.findIndex(x=>x.productId === productId);
  if(index!==-1){
    if(cart.items[index].quantity>quantity){
      cart.items[index].quantity-=quantity;
    }else{
      cart.items.slice(index, 1); 
    }
    if(cart.items.length===0){
      this .deleteCart();
    }else{
      this.setCart(cart);
    }
  }
}
  deleteCart() {
    this.httpClient.delete(this.baseUrl + 'cart?id='+this.cart()?.id).subscribe({
      next:()=>{
        localStorage.removeItem('cart_id');
        this.cart.set(null);  
      }
    }); 
  }

  private addOrUpdateItems(items: CartItem[], item: CartItem, quantity: any): CartItem[] {
    const index = items.findIndex(x=>x.productId === item.productId);
    if(index ===-1){
      item.quantity = quantity;
      items.push(item); 
    }else{
      items[index].quantity += quantity;
    }
    return items;
  }
  private mapProdutToCartItem(item: Product): CartItem {
    return{
      productId: item.id,
      productName: item.name,
      price: item.price,
      quantity:0,
      pictureUrl: item.pictureUrl,
      brand: item.brand,
      type: item.type
    }
  }
private isProduct(item:Product|CartItem):item is Product{
  return(item as Product).id !== undefined;
}
private CreateCart(): Cart  {
  const cart = new Cart();
  localStorage.setItem('cart_id',cart.id);
  return cart;
}
}

