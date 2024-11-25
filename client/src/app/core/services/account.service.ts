import { inject, Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Address, User } from '../../shared/models/user';
import { environment } from '../../../environments/environment.development';
import { map, pipe } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl=environment.apiUrl;
private httpclient = inject(HttpClient);
currentUser = signal<User|null>(null);

login(values: any){
  let params =new HttpParams();
  params =  params.append('useCookies',true);
  return this.httpclient.post<User>(this.baseUrl+'login', values, {params});
}

register(values:any){
  return this.httpclient.post(this.baseUrl+'account/register', values);

}

getUserInfo(){
  return this.httpclient.get<User>(this.baseUrl+'account/user-info',{}).pipe(
    map(user=>{
      this.currentUser.set(user);
      return user;
    })
  )
  
}
logout(){
  return this.httpclient.post(this.baseUrl+ 'account/logout',{});
}

updateAddress(address: Address) {
return this.httpclient.post(this.baseUrl+'account/address',address);

}

getAuthState() {
  return this.httpclient.get<{isAuthenticated: boolean}>(this.baseUrl + 'account/auth-status');
}
}
