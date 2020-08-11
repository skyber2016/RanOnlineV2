import { Injectable } from "@angular/core";
import { http } from "../common/interceptor";
import { environment } from "src/environments/environment";
@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor() {}

  login(param): Promise<any> {
    return http.post(environment.host + "/auth/login", param);
  }
  isLogin() {
    return window.localStorage.getItem("username") != null;
  }
}
