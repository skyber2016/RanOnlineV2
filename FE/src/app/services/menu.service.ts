import { Injectable } from "@angular/core";
import { Observable, of, from } from "rxjs";
import { environment } from "src/environments/environment";
import { http } from "../common/interceptor";
@Injectable({
  providedIn: "root",
})
export class MenuService {
  constructor() {}

  getMenu(): Promise<any[]> {
    return http.get(environment.host + "/menu");
  }

  create(data): Promise<any[]> {
    return http.post(environment.host + "/menu", data);
  }

  delete(id): Promise<any[]> {
    return http.delete(environment.host + "/menu", {
      data: { id },
    });
  }
}
