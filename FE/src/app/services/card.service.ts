import { Injectable } from "@angular/core";
import { http } from "../common/interceptor";
import { environment } from "src/environments/environment";
@Injectable({
  providedIn: "root",
})
export class CardService {
  constructor() {}

  postCard(opt): Promise<any> {
    return http.post(environment.host + "/card", opt);
  }
}
