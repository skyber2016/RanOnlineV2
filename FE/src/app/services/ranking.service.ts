import { Injectable } from "@angular/core";
import { http } from "../common/interceptor";
import { environment } from "src/environments/environment";
@Injectable({
  providedIn: "root",
})
export class RankingService {
  constructor() {}

  getRanking(): Promise<any[]> {
    return http.get(environment.host + "/ranking");
  }
}
