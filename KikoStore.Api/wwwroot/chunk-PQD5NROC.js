import{Q as A}from"./chunk-FP5TAWYM.js";import{b as D,ja as j,k as F,n as T}from"./chunk-REULIXWP.js";import{Db as U,Fc as x,Ib as o,Jb as a,Oc as E,Uc as _,Vc as k,ba as v,db as s,dc as l,e as C,ea as S,fc as c,ka as d,lc as P,oa as w,ob as I,pc as u,qc as f,ub as M,w as b,x as g}from"./chunk-O6DIU7OS.js";var O="useandom-26T198340PX75pxJACKVERYMINDBUSHWOLF_GQZbfghjklqvwyzrict";var q=(i=21)=>{let t="",e=crypto.getRandomValues(new Uint8Array(i));for(;i--;)t+=O[e[i]&63];return t};var y=class{id=q();items=[];deliveryMethodId;paymentIntentId;clientSecret};var h=class i{baseUrl=T.apiUrl;http=d(D);cart=I(null);itemCount=x(()=>this.cart()?.items.reduce((t,e)=>t+e.quantity,0));selectedDelivery=I(null);totals=x(()=>{let t=this.cart(),e=this.selectedDelivery();if(!t)return null;let r=t.items.reduce((m,p)=>m+p.price*p.quantity,0),n=e?e.price:0;return{subtotal:r,shipping:n,total:r+n}});getCart(t){return this.http.get(this.baseUrl+"cart?id="+t).pipe(g(e=>(this.cart.set(e),e)))}setCart(t){return this.http.post(this.baseUrl+"cart",t).pipe(v(e=>{this.cart.set(e)}))}addItemToCart(t,e=1){return C(this,null,function*(){let r=this.cart()??this.createCart();this.isProduct(t)&&(t=this.mapProductToCartItem(t)),r.items=this.addOrUpdateItem(r.items,t,e),yield b(this.setCart(r))})}removeItemFromCart(t,e=1){return C(this,null,function*(){let r=this.cart();if(!r)return;let n=r.items.findIndex(m=>m.productId===t);n!==-1&&(r.items[n].quantity>e?r.items[n].quantity-=e:r.items.splice(n,1),r.items.length===0?this.deleteCart():yield b(this.setCart(r)))})}deleteCart(){this.http.delete(this.baseUrl+"cart?id="+this.cart()?.id).subscribe({next:()=>{localStorage.removeItem("cart_id"),this.cart.set(null)}})}addOrUpdateItem(t,e,r){let n=t.findIndex(m=>m.productId===e.productId);return n===-1?(e.quantity=r,t.push(e)):t[n].quantity+=r,t}mapProductToCartItem(t){return{productId:t.id,productName:t.name,price:t.price,quantity:0,pictureUrl:t.pictureUrl,brand:t.brand,type:t.type}}isProduct(t){return t.id!==void 0}createCart(){let t=new y;return localStorage.setItem("cart_id",t.id),t}static \u0275fac=function(e){return new(e||i)};static \u0275prov=S({token:i,factory:i.\u0275fac,providedIn:"root"})};function N(i,t){i&1&&(o(0,"div",9)(1,"button",10),l(2,"Checkout"),a(),o(3,"button",11),l(4,"Continue Shopping"),a()())}var L=class i{cartService=d(h);location=d(E);removeCouponCode(){}applyCouponCode(){}static \u0275fac=function(e){return new(e||i)};static \u0275cmp=w({type:i,selectors:[["app-order-summary"]],standalone:!0,features:[P],decls:25,vars:10,consts:[[1,"mx-auto","max-w-4xl","flex-1","space-y-6","w-full"],[1,"space-y-4","rounded-lg","border","border-gray-200","p-4","bg-white","shadow-sm"],[1,"text-xl","font-semibold"],[1,"space-y-4"],[1,"space-y-2"],[1,"flex","items-center","justify-between","gap-4"],[1,"font-medium","text-gray-500"],[1,"font-medium","text-gray-900"],[1,"flex","items-center","justify-between","gap-4","border-t","border-gray-200","pt-2"],[1,"flex","flex-col","gap-2"],["routerLink","/checkout","mat-flat-button",""],["routerLink","/shop","mat-button",""]],template:function(e,r){if(e&1&&(o(0,"div",0)(1,"div",1)(2,"p",2),l(3,"Order summary"),a(),o(4,"div",3)(5,"div",4)(6,"dl",5)(7,"dt",6),l(8,"Subtotal"),a(),o(9,"dd",7),l(10),u(11,"currency"),a()(),o(12,"dl",5)(13,"dt",6),l(14,"Delivery fee"),a(),o(15,"dd",7),l(16),u(17,"currency"),a()()(),o(18,"dl",8)(19,"dt",6),l(20,"Total"),a(),o(21,"dd",7),l(22),u(23,"currency"),a()()(),M(24,N,5,0,"div",9),a()()),e&2){let n,m,p;s(10),c(" ",f(11,4,(n=r.cartService.totals())==null?null:n.subtotal)," "),s(6),c(" ",f(17,6,(m=r.cartService.totals())==null?null:m.shipping)," "),s(6),c(" ",f(23,8,(p=r.cartService.totals())==null?null:p.total)," "),s(2),U(r.location.path()!=="/checkout"?24:-1)}},dependencies:[k,_,A,j,F]})};export{h as a,L as b};
