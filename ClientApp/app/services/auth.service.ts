import { Http, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelper } from 'angular2-jwt/angular2-jwt';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';
import { Observable } from 'rxjs/Observable';

export const AUTH_CONFIG = {
  clientID: 'vWBS8Cqj17PabvdOa38tIo1VXcT1Idbq',
  domain: 'neelanlearns.auth0.com',
  callbackURL: 'http://localhost:5000/home'
};

@Injectable()
export class AuthService {
  profile: any;
  originUrl:string;
  private roles: string[] = [];

  auth0 = new auth0.WebAuth({
    clientID: AUTH_CONFIG.clientID,
    domain: AUTH_CONFIG.domain,
    responseType: 'id_token',
    audience: `https://${AUTH_CONFIG.domain}/userinfo`,
    redirectUri: 'http://localhost:5000/home',
    scope: 'openid profile email'
  });

  constructor(public router: Router, private http: Http,
    @Inject('ORIGIN_URL')originUrl: string) {
    this.readUserFromLocalStorage();
      this.originUrl=originUrl;
  }

  public isInRole(role){
    return this.roles.indexOf(role) > -1;
  }

  public login(): void {
    this.auth0.authorize();    
  }

  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {      
      if (authResult && authResult.accessToken) {
        localStorage.setItem("token",authResult.accessToken);
        this.readUserFromLocalStorage();
        window.location.hash = '';

        this.auth0.client.userInfo(authResult.accessToken, (err,user)=>{
            let newUser = {
              Id:'',
              FirstName:'',
              LastName:'',
              Email:''
            };

            newUser.Id = user.sub;
            newUser.FirstName = user.given_name;
            newUser.LastName = user.family_name;
            newUser.Email = user.email;
            localStorage.setItem("profile", JSON.stringify(user));

            if(err) console.log("err"+ JSON.stringify(err));

            this.http.post('http://localhost:5000/api/login',newUser)
            .map(res => res.json())
            .subscribe(r=> {
                this.router.navigate(['/home']);
              });
        });

        this.setSession(authResult);
      } else if (err) {
        this.router.navigate(['/home']);
        console.log(err);
        alert(`Error: ${err.error}. Check the console for further details.`);
      }
    });
    

  }


  private readUserFromLocalStorage(){
        var token = localStorage.getItem('token'); 
        
        this.profile = JSON.parse(localStorage.getItem('profile'));  

        if(token) {
          var jwtHelper = new JwtHelper();
          var decodedToken = jwtHelper.decodeToken(token);
          this.roles = decodedToken['https://neelanlearns/roles'] || [];
          localStorage.setItem("token",token);
        }
  }

  private setSession(authResult): void {
    // Set the time that the access token will expire at
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    localStorage.setItem('token', authResult.accessToken);
    localStorage.setItem('expires_at', expiresAt);
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('token');
    localStorage.removeItem('expires_at');
    localStorage.removeItem('profile');
    this.profile = null;
    this.roles = [];
    // Go back to the home route
    this.router.navigate(['/']);
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // access token's expiry time
    const expiresAt = JSON.parse(localStorage.getItem('expires_at'));
    return new Date().getTime() < expiresAt;
  }

}
